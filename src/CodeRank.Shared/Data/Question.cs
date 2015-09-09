using System.Runtime.Serialization;

namespace CodeRank.Shared.Data
{
    /// <summary>
    /// The question class
    /// </summary>
    [DataContract]
    public class Question
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [DataMember]
        public string Description { get; set; }

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
