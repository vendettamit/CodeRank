using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRank.Framework.Entities
{
    /// <summary>
    /// Implements the execution result
    /// </summary>
    public class ExecutionResult
    {
        /// <summary>
        /// Gets a value indicating whether has error.
        /// </summary>
        public bool HasError
        {
            get
            {
                return string.IsNullOrEmpty(this.ErrorDescription);
            }
        }

        /// <summary>
        /// Gets or sets the error description.
        /// </summary>
        public string ErrorDescription { get; set; }

        /// <summary>
        /// Gets or sets the line numbers.
        /// </summary>
        public int[] LineNumbers { get; set; }

        /// <summary>
        /// Gets or sets the test result.
        /// </summary>
        public TestResult TestResult { get; set; }
    }
}
