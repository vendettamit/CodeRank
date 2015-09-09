using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeRank.Database.DAL.Database;

namespace CodeRank.Database.DAL.Interfaces
{
    /// <summary>
    /// The repository interface which can handle paper set and question related data access/update.
    /// </summary>
    public interface IPapersetManagerRepository : IRepositoryBase
    {
        /// <summary>
        /// Adds the question.
        /// </summary>
        /// <param name="questionDetails">The question details.</param>
        void AddQuestion(Question questionDetails);

        /// <summary>
        /// Updates the question.
        /// </summary>
        /// <param name="questionDetails">The question details.</param>
        void UpdateQuestion(Question questionDetails);

        /// <summary>
        /// Deletes the question.
        /// </summary>
        /// <param name="questionID">The question identifier.</param>
        void DeleteQuestion(int questionID);

        /// <summary>
        /// Adds the paperset.
        /// </summary>
        /// <param name="paperSetDetails">The paper set details.</param>
        void AddPaperset(PaperSet paperSetDetails);

        /// <summary>
        /// Updates the paperset.
        /// </summary>
        /// <param name="paperSetDetails">The paper set details.</param>
        void UpdatePaperset(PaperSet paperSetDetails);

        /// <summary>
        /// Deletes the paperset.
        /// </summary>
        /// <param name="papersetID">The paperset identifier.</param>
        void DeletePaperset(int papersetID);

        /// <summary>
        /// Adds the paperset question.
        /// </summary>
        /// <param name="paperSetQuestionDetails">The paper set question details.</param>
        void AddPapersetQuestion(PaperSetQuestion paperSetQuestionDetails);

        /// <summary>
        /// Adds the paperset question.
        /// </summary>
        /// <param name="paperSetQuestions">The paper set questions.</param>
        void AddPapersetQuestion(IList<PaperSetQuestion> paperSetQuestions);

        /// <summary>
        /// Updates the paperset question.
        /// </summary>
        /// <param name="paperSetDetails">The paper set details.</param>
        void UpdatePapersetQuestion(PaperSetQuestion paperSetDetails);

        /// <summary>
        /// Deletes the paperset question.
        /// </summary>
        /// <param name="papersetQuestionID">The paperset question identifier.</param>
        void DeletePapersetQuestion(int papersetQuestionID);

        /// <summary>
        /// Gets all questions.
        /// </summary>
        /// <returns>All questions</returns>
        IList<Question> GetAllQuestions();

        /// <summary>
        /// Gets all paper sets.
        /// </summary>
        /// <returns>all paper sets</returns>
        IList<PaperSet> GetAllPaperSets();

        /// <summary>
        /// Gets the questions in paper set.
        /// </summary>
        /// <param name="paperSetID">The paper set identifier.</param>
        /// <returns>paper set</returns>
        IList<GetPaperSetQuestions_Result> GetQuestionsInPaperSet(int paperSetID);
    }
}
