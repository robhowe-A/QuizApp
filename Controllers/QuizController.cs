using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;
using System.Numerics;

namespace QuizApp.Controllers
{
    public class QuizController : Controller
    {
        // GET: Quiz/Menu
        public ActionResult Index()
        {
            return Redirect("/");
        }

        // GET: Quiz/Questions
        public ActionResult Questions(string quiz)
        {
            if (string.IsNullOrEmpty(quiz)) return Redirect("/");
            
            //get the quizzes names from the data
            var NamesList = QuizOperations.GetQuizNames();

            //if query data isn't an exact name of a quiz, return to home
            var match = NamesList.Find(name => name.Equals(quiz));
            if (match == null) return Redirect("/");

            //Get overview of the quiz data
            Quiz quizDataFind = QuizOperations.GetQuiz(match);
            QuizOverview QuizOverview = new QuizOverview(quizDataFind);

            //Here, only the title and icon data is needed, so dispose the quiz
            //to remove unneeded question+answer data from existing in the page model
            quizDataFind.Dispose();

            return View(QuizOverview);
        }
    }
}
