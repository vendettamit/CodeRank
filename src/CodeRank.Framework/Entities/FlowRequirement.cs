using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using CodeRank.Framework.Validations;

namespace CodeRank.Framework.Entities
{
    /// <summary>
    /// Contains all the information required during the execution of Compilation unit
    /// </summary>
    public class FlowRequirement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlowRequirement"/> class.
        /// </summary>
        /// <param name="sourceCode">
        /// The source code.
        /// </param>
        public FlowRequirement(string sourceCode)
        {
            this.SourceCode = sourceCode;

            this.SourceCode.MustNotBeNull("The source code must not be null.");
        }

        /// <summary>
        /// Gets the source code.
        /// </summary>
        public string SourceCode { get; private set; }

        /// <summary>
        /// Gets or sets the action that will compile and emit the result of execution
        /// </summary>
        public Func<string, ExecutionResult> CompileOperation { get; set; }

        /// <summary>
        /// Gets or sets the test runner operation.
        /// </summary>
        public Func<string, Assembly, TestResult> TestRunnerOperation { get; set; }

        /// <summary>
        /// Gets or sets the test assembly of given operation.
        /// </summary>
        public Assembly TestAssembly { get; set; }
    }
}
