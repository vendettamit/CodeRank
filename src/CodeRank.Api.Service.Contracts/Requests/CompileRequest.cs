using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using CodeRank.Api.Service.Contracts.Base;
using CodeRank.Api.Service.Contracts.Data.Enums;

namespace CodeRank.Api.Service.Contracts.Requests
{
    /// <summary>
    /// Implements the request for Compilation operation
    /// </summary>
    [DataContract]
    [Serializable]
    public class CompileRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        [DataMember]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the problem id.
        /// </summary>
        [DataMember]
        public string ProblemId { get; set; }

        /// <summary>
        /// Gets or sets the source code.
        /// </summary>
        [DataMember]
        public string SourceCode { get; set; }

        /// <summary>
        /// Gets or sets the language
        /// </summary>
        [DataMember]
        public LanguageType Language { get; set; }
    }
}
