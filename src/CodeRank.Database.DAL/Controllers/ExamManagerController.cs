using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeRank.Database.DAL.Database;
using CodeRank.Database.DAL.Interfaces;
using CodeRank.Database.DAL.Repositories;

namespace CodeRank.Database.DAL.Controllers
{
    /// <summary>
    /// Controller for Exam 
    /// </summary>
    public class ExamManagerController
    {
        /// <summary>
        /// The repository
        /// </summary>
        private IExamManagerRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExamManagerController" /> class.
        /// </summary>
        public ExamManagerController()
        {
            this.repository = new ExamManagerRepository();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExamManagerController"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public ExamManagerController(IExamManagerRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Adds the exam.
        /// </summary>
        /// <param name="examDetails">The exam details.</param>
        public void AddExam(Exam examDetails)
        {
            this.repository.AddExam(examDetails);
        }

        /// <summary>
        /// Updates the exam.
        /// </summary>
        /// <param name="examDetails">The exam details.</param>
        public void UpdateExam(Exam examDetails)
        {
            this.repository.UpdateExam(examDetails);
        }

        /// <summary>
        /// Deletes the exam.
        /// </summary>
        /// <param name="examID">The exam identifier.</param>
        public void DeleteExam(int examID)
        {
            this.repository.DeleteExam(examID);
        }

        /// <summary>
        /// Adds the exam result.
        /// </summary>
        /// <param name="examResultDetails">The exam result details.</param>
        public void AddExamResult(ExamResult examResultDetails)
        {
            this.repository.AddExamResult(examResultDetails);
        }

        /// <summary>
        /// Updates the exam result.
        /// </summary>
        /// <param name="examResultDetails">The exam result details.</param>
        public void UpdateExamResult(ExamResult examResultDetails)
        {
            this.repository.UpdateExamResult(examResultDetails);
        }

        /// <summary>
        /// Deletes the exam result.
        /// </summary>
        /// <param name="examID">The exam identifier.</param>
        /// <param name="paperSetQuestionID">The paper set question identifier.</param>
        public void DeleteExamResult(int examID, int paperSetQuestionID)
        {
            this.repository.DeleteExamResult(examID, paperSetQuestionID);
        }

        /// <summary>
        /// Gets the candidate exam result.
        /// </summary>
        /// <param name="candidateID">The candidate identifier.</param>
        /// <param name="examID">The exam identifier.</param>
        /// <returns>candidate exam result details</returns>
        public IList<GetCandidateExamResult_Result> GetCandidateExamResult(int candidateID, int examID)
        {
            return this.repository.GetCandidateExamResult(candidateID, examID);
        }

        /// <summary>
        /// Gets the candidate exams.
        /// </summary>
        /// <param name="candidateID">The candidate identifier.</param>
        /// <param name="examID">The exam identifier.</param>
        /// <returns>List of candidate's exams</returns>
        public IList<GetCandidateExams_Result> GetCandidateExams(int candidateID, int examID)
        {
            return this.repository.GetCandidateExams(candidateID, examID);
        }
    }
}
