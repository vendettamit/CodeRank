using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using CodeRank.Api.Entities;
using CodeRank.Api.Service.Contracts.Base;

namespace CodeRank.Api.Service.Contracts.Response
{
    /// <summary>
    /// Implements the response of compile operation
    /// </summary>
    [DataContract]
    [Serializable]
    public class CompileResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the compile result.
        /// </summary>
        [DataMember]
        public CompileResult CompileResult { get; set; }
    }
}
