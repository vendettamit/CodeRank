using System;

using CodeRank.Framework.Entities;
using CodeRank.Framework.ExecutionFlow.Base;
using CodeRank.Framework.ExecutionFlow.Context;
using CodeRank.Framework.Validations;

namespace CodeRank.Framework.ExecutionFlow
{
    /// <summary>
    /// Exception occurred in any step will be handled here.
    /// </summary>
    internal class CompilationUnitExceptionHandlingProxy : IExecutionStrategy
    {
        /// <summary>
        /// The successor.
        /// </summary>
        private IExecutionStrategy successor;

        /// <summary>
        /// The exception handler.
        /// </summary>
        private Action<Exception> exceptionHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompilationUnitExceptionHandlingProxy"/> class.
        /// </summary>
        /// <param name="successor">
        /// The successor.
        /// </param>
        /// <param name="exceptionHandler">
        /// The exception Handler.
        /// </param>
        public CompilationUnitExceptionHandlingProxy(IExecutionStrategy successor, Action<Exception> exceptionHandler)
        {
            this.successor = successor;
            this.exceptionHandler = exceptionHandler;

            this.successor.MustNotBeNull();
            this.exceptionHandler.MustNotBeNull("The exception handler must not be null.");
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="requirement">
        /// The requirement.
        /// </param>
        public void Execute(ExecutionContext context, FlowRequirement requirement)
        {
            try
            {
                 this.successor.Execute(context, requirement);
            }
            catch (Exception exception)
            {
                context.LastExecutionResult = new ExecutionResult
                                                  {
                                                      ErrorDescription =
                                                          string.Format(
                                                              "An exception occurred during execution. {0}",
                                                              exception.Message)
                                                  };
                this.exceptionHandler(exception);
            }
        }
    }
}
