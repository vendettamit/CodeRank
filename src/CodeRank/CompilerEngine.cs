using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeRank.Api.Entities;
using CodeRank.Compiler.Base;
using CodeRank.CSharpProblems.Ruleset.Base;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;

namespace CodeRank.Compiler.Csharp
{
    /// <summary>
    /// The compiler engine implementation of Csharp
    /// </summary>
    public class CompilerEngine : CompilerBase
    {
        /// <summary>
        /// Holds the name of the assembly file.
        /// </summary>
        private string assemblyFile;

        /// <summary>
        /// Holds the template for the main block.
        /// </summary>
        private string mainBlock = @"public class Program
                            {
                                public static void Main(string[] args)
                                {
                                    $
                                }

                                private static string output = """";

                                public static string GetResult()
                                {
                                    return output;
                                }

                                public static void Print(string statement)
                                {
                                  output = System.String.Concat(output, ""<br>"","">"", statement);
                                }
                            }";

        /// <summary>
        /// Implementation of Inner compile
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// Assembly generated after the compilation
        /// </returns>
        protected override CompileResult InnerCompile(CompileArgs request)
        {
            var result = new CompileResult();

            // this.mainBlock = this.mainBlock.Replace("$", this.mainBlockStatements);
            // this.code = string.Concat(this.code, Environment.NewLine, this.mainBlock);

            // TODO: Remove this hack when the code templates are ready.
            if (!request.SourceCode.Contains("CodeRank.CSharpProblems.Ruleset.Base"))
            {
                request.SourceCode = string.Concat("using CodeRank.CSharpProblems.Ruleset.Base; \n", request.SourceCode);
            }

            var tree = SyntaxTree.ParseText(request.SourceCode);

            // compiler section starts
            this.assemblyFile = string.Format("{0}.dll", Guid.NewGuid());
            Compilation compilation = Compilation
            .Create(this.assemblyFile, new CompilationOptions(OutputKind.DynamicallyLinkedLibrary))
            .AddSyntaxTrees(tree)
            .AddReferences(new[]
                {
                    new MetadataFileReference(typeof(Console).Assembly.Location), 
                    new MetadataFileReference(typeof(object).Assembly.Location), 
                    new MetadataFileReference(typeof(IEnumerable<>).Assembly.Location),
                    new MetadataFileReference(typeof(IQueryable).Assembly.Location),
                    new MetadataFileReference(this.GetType().Assembly.Location),
                    new MetadataFileReference(typeof(ISampleTest).Assembly.Location)
                }.ToList());

            IEnumerable<Diagnostic> errorsAndWarnings = compilation.GetDiagnostics().ToList();

            if (errorsAndWarnings.Any())
            {
                StringBuilder errors = new StringBuilder();

                foreach (var errorsAndWarning in errorsAndWarnings)
                {
                    errors.AppendFormat("Error: {0}{1}", errorsAndWarning.Info.GetMessage(CultureInfo.InvariantCulture), "<br\\>");

                    //// errors.AppendFormat("Location: {0}{1}", errorsAndWarning.Location, Environment.NewLine);
                    errors.AppendFormat("{0}{1}", errorsAndWarning.Location.SourceTree.GetText().ToString(errorsAndWarning.Location.SourceSpan), "<br\\>");
                    //// errors.AppendFormat("Line: {0}{1}", errorsAndWarning.Location.GetLineSpan(usePreprocessorDirectives: true), Environment.NewLine);
                }

                result.Error = string.Concat(Environment.NewLine, errors.ToString());
                result.FirstErrorLine =
                    errorsAndWarnings.First().Location.GetLineSpan(usePreprocessorDirectives: true).ToString();

                // return the result and skip the loading of Assembly as it's not generated because of the compilation errors
                return result;
            }

            // Compiler section ends
            MemoryStream stream = new MemoryStream();
            EmitResult compileResult = compilation.Emit(stream);

            // result.GeneratedAssembly = Assembly.Load(stream.GetBuffer());
            result.LoadedStream = stream;
            result.AssemblyFileName = this.assemblyFile;
            return result;
        }
    }
}
