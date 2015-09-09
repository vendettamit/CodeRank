using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeRank.Shared.Data;

namespace CodeRank.Web.UI.Controllers
{
    public class CodeRankController : Controller
    {
        //
        // GET: /CodeRank/

        public ActionResult Home()
        {
            return View();
        }

        /// <summary>
        /// Gets the question.
        /// </summary>
        /// <returns></returns>
        public ActionResult GetQuestion()
        {
            return Json(new Shared.Data.Question()
            {
                QuestionId = 1,
                Description = @"This is an introductory challenge. The purpose of this challenge is to give you a working I/O template in your preferred language. It includes scanning 2 integers from STDIN, calling a function, returning a value, and printing it to STDOUT.

Your task is to scan two numbers from STDIN, and print the sum A+B on STDOUT.

Note: The code has been saved in a template, which you can submit if you want"
            });
        }


        /// <summary>
        /// Submits the answer.
        /// </summary>
        /// <param name="solution">The solution.</param>
        public ActionResult SubmitAnswer(Solution solution)
        {
            return Json(true);
        }
    }
}
