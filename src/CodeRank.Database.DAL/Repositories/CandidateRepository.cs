using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeRank.Database.DAL.Database;
using CodeRank.Database.DAL.Interfaces;

namespace CodeRank.Database.DAL.Repositories
{
    /// <summary>
    /// The repository to handle candidate related data access/update.
    /// </summary>
    public class CandidateRepository : RepositoryBase, ICandidateRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CandidateRepository"/> class.
        /// </summary>
        public CandidateRepository()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CandidateRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CandidateRepository(CodeRankEntities context)
            : base(context)
        {
        }

        /// <summary>
        /// Adds the candidate.
        /// </summary>
        /// <param name="candidateDetails">The candidate details.</param>
        public void AddCandidate(Candidate candidateDetails)
        {
            Context.Candidates.Add(candidateDetails);
        }

        /// <summary>
        /// Updates the candidate.
        /// </summary>
        /// <param name="candidateDetails">The candidate details.</param>
        public void UpdateCandidate(Candidate candidateDetails)
        {
            var candidate = Context.Candidates.FirstOrDefault(@this => @this.CandidateID == candidateDetails.CandidateID);
            if (candidate != null)
            {
                candidate.emailID = candidateDetails.emailID;
                candidate.FirstName = candidateDetails.FirstName;
                candidate.LastName = candidateDetails.LastName;
                candidate.password = candidateDetails.password;
            }
            else
            {
                Context.Candidates.Add(candidateDetails);
            }
        }

        /// <summary>
        /// Deletes the candidate.
        /// </summary>
        /// <param name="candidateID">The candidate identifier.</param>
        public void DeleteCandidate(int candidateID)
        {
            var candidate = Context.Candidates.FirstOrDefault(@this => @this.CandidateID == candidateID);
            if (candidate != null)
            {
                Context.Candidates.Remove(candidate);
            }
        }

        /// <summary>
        /// Gets all candidates.
        /// </summary>
        /// <returns>List of candidates</returns>
        public IList<Candidate> GetAllCandidates()
        {
            return Context.Candidates.ToList<Candidate>();
        }

        /// <summary>
        /// Gets the candidate details.
        /// </summary>
        /// <param name="candidateID">The candidate identifier.</param>
        /// <returns>Candidate details</returns>
        public IList<GetCandidate_Result> GetCandidate(int candidateID)
        {
                return Context.GetCandidate(candidateID).ToList<GetCandidate_Result>();
        }
    }
}
