using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;
using System;

namespace QuizApp.Controllers
{
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
