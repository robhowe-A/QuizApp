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

            var NamesList = QuizOperations.GetQuizNames();
            //if query data isn't an exact name of a quiz, return to home
            var match = NamesList.Find(name => name.Equals(quiz));
            if (match == null) return Redirect("/");
            Quiz quizDataFind = QuizOperations.GetQuiz(match);
            QuizOverview QuizOverview = new QuizOverview(quizDataFind);

            return View(QuizOverview);
        }
    }
}
