using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SystemOfTestKnowledge.Models;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace SystemOfTestKnowledge.Controllers
{
    public class HomeController : Controller
    {
        SystemContext _context;
        public HomeController(SystemContext context)
        {
            _context = context;
        }

        public IActionResult About()
        {
            ViewBag.Comments = _context.Comments.ToList();
            return View();
        }
        public IActionResult Index()
        {
            CultureInfo.CurrentCulture = new CultureInfo("en", false);
            CultureInfo.CurrentUICulture = new CultureInfo("en", false);
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en", false);
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en", false);
            return View();
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        [HttpGet]
        public IActionResult Reaction()
        {

            return View();
        }

        public IActionResult Privacy()
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
