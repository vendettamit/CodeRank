using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Security.Policy;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using CodeRank.Api.Entities;
using CodeRank.Api.Service.Contracts;
using CodeRank.Api.Service.Contracts.Requests;
using CodeRank.Api.Service.Contracts.Response;
using CodeRank.Compiler.Base;
using CodeRank.Compiler.Csharp;
using CodeRank.Framework.Builder;
using CodeRank.Framework.Entities;
using CodeRank.Framework.ExecutionFlow.Context;
using CodeRank.Nunit.TestRunner;

using NUnit.Framework.Internal;

using Roslyn.Compilers.CSharp;

using CompileRequest = CodeRank.Api.Service.Contracts.Requests.CompileRequest;

namespace CodeRank.Api.Service
{
    /// <summary>
    /// Implements the method of compiler service.
    /// </summary>
    [Serializable]
    public class CompilerService : MarshalByRefObject, ICompilationService
    {
        /// <summary>
        /// Holds the csharp rules assembly name.
        /// </summary>
        private const string CsharpRulesAssemblyName = "CodeRank.CSharpProblems.Ruleset";

        /// <summary>
        /// Holds the instance of test domain.
        /// </summary>
        private AppDomain testDomain;

        /// <summary>
        /// The assembly file path.
        /// </summary>
        private string assemblyFilePath;

        /// <summary>
        /// The compile operation to compile the requested code unit.
        /// </summary>
        /// <param name="compileRequest">
        /// The compile request.
        /// </param>
        /// <returns>
        /// The <see cref="CompileResponse"/>.
        /// </returns>
        public CompileResponse Compile(CompileRequest compileRequest)
        {
            // TODO: Future version execution
            /*
            FlowRequirement requirement = new FlowRequirement(compileRequest.SourceCode);
            ExecutionFlowBuilder.Build().Execute(ContextProvider.Context, requirement);
             * */

            ICompiler csharpCompiler = new CompilerEngine();
            CompileArgs arguments = new CompileArgs { SourceCode = compileRequest.SourceCode };
            
            var result = csharpCompiler.Compile(arguments);

            return new CompileResponse { CompileResult = result };
        }

        /// <summary>
        /// Compiles the code and runs the test against the submitted code.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="CompileAndRunResponse"/>.
        /// </returns>
        /// <exception cref="FaultException">Unhandled exception
        /// </exception>
        public CompileAndRunResponse CompileAndRunTests(CompileAndRunRequest request)
        {
            string pathToDlls = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
            Trace.WriteLine(AppDomain.CurrentDomain.FriendlyName);
            AppDomainSetup domainSetup = new AppDomainSetup { /*PrivateBinPath = Assembly.GetExecutingAssembly().CodeBase */ };
            domainSetup.ApplicationBase = pathToDlls;
            this.testDomain = AppDomain.CreateDomain(Guid.NewGuid().ToString(), null, domainSetup, this.GetPermissionSet());

            try
            {
                return this.Run(request);
            }
            catch (Exception exception)
            {
                // Throw the unhandled exception as fault
                throw new FaultException(exception.Message);
            }
            finally
            {
                this.Cleanup();
            }
        }

        /// <summary>
        /// The compile and run tests in other domain.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="CompileAndRunResponse"/>.
        /// </returns>
        /// <exception cref="FaultException">Unhandled exception
        /// </exception>
        public CompileAndRunResponse CompileAndRunTestsInOtherDomain(CompileAndRunRequest request)
        {
            Trace.WriteLine(AppDomain.CurrentDomain.FriendlyName);
            var compileResponse = this.Compile(request);

            if (!string.IsNullOrEmpty(compileResponse.CompileResult.Error))
            {
                return new CompileAndRunResponse { CompileResult = compileResponse.CompileResult };
            }

            this.CreateDomainAndUnwrapObject(compileResponse.CompileResult.LoadedStream, compileResponse.CompileResult.AssemblyFileName);
            
            // Ready to run the tests.
            CoreExtensions.Host.InstallBuiltins();

            // run the test in safe mode so that service doesn't go in faulted state.
            try
            {
                var runnerResult =
                    new InMemoryNunitTestRunner().RunTests(
                        new TestRunRequest { TestAssembly = Assembly.Load(CsharpRulesAssemblyName) });

                return new CompileAndRunResponse { TestResult = runnerResult, CompileResult = new CompileResult() };
            }
            catch (Exception exception)
            {
                // Throw the unhandled exception as fault
                throw new FaultException(exception.Message);
            }
        }

        /// <summary>
        /// The create domain and unwrap object.
        /// </summary>
        /// <param name="assemblyStream">
        /// The assembly stream.
        /// </param>
        /// <param name="assemblyFileName">
        /// The assembly File Name.
        /// </param>
        private void CreateDomainAndUnwrapObject(MemoryStream assemblyStream, string assemblyFileName)
        {
            string pathToDlls = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
            this.assemblyFilePath = Path.Combine(pathToDlls, assemblyFileName);

            // AppDomainSetup domainSetup = new AppDomainSetup { PrivateBinPath = Assembly.GetExecutingAssembly().CodeBase };
            // domainSetup.ApplicationBase = pathToDlls;
            // this.testDomain = AppDomain.CreateDomain(Guid.NewGuid().ToString(), null, domainSetup, this.GetPermissionSet());
            // File.WriteAllBytes(this.assemblyFilePath, assemblyStream.ToArray());
            Trace.WriteLine(AppDomain.CurrentDomain.FriendlyName);
            AppDomain.CurrentDomain.Load(assemblyStream.ToArray());
        }

        /// <summary>
        /// Runs a test in another application domain. 
        /// </summary>
        /// <param name="args">
        /// The arguments to pass to the runner inside the application domain. 
        /// </param>
        /// <returns>
        /// The exception that occurred in the test, or null if no exception occurred. 
        /// </returns>
        public CompileAndRunResponse Run(CompileAndRunRequest args)
        {
            this.testDomain.Load(Assembly.GetExecutingAssembly().GetName());

            var instance = (CompilerService)this.testDomain.CreateInstanceAndUnwrap(
              typeof(CompilerService).Assembly.FullName,
              typeof(CompilerService).FullName);

            return instance.CompileAndRunTestsInOtherDomain(args);
        }

        /// <summary>
        /// create a permission set
        /// </summary>
        /// <returns>
        /// The <see cref="PermissionSet"/>.
        /// </returns>
        private PermissionSet GetPermissionSet()
        {
            // create an evidence of type zone
            var ev = new Evidence();
            ev.AddHostEvidence(new Zone(SecurityZone.MyComputer));

            // return the PermissionSets specific to the type of zone
            return SecurityManager.GetStandardSandbox(ev);
        }

        /// <summary>
        /// The cleanup.
        /// </summary>
        private void Cleanup()
        {
            Trace.WriteLine(AppDomain.CurrentDomain.FriendlyName);
            AppDomain.Unload(this.testDomain);
            Trace.WriteLine(AppDomain.CurrentDomain.FriendlyName);
        }
    }
}
