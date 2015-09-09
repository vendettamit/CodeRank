using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CodeRank.Api.Service.Contracts.Base
{
    /// <summary>
    /// Provides base of all authorized requests for the Code rank services.
    /// </summary>
    [DataContract]
    public abstract class AuthorizeRequestBase : RequestBase
    {
    }
}
