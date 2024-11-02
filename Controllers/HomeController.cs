using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;
using System;

namespace QuizApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Quiz/Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Attribution()
        {
            return View();
        }
    }
}
