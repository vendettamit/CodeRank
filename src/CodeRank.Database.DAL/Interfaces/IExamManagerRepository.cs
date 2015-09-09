using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeRank.Database.DAL.Database;

namespace CodeRank.Database.DAL.Interfaces
{
    /// <summary>
    /// The repository interface which can handle exam related data access/update.
    /// </summary>
    public interface IExamManagerRepository
    {
        /// <summary>
        /// Adds the exam.
        /// </summary>
        /// <param name="examDetails">The exam details.</param>
          void AddExam(Exam examDetails);

        /// <summary>
        /// Updates the exam.
        /// </summary>
        /// <param name="examDetails">The exam details.</param>
          void UpdateExam(Exam examDetails);

        /// <summary>
        /// Deletes the exam.
        /// </summary>
        /// <param name="examID">The exam identifier.</param>
          void DeleteExam(int examID);

        /// <summary>
        /// Adds the exam result.
        /// </summary>
        /// <param name="examResultDetails">The exam result details.</param>
          void AddExamResult(ExamResult examResultDetails);

        /// <summary>
        /// Updates the exam result.
        /// </summary>
        /// <param name="examResultDetails">The exam result details.</param>
          void UpdateExamResult(ExamResult examResultDetails);

        /// <summary>
        /// Deletes the exam result.
        /// </summary>
        /// <param name="examID">The exam identifier.</param>
        /// <param name="paperSetQuestionID">The paper set question identifier.</param>
          void DeleteExamResult(int examID, int paperSetQuestionID);

          /// <summary>
          /// Gets the candidate exam result.
          /// </summary>
          /// <param name="candidateID">The candidate identifier.</param>
          /// <param name="examID">The exam identifier.</param>
          /// <returns>candidate exam result details</returns>
          IList<GetCandidateExamResult_Result> GetCandidateExamResult(int candidateID, int examID);

        /// <summary>
        /// Gets the candidate exams.
        /// </summary>
        /// <param name="candidateID">The candidate identifier.</param>
        /// <param name="examID">The exam identifier.</param>
        /// <returns>list of exam in which candidate appeared</returns>
        IList<GetCandidateExams_Result> GetCandidateExams(int candidateID, int examID);
    }
}