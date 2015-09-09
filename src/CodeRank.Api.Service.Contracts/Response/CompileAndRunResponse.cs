using System;
using System.Runtime.Serialization;

using CodeRank.Api.Entities;

namespace CodeRank.Api.Service.Contracts.Response
{
    /// <summary>
    /// Holds the entity of compile and run response.
    /// </summary>
    [DataContract]
    [Serializable]
    public class CompileAndRunResponse : CompileResponse
    {
        /// <summary>
        /// Gets or sets the test result.
        /// </summary>
        [DataMember]
        public TestResult TestResult { get; set; }
    }
}
