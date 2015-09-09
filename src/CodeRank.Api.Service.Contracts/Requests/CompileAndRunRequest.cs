using System;
using System.Runtime.Serialization;

using CodeRank.Api.Entities;

namespace CodeRank.Api.Service.Contracts.Requests
{
    /// <summary>
    /// Holds the data required to send a request for compile and run
    /// </summary>
    [DataContract]
    [Serializable]
    public class CompileAndRunRequest : CompileRequest
    {
    }
}
