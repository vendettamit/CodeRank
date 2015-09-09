using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeRank.Api.Entities
{
    /// <summary>
    /// Implements the members required to create request for Test run operation
    /// </summary>
    [Serializable]
    public class TestRunRequest
    {
        /// <summary>
        /// Gets or sets the assembly that contains the tests.
        /// </summary>
        public Assembly TestAssembly { get; set; }

        /// <summary>
        /// Gets or sets the source assembly that will be tested against the tests.
        /// </summary>
        public MemoryStream SourceAssemblyStream { get; set; }
    }
}
