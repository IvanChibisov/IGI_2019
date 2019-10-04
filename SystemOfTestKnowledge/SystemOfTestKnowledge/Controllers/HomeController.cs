using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SystemOfTestKnowledge.Models;

namespace SystemOfTestKnowledge.Controllers
{
    public class HomeController : Controller
    {
        SystemContext db;
        public HomeController(SystemContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Questions.ToList());
        }

        [HttpGet]
        public IActionResult Reaction()
        {

            return View();
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
