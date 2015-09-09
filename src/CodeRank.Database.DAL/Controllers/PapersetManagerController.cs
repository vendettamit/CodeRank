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
    /// Controller for PapersetManager
    /// </summary>
    public class PapersetManagerController
    {
        /// <summary>
        /// The repository
        /// </summary>
        private IPapersetManagerRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PapersetManagerController" /> class.
        /// </summary>
        public PapersetManagerController()
        {
            this.repository = new PapersetManagerRepository();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PapersetManagerController"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public PapersetManagerController(IPapersetManagerRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Adds the question.
        /// </summary>
        /// <param name="questionDetails">The question details.</param>
        public void AddQuestion(Question questionDetails)
        {
            this.repository.AddQuestion(questionDetails);
        }

        /// <summary>
        /// Updates the question.
        /// </summary>
        /// <param name="questionDetails">The question details.</param>
        public void UpdateQuestion(Question questionDetails)
        {
            this.repository.UpdateQuestion(questionDetails);
        }

        /// <summary>
        /// Deletes the question.
        /// </summary>
        /// <param name="questionID">The question identifier.</param>
        public void DeleteQuestion(int questionID)
        {
            this.repository.DeleteQuestion(questionID);
        }

        /// <summary>
        /// Adds the paperset.
        /// </summary>
        /// <param name="paperSetDetails">The paper set details.</param>
        public void AddPaperset(PaperSet paperSetDetails)
        {
            this.repository.AddPaperset(paperSetDetails);
        }

        /// <summary>
        /// Updates the paperset.
        /// </summary>
        /// <param name="paperSetDetails">The paper set details.</param>
        public void UpdatePaperset(PaperSet paperSetDetails)
        {
            this.repository.UpdatePaperset(paperSetDetails);
        }

        /// <summary>
        /// Deletes the paperset.
        /// </summary>
        /// <param name="papersetID">The paperset identifier.</param>
        public void DeletePaperset(int papersetID)
        {
            this.repository.DeletePaperset(papersetID);
        }

        /// <summary>
        /// Adds the paperset question.
        /// </summary>
        /// <param name="paperSetQuestionDetails">The paper set question details.</param>
        public void AddPapersetQuestion(PaperSetQuestion paperSetQuestionDetails)
        {
            this.repository.AddPapersetQuestion(paperSetQuestionDetails);
        }

        /// <summary>
        /// Adds the paperset question.
        /// </summary>
        /// <param name="paperSetQuestions">The paper set questions.</param>
        public void AddPapersetQuestion(IList<PaperSetQuestion> paperSetQuestions)
        {
            this.repository.AddPapersetQuestion(paperSetQuestions);
        }

        /// <summary>
        /// Updates the paperset question.
        /// </summary>
        /// <param name="paperSetDetails">The paper set details.</param>
        public void UpdatePapersetQuestion(PaperSetQuestion paperSetDetails)
        {
            this.repository.UpdatePapersetQuestion(paperSetDetails);
        }

        /// <summary>
        /// Deletes the paperset question.
        /// </summary>
        /// <param name="papersetQuestionID">The paperset question identifier.</param>
        public void DeletePapersetQuestion(int papersetQuestionID)
        {
            this.repository.DeletePapersetQuestion(papersetQuestionID);
        }

        /// <summary>
        /// Gets all questions.
        /// </summary>
        /// <returns>List of  questions</returns>
        public IList<Question> GetAllQuestions()
        {
            return this.repository.GetAllQuestions();
        }

        /// <summary>
        /// Gets all paper sets.
        /// </summary>
        /// <returns>List of paper sets</returns>
        public IList<PaperSet> GetAllPaperSets()
        {
            return this.repository.GetAllPaperSets();
        }

        /// <summary>
        /// Gets the questions in paper set.
        /// </summary>
        /// <param name="paperSetID">The paper set identifier.</param>
        /// <returns>List of questions in a paper set</returns>
        public IList<GetPaperSetQuestions_Result> GetQuestionsInPaperSet(int paperSetID)
        {
            return this.repository.GetQuestionsInPaperSet(paperSetID);
        }
    }
}
