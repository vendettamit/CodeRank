using System.Runtime.Serialization;
namespace CodeRank.Shared.Data
{
    /// <summary>
    /// The solution for as given question
    /// </summary>
    [DataContract]
    public class Solution
    {
        /// <summary>
        /// Gets or sets the question identifier for that the solution is given.
        /// </summary>
        /// <value>
        /// The question identifier.
        /// </value>
        [DataMember]
        public int QuestionId { get; set; }

        /// <summary>
        /// Gets or sets the solution description.
        /// </summary>
        /// <value>
        /// The solution description.
        /// </value>
        public string  SolutionDescription { get; set; }
    }
}
