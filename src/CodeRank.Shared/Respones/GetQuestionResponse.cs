using System.Runtime.Serialization;
using CodeRank.Shared.Data;

namespace CodeRank.Shared.Responses
{
    /// <summary>
    /// The get question response
    /// </summary>
    [DataContract]
    public class GetQuestionResponse
    {
        /// <summary>
        /// Gets or sets the question.
        /// </summary>
        /// <value>
        /// The question.
        /// </value>
        [DataMember]
        public Question Question { get; set; }
    }
}
