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
using Microsoft.AspNetCore.Mvc.ViewFeatures;


namespace TestMVC.Controllers
{
    public class CasesController : Controller
    {
        private string loggedUser = "Ian Boggs";
        private readonly ProjectContext _context;


        public CasesController(ProjectContext context)
        {
            _context = context;
        }

        public IActionResult CaseSearch()
        {
            var searchParameters = new CaseSearchParameters();
            return View(searchParameters);
        }

        [HttpPost]
        public PartialViewResult CaseSearchResult(CaseSearchParameters searchParams)
        {
            var caseList = _context.Cases.Include(c => c.Client).AsNoTracking()
                    .Where(c => c.CaseReference.Contains(searchParams.SearchTerm)).ToList();
            return PartialView("_CaseSearchResult", caseList);
        }


        public IActionResult Index()
        {
            var allCases = _context.Cases.ToList();

            return View(allCases);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
