using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    public static partial class QuizOperations
    {
        public static QuizData GetData()
        {
            const string QuizDataFilePath = "./assets/data.json";

            //Can be any method of getting data
            FetchData fetchData = new FetchData();
            QuizData? dataFetch = fetchData.GetFromFileToJson(QuizDataFilePath);

            if (dataFetch == null) throw new InvalidDataException("Invalid data. Check data fetch from file.");

            //Can validate quiz data, is TODO

            QuizData Data = dataFetch;

            return Data;
        }

        public static QuizzesOverview GetData(ref List<Quiz> quizzes)
        {
            if (quizzes == null) { throw new ArgumentNullException(); }

            List<QuizOverview> quizzesOverviews = new List<QuizOverview>();

            //Find and return the quiz model
            foreach (Quiz quiz in quizzes)
            {
                QuizOverview qOverview = new QuizOverview(quiz);
                quizzesOverviews.Add(qOverview);
            }
            QuizzesOverview quizzesOverview = new QuizzesOverview(quizzesOverviews);

            return quizzesOverview;
        }

    }

    public class HomeController : Controller
    {
        // GET: Home/Index
        public ActionResult Index()
        {
            //Start by fetching asset data
            QuizData Data = QuizOperations.GetData();

            //Only the quiz overview information is needed, so refine it
            List<Quiz> quizData = Data.Quizzes;
            
            QuizzesOverview QuizzesOverviews = QuizOperations.GetData(ref quizData);
            
            //Quiz asset data is not needed, so dispose of it
            Data.Dispose();
            quizData.Clear();
            quizData.TrimExcess();

            return View(QuizzesOverviews);
        }

        public ActionResult Attribution()
        {
            return View();
        }

    }
}
