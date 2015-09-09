using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CodeRank.Api.Service.Contracts.Data.Enums
{
    /// <summary>
    /// Flag to identify the comiler type
    /// </summary>
    [DataContract]
    public enum LanguageType
    {
        /// <summary>
        /// Flag indicating a undefined compiler types
        /// </summary>
        [EnumMember]
        Undefined = 0,

        /// <summary>
        /// Flag indicating CSharp compiler
        /// </summary>
        [EnumMember]
        CSharp = 1,

        /// <summary>
        /// Flag indicating Visual basic compiler
        /// </summary>
        [EnumMember]
        VisualBasic = 2,

        /// <summary>
        /// Flag indicating Java compiler
        /// </summary>
        [EnumMember]
        Java = 3,

        /// <summary>
        /// Flag indicating JavaScript compiler
        /// </summary>
        [EnumMember]
        JavaScript = 4
    }
}
