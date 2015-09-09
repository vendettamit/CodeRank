using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRank.Framework.ExecutionFlow.Context
{
    /// <summary>
    /// Singleton implementation of Execution Context
    /// </summary>
    public static class ContextProvider
    {
        /// <summary>
        /// Holds the lazy instance of the 
        /// </summary>
        private static readonly Lazy<ExecutionContext> LazyContext = new Lazy<ExecutionContext>(() => new ExecutionContext());

        /// <summary>
        /// Gets the execution context singleton instance.
        /// </summary>
        public static ExecutionContext Context
        {
            get
            {
                return LazyContext.Value;
            }
        }
    }
}
