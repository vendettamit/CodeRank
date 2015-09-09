using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CodeRank.Api.Entities
{
    /// <summary>
    /// Entity to emit the result of test run.
    /// </summary>
    [DataContract]
    [Serializable]
    public class TestResult
    {
        /// <summary>
        /// Gets or sets the string result.
        /// </summary>
        [DataMember]
        public string StringResult { get; set; }

        /// <summary>
        /// Gets or sets the totalTests
        /// </summary>
        [DataMember]
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the passed.
        /// </summary>
        [DataMember]
        public int Passed { get; set; }

        /// <summary>
        /// Gets or sets the failed tests.
        /// </summary>
        [DataMember]
        public int Failed { get; set; }

        /// <summary>
        /// Gets or sets the compilation errors.
        /// </summary>
        [DataMember]
        public string Error { get; set; }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return string.Format(
                "Total: {0}, Passed: {1}, Failed{2} \n {3}",
                this.Total,
                this.Passed,
                this.Failed,
                this.StringResult);
        }
    }
}
