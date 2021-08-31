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
using Microsoft.AspNetCore.Mvc.Rendering;


namespace TestMVC.Controllers
{
    public class CaseDetailController : Controller
    {

        private readonly ProjectContext _context;


        public CaseDetailController(ProjectContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            var caseToView = _context.Cases.FirstOrDefault(c => c.CaseId == id);

            return View(caseToView);
        }

        public IActionResult EditBasicCase(int id)
        {

            var editCase = _context.Cases.FirstOrDefault(c => c.CaseId == id);
            var list = (from s in _context.CaseStatusList
                        select new SelectListItem
                        {
                            Text = s.CaseStatusName,
                            Value = s.CaseStatusId.ToString(),
                            Selected = string.Equals(s.CaseStatusName, editCase.CurrentStatus.CaseStatusName, StringComparison.OrdinalIgnoreCase) ? true : false
                        }).ToList();


            return View(editCase);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBasicCase(int? id)
        {
            var targetCase = _context.Cases.FirstOrDefault(c => c.CaseId == id);
            if (await TryUpdateModelAsync<Case>(
                targetCase,
                "",
                c => c.ClientReference
            ))
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = id });
            }


            return View(targetCase);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
