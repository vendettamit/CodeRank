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
    /// The repository to handle paper set and question related data access/update.
    /// </summary>
    public class PapersetManagerRepository : RepositoryBase, IPapersetManagerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PapersetManagerRepository"/> class.
        /// </summary>
        public PapersetManagerRepository()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PapersetManagerRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public PapersetManagerRepository(CodeRankEntities context)
            : base(context)
        {
        }

        /// <summary>
        /// Adds the question.
        /// </summary>
        /// <param name="questionDetails">The question details.</param>
        public void AddQuestion(Question questionDetails)
        {
            Context.Questions.Add(questionDetails);
        }

        /// <summary>
        /// Updates the question.
        /// </summary>
        /// <param name="questionDetails">The question details.</param>
        public void UpdateQuestion(Question questionDetails)
        {
            var question = Context.Questions.FirstOrDefault(@this => @this.QuestionID == questionDetails.QuestionID);
            if (question != null)
            {
                question.Description = questionDetails.Description;
                question.TestAssemblyName = questionDetails.TestAssemblyName;
                question.Title = questionDetails.Title;
                question.ComplexityLevel = questionDetails.ComplexityLevel;
            }
            else
            {
                Context.Questions.Add(questionDetails);
            }
        }

        /// <summary>
        /// Deletes the question.
        /// </summary>
        /// <param name="questionID">The question identifier.</param>
        public void DeleteQuestion(int questionID)
        {
            var question = Context.Questions.FirstOrDefault(@this => @this.QuestionID == questionID);
            if (question != null)
            {
                Context.Questions.Remove(question);
            }
        }

        /// <summary>
        /// Adds the paperset.
        /// </summary>
        /// <param name="paperSetDetails">The paper set details.</param>
        public void AddPaperset(PaperSet paperSetDetails)
        {
            Context.PaperSets.Add(paperSetDetails);
        }

        /// <summary>
        /// Updates the paperset.
        /// </summary>
        /// <param name="paperSetDetails">The paper set details.</param>
        public void UpdatePaperset(PaperSet paperSetDetails)
        {
            var paperSet = Context.PaperSets.FirstOrDefault(@this => @this.PaperSetID == paperSetDetails.PaperSetID);
            if (paperSet != null)
            {
                paperSet.Description = paperSetDetails.Description;
            }
            else
            {
                Context.PaperSets.Add(paperSetDetails);
            }
        }

        /// <summary>
        /// Deletes the paperset.
        /// </summary>
        /// <param name="papersetID">The paperset identifier.</param>
        public void DeletePaperset(int papersetID)
        {
            var paperset = Context.PaperSets.FirstOrDefault(@this => @this.PaperSetID == papersetID);
            if (paperset != null)
            {
                Context.PaperSets.Remove(paperset);
            }
        }

        /// <summary>
        /// Adds the paperset question.
        /// </summary>
        /// <param name="paperSetQuestionDetails">The paper set question details.</param>
        public void AddPapersetQuestion(PaperSetQuestion paperSetQuestionDetails)
        {
            Context.PaperSetQuestions.Add(paperSetQuestionDetails);
        }

        /// <summary>
        /// Adds the paperset question.
        /// </summary>
        /// <param name="paperSetQuestions">The paper set questions.</param>
        public void AddPapersetQuestion(IList<PaperSetQuestion> paperSetQuestions)
        {
            foreach (var question in paperSetQuestions)
            {
                Context.PaperSetQuestions.Add(question);
            }
        }

        /// <summary>
        /// Updates the paperset question.
        /// </summary>
        /// <param name="paperSetDetails">The paper set details.</param>
        public void UpdatePapersetQuestion(PaperSetQuestion paperSetDetails)
        {
            var paperSetQuestion = Context.PaperSetQuestions.FirstOrDefault(@this => @this.PaperSetQuestionID == paperSetDetails.PaperSetQuestionID);
            if (paperSetQuestion != null)
            {
                paperSetQuestion.MaximumMarks = paperSetDetails.MaximumMarks;
            }
            else
            {
                Context.PaperSetQuestions.Add(paperSetDetails);
            }
        }

        /// <summary>
        /// Deletes the paperset question.
        /// </summary>
        /// <param name="papersetQuestionID">The paperset question identifier.</param>
        public void DeletePapersetQuestion(int papersetQuestionID)
        {
            var papersetQuestion = Context.PaperSetQuestions.FirstOrDefault(@this => @this.PaperSetQuestionID == papersetQuestionID);
            if (papersetQuestion != null)
            {
                Context.PaperSetQuestions.Remove(papersetQuestion);
            }
        }

        /// <summary>
        /// Gets all questions.
        /// </summary>
        /// <returns>List of  questions</returns>
        public IList<Question> GetAllQuestions()
        {
            return Context.Questions.ToList<Question>();
        }

        /// <summary>
        /// Gets all paper sets.
        /// </summary>
        /// <returns>List of paper sets</returns>
        public IList<PaperSet> GetAllPaperSets()
        {
            return Context.PaperSets.ToList<PaperSet>();
        }

        /// <summary>
        /// Gets the questions in paper set.
        /// </summary>
        /// <param name="paperSetID">The paper set identifier.</param>
        /// <returns>List of questions in a paper set</returns>
        public IList<GetPaperSetQuestions_Result> GetQuestionsInPaperSet(int paperSetID)
        {
            return Context.GetPaperSetQuestions(paperSetID).ToList<GetPaperSetQuestions_Result>();
        }
    }
}