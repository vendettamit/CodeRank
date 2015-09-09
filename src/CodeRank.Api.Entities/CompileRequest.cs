using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRank.Api.Entities
{
    /// <summary>
    /// Entity that implements the members required for compilation operation
    /// </summary>
    [Serializable]
    public class CompileArgs
    {
        /// <summary>
        /// Gets or sets the source code text.
        /// </summary>
        public string SourceCode { get; set; }
    }
}
