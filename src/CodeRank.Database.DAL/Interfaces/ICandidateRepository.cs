using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeRank.Database.DAL.Database;

namespace CodeRank.Database.DAL.Interfaces
{
    /// <summary>
    /// The interface to handle candidate related data access/update.
    /// </summary>
    public interface ICandidateRepository : IRepositoryBase
    {
        /// <summary>
        /// Adds the candidate.
        /// </summary>
        /// <param name="candidateDetails">The candidate details.</param>
        void AddCandidate(Candidate candidateDetails);

        /// <summary>
        /// Updates the candidate.
        /// </summary>
        /// <param name="candidateDetails">The candidate details.</param>
        void UpdateCandidate(Candidate candidateDetails);

        /// <summary>
        /// Deletes the candidate.
        /// </summary>
        /// <param name="candidateID">The candidate identifier.</param>
        void DeleteCandidate(int candidateID);

        /// <summary>
        /// Gets all candidates.
        /// </summary>
        /// <returns>All candidates</returns>
        IList<Candidate> GetAllCandidates();

        /// <summary>
        /// Gets the candidate details.
        /// </summary>
        /// <param name="candidateID">The candidate identifier.</param>
        /// <returns>Get candidate</returns>
        IList<GetCandidate_Result> GetCandidate(int candidateID);
    }
}
