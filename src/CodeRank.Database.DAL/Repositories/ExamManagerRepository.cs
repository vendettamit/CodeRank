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
    /// The repository to handle exam related data access/update.
    /// </summary>
    public class ExamManagerRepository : RepositoryBase, IExamManagerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExamManagerRepository"/> class.
        /// </summary>
        public ExamManagerRepository()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExamManagerRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ExamManagerRepository(CodeRankEntities context)
            : base(context)
        {
        }

        /// <summary>
        /// Adds the exam.
        /// </summary>
        /// <param name="examDetails">The exam details.</param>
        public void AddExam(Exam examDetails)
        {
            Context.Exams.Add(examDetails);
        }

        /// <summary>
        /// Updates the exam.
        /// </summary>
        /// <param name="examDetails">The exam details.</param>
        public void UpdateExam(Exam examDetails)
        {
            var exam = Context.Exams.FirstOrDefault(@this => @this.ExamID == examDetails.ExamID);
            if (exam != null)
            {
                exam.CandidateID = examDetails.CandidateID;
                exam.PaperSetID = examDetails.PaperSetID;
            }
            else
            {
                Context.Exams.Add(examDetails);
            }
        }

        /// <summary>
        /// Deletes the exam.
        /// </summary>
        /// <param name="examID">The exam identifier.</param>
        public void DeleteExam(int examID)
        {
            var exam = Context.Exams.FirstOrDefault(@this => @this.ExamID == examID);
            if (exam != null)
            {
                Context.Exams.Remove(exam);
            }
        }

        /// <summary>
        /// Adds the exam result.
        /// </summary>
        /// <param name="examResultDetails">The exam result details.</param>
        public void AddExamResult(ExamResult examResultDetails)
        {
            Context.ExamResults.Add(examResultDetails);
        }

        /// <summary>
        /// Updates the exam result.
        /// </summary>
        /// <param name="examResultDetails">The exam result details.</param>
        public void UpdateExamResult(ExamResult examResultDetails)
        {
            var examResult = Context.ExamResults.FirstOrDefault(@this => @this.ExamID == examResultDetails.ExamID &&
                                                                   @this.PaperSetQuestionID == examResultDetails.PaperSetQuestionID);
            if (examResult != null)
            {
                examResult.Score = examResultDetails.Score;
            }
            else
            {
                Context.ExamResults.Add(examResultDetails);
            }
        }

        /// <summary>
        /// Deletes the exam result.
        /// </summary>
        /// <param name="examID">The exam identifier.</param>
        /// <param name="paperSetQuestionID">The paper set question identifier.</param>
        public void DeleteExamResult(int examID, int paperSetQuestionID)
        {
            var examResult = Context.ExamResults.FirstOrDefault(@this => @this.ExamID == examID &&
                                                             @this.PaperSetQuestionID == paperSetQuestionID);
            if (examResult != null)
            {
                Context.ExamResults.Remove(examResult);
            }
        }

        /// <summary>
        /// Gets the candidate exam result.
        /// </summary>
        /// <param name="candidateID">The candidate identifier.</param>
        /// <param name="examID">The exam identifier.</param>
        /// <returns>candidate exam result details</returns>
        public IList<GetCandidateExamResult_Result> GetCandidateExamResult(int candidateID, int examID)
        {
            return Context.GetCandidateExamResult(candidateID, examID).ToList<GetCandidateExamResult_Result>();
        }

        /// <summary>
        /// Gets the candidate exams.
        /// </summary>
        /// <param name="candidateID">The candidate identifier.</param>
        /// <param name="examID">The exam identifier.</param>
        /// <returns>List of candidate's exams</returns>
        public IList<GetCandidateExams_Result> GetCandidateExams(int candidateID, int examID)
        {
            return Context.GetCandidateExams(candidateID).ToList<GetCandidateExams_Result>();
        }
    }
}