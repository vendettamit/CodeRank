using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CodeRank.Framework.Entities;
using CodeRank.Framework.ExecutionFlow.Context;

namespace CodeRank.Framework.ExecutionFlow.Base
{
    /// <summary>
    /// Provieds the methods for Executions stategy implementation
    /// </summary>
    public interface IExecutionStrategy
    {
        /// <summary>
        /// Executes the source code compilation unit with a strategic sequential pattern. 
        /// </summary>
        /// <param name="context">
        /// The execution context state.
        /// </param>
        /// <param name="requirement">
        /// The requirement.
        /// </param>
        void Execute(ExecutionContext context, FlowRequirement requirement);
    }
}
