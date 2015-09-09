using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRank.Framework.Entities
{
    /// <summary>
    /// Contains the specific type of result from the Unit test runner.
    /// </summary>
    public class TestResult
    {
        /// <summary>
        /// Gets or sets the string result.
        /// </summary>
        public string StringResult { get; set; }

        /// <summary>
        /// Gets or sets the passed.
        /// </summary>
        public int Passed { get; set; }

        /// <summary>
        /// Gets or sets the failed.
        /// </summary>
        public int Failed { get; set; }
    }
}
