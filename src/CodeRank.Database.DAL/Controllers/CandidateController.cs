using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeRank.Database.DAL.Database;
using CodeRank.Database.DAL.Interfaces;

namespace CodeRank.Database.DAL.Controllers
{
    /// <summary>
    /// Controller for candidate 
    /// </summary>
    public class CandidateController
    {
        /// <summary>
        /// The repository
        /// </summary>
        private ICandidateRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CandidateController"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public CandidateController(ICandidateRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Adds the candidate.
        /// </summary>
        /// <param name="candidateDetails">The candidate details.</param>
        public void AddCandidate(Candidate candidateDetails)
        {
            this.repository.AddCandidate(candidateDetails);
        }

        /// <summary>
        /// Updates the candidate.
        /// </summary>
        /// <param name="candidateDetails">The candidate details.</param>
        public void UpdateCandidate(Candidate candidateDetails)
        {
            this.repository.UpdateCandidate(candidateDetails);
        }

        /// <summary>
        /// Deletes the candidate.
        /// </summary>
        /// <param name="candidateID">The candidate identifier.</param>
        public void DeleteCandidate(int candidateID)
        {
            this.repository.DeleteCandidate(candidateID);
        }

        /// <summary>
        /// Gets all candidates.
        /// </summary>
        /// <returns>List of candidates</returns>
        public IList<Candidate> GetAllCandidates()
        {
            return this.repository.GetAllCandidates();
        }

        /// <summary>
        /// Gets the candidate details.
        /// </summary>
        /// <param name="candidateID">The candidate identifier.</param>
        /// <returns>Candidate details</returns>
        public IList<GetCandidate_Result> GetCandidate(int candidateID)
        {
            return this.repository.GetCandidate(candidateID);
        }
    }
}
