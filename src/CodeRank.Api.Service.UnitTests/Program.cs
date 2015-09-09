using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using CodeRank.Api.Entities;
using CodeRank.Compiler.Csharp;
using CodeRank.Nunit.TestRunner;

using NUnit.Framework.Internal;

namespace CodeRank.Api.Service.UnitTests
{
    /// <summary>
    /// The program.
    /// </summary>
    [Serializable]
    public class Program : MarshalByRefObject
    {
        private AppDomain testDomain;

        /// <summary>
        /// The test is to verify the integration of CSharp compiler and the Nunit test runner. 
        /// TODO: The Generated assemblies are not being unloaded. This would lead the problem to have unused assemblies loaded in the AppDomain.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        static void Main(string[] args)
        {
            new Program().Setup();
        }

        public void Setup()
        {
            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
            string pathToDlls = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);

            AppDomainSetup domainSetup = new AppDomainSetup { /*PrivateBinPath = Assembly.GetExecutingAssembly().CodeBase */ };
            domainSetup.ApplicationBase = pathToDlls;
            this.testDomain = AppDomain.CreateDomain(Guid.NewGuid().ToString(), null, domainSetup, this.GetPermissionSet());
            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
            try
            {
                this.InvokeRun();
            }
            catch (Exception exception)
            {
                // Throw the unhandled exception as fault
                Console.WriteLine(exception.Message);
            }
            finally
            {
                AppDomain.Unload(this.testDomain);
            }
        }

        /// <summary> Runs a test in another application domain. </summary>
        /// <param name="testDomainName"> The name to assign to the application domain. </param>
        /// <param name="assembly"> The assembly that contains the test to run. </param>
        /// <param name="args"> The arguments to pass to the runner inside the application domain. </param>
        /// <returns> The exception that occurred in the test, or null if no exception occurred. </returns>
        public void InvokeRun()
        {
            this.testDomain.Load(Assembly.GetExecutingAssembly().GetName());

            var instance = (Program)this.testDomain.CreateInstanceAndUnwrap(
              typeof(Program).Assembly.FullName,
              typeof(Program).FullName);

            instance.Run();
        }

        public void Run()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("using CodeRank.CSharpProblems.Ruleset.Base;");
            sb.Append("namespace CodeRank.CSharpProblems.Ruleset.Solution");
            sb.Append("{");
            sb.Append("public class SampleTestRuleSolution : ISampleTest");
            sb.Append("{");
            sb.Append("public int Sum(int a, int b)");
            sb.Append("{");
            sb.Append("return a + b;");
            sb.Append("}");
            sb.Append("}");
            sb.Append("}");

            CompilerEngine engine = new CompilerEngine();
            var response = engine.Compile(new CompileArgs { SourceCode = sb.ToString() });

            string pathToDlls = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
            var assemblyFilePath = Path.Combine(pathToDlls, response.AssemblyFileName);

            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
            AppDomain.CurrentDomain.Load(response.LoadedStream.ToArray());

            CoreExtensions.Host.InstallBuiltins();

            var runner = new InMemoryNunitTestRunner().RunTests(new TestRunRequest { TestAssembly = Assembly.Load("CodeRank.CSharpProblems.Ruleset"), SourceAssemblyStream = response.LoadedStream });

            Console.WriteLine(runner);
            Console.Read();
        }

        /// <summary>
        /// create a permission set
        /// </summary>
        private PermissionSet GetPermissionSet()
        {
            // create an evidence of type zone
            var ev = new Evidence();
            ev.AddHostEvidence(new Zone(SecurityZone.MyComputer));

            // return the PermissionSets specific to the type of zone
            return SecurityManager.GetStandardSandbox(ev);
        }
    }
}
