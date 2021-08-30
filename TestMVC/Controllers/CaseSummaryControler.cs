using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestMVC.Models;
using CommonObjectLibraryCore;
using Microsoft.EntityFrameworkCore;

namespace TestMVC.Controllers
{
    public class CaseSummaryController : Controller
    {

        private readonly ProjectContext _context;


        public CaseSummaryController(ProjectContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            var caseToView = _context.Cases.FirstOrDefault(c => c.CaseId == id);

            return View(caseToView);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
