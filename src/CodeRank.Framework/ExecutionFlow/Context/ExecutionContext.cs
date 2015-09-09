using System.Collections.Generic;
using System.Net.Cache;

using CodeRank.Framework.Abstract;
using CodeRank.Framework.Entities;

namespace CodeRank.Framework.ExecutionFlow.Context
{
    /// <summary>
    /// Context providing the runtime state of an execution
    /// </summary>
    public class ExecutionContext
    {
        /// <summary>
        /// Gets or sets the last execution result.
        /// </summary>
        public ExecutionResult LastExecutionResult { get; set; }
    }
}
