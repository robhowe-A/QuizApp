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
            QuizzesOverview QuizzesOverviews = QuizOperations.GetData(Data.Quizzes);

            //Quiz asset data is not needed any longer, so dispose of it
            Data.Dispose();

            return View(QuizzesOverviews);
        }

        public ActionResult Attribution()
        {
            return View();
        }
    }
}
