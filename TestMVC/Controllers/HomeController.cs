using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestMVC.Models;
using CommonObjectLibraryCore;

namespace TestMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProjectContext _context;


        public HomeController(ProjectContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var test = _context.Cases.Count();
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
