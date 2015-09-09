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
    /// Provides the mean to compile a code unit.
    /// </summary>
    internal class CompilationUnit : IExecutionStrategy
    {        
        /// <summary>
        /// The succssor.
        /// </summary>
        private IExecutionStrategy successor;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompilationUnit"/> class.
        /// </summary>
        /// <param name="successor">
        /// The successor.
        /// </param>
        public CompilationUnit(IExecutionStrategy successor)
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
            // Invokes the action on flow requirements.
            if (!context.LastExecutionResult.HasError)
            {
                context.LastExecutionResult = requirement.CompileOperation.Invoke(requirement.SourceCode);
            }

            if (this.successor != null)
            {
                this.successor.Execute(context, requirement);
            }
        }
    }
}
