using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CodeRank.Framework.Entities;
using CodeRank.Framework.ExecutionFlow.Base;
using CodeRank.Framework.ExecutionFlow.Context;
using CodeRank.Framework.Validations;

namespace CodeRank.Framework.ExecutionFlow
{
    /// <summary>
    /// The init compiler compilation unit proxy.
    /// </summary>
    internal class InitCompilerCompilationUnitProxy : IExecutionStrategy
    {
        /// <summary>
        /// The succssor.
        /// </summary>
        private IExecutionStrategy successor;

        /// <summary>
        /// Initializes a new instance of the <see cref="InitCompilerCompilationUnitProxy"/> class.
        /// </summary>
        /// <param name="successor">
        /// The successor.
        /// </param>
        public InitCompilerCompilationUnitProxy(IExecutionStrategy successor)
        {
            this.successor = successor;

            this.successor.MustNotBeNull();
        }

        /// <summary>
        /// Executes the source code compilation unit with a strategic sequential pattern. 
        /// </summary>
        /// <param name="context">
        /// The execution context state.
        /// </param>
        /// <param name="requirement">
        /// The requirement.
        /// </param>
        public void Execute(ExecutionContext context, FlowRequirement requirement)
        {
            // TODO: Find the compilation unit from service locator and attach the compile function to the requirement
            this.successor.Execute(context, requirement);
        }
    }
}
