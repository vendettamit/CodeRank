using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CodeRank.Api.Service.Contracts.Base
{
    /// <summary>
    /// Implements the response base class for all services repsonses of Code rank
    /// </summary>
    [DataContract]
    [Serializable]
    public abstract class ResponseBase
    {
    }
}
