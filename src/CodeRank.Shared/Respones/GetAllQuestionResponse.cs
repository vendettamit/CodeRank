using System.Collections.Generic;
using System.Runtime.Serialization;
using CodeRank.Shared.Data;

namespace CodeRank.Shared.Respones
{
    /// <summary>
    /// The get all question response.
    /// </summary>
    [DataContract]
    public class GetAllQuestionResponse
    {
        /// <summary>
        /// Gets or sets the questions.
        /// </summary>
        /// <value>
        /// The questions.
        /// </value>
        [DataMember]
        public List<Question> Questions { get; set; }
    }
}
