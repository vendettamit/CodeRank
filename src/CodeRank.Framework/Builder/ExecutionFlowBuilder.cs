using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CodeRank.Framework.ExecutionFlow;
using CodeRank.Framework.ExecutionFlow.Base;

namespace CodeRank.Framework.Builder
{
    /// <summary>
    /// Builds the execution flow for compilation unit in sequential order.
    /// </summary>
    public static class ExecutionFlowBuilder
    {
        public static IExecutionStrategy Build()
        {
            IExecutionStrategy executer = new CompilationUnit(null);

            return executer;
        }
    }
}
