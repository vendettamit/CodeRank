using System.Runtime.Serialization;

namespace CodeRank.Shared.Requests
{
    /// <summary>
    /// The get question request.
    /// </summary>
    [DataContract]
    public class GetQuestionRequest
    {
        /// <summary>
        /// Gets or sets the question identifier.
        /// </summary>
        /// <value>
        /// The question identifier.
        /// </value>
        [DataMember]
        public int QuestionId { get; set; }
    }
}
