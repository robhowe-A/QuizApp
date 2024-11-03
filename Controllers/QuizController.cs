using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    public static partial class QuizOperations
    {
        public static List<string> GetQuizNames()
        {
            List<string> Names = new List<string>();

            QuizData Data = GetData();
            foreach (var name in Data.Quizzes)
            {
                Names.Add(name.Title);
            }
            Data.Dispose();

            return Names;
        }

        public static Quiz GetQuiz(string match)
        {
            if (match == null) { throw new ArgumentNullException(); }
            //Find and return the quiz model
            QuizData Data = QuizOperations.GetData();
            var QuizChoice = Data.Quizzes.Find(name => name.Title.Equals(match));
            Data.Dispose();

            return QuizChoice;
        }

        public static QuizOverview GetQuiz(ref Quiz quiz)
        {
            if (quiz == null) { throw new ArgumentNullException(); }

            //Find and return the quiz model
            QuizData Data = QuizOperations.GetData();

            //Match the quiz by title
            string quizTitle = quiz.Title;
            var QuizChoice = Data.Quizzes.Find(qiz => qiz.Title.Equals(quizTitle));
            Data.Dispose();

            QuizOverview qOverview = new QuizOverview(QuizChoice);
            return qOverview;
        }

    }

    public class QuizController : Controller
    {
        // GET: Quiz/
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
