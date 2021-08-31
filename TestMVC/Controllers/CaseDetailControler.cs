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
            var editCase = _context.Cases
                    .Include(c => c.Client).AsNoTracking().FirstOrDefault(c => c.CaseId == id);

            ViewBag.CurrentStatusId = new SelectList(_context.CaseStatusList.AsNoTracking().ToList(), "CaseStatusId", "CaseStatusName");
            ViewBag.CaseHandlerId = new SelectList(_context.Users.AsNoTracking().ToList(), "UserEntityId", "FullName");
            return View(editCase);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBasicCase(int? id)
        {
            var targetCase = await _context.Cases.FirstOrDefaultAsync(c => c.CaseId == id);

            if (ModelState.IsValid)
            {


                if (await TryUpdateModelAsync<Case>(
                    targetCase,
                    "",
                    c => c.ClientReference, c => c.CurrentStatusId, c => c.CaseHandlerId
                ))
                {
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateException /* ex */)
                    {
                        //Log the error (uncomment ex variable name and write a log.)
                        ModelState.AddModelError("", "Unable to save changes. " +
                            "Try again, and if the problem persists, " +
                            "see your system administrator.");
                    }
                    return RedirectToAction(nameof(Index), new { id = id });
                }
            }

            ViewBag.CaseStatusId = new SelectList(_context.CaseStatusList.AsNoTracking().ToList(), "CaseStatusId", "CaseStatusName");
            ViewBag.CaseHandlerId = new SelectList(_context.Users.AsNoTracking().ToList(), "UserEntityId", "FullName");

            var myCase = _context.Cases
                    .Include(c => c.Client).AsNoTracking().FirstOrDefault(c => c.CaseId == id);

            return View(myCase);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
