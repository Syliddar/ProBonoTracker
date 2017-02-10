using System;
using MemigrationProBonoTracker.Models;
using MemigrationProBonoTracker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MemigrationProBonoTracker.Controllers
{
    [Authorize]
    public class CaseLogController : Controller
    {
        private readonly IContextService _context;
        public CaseLogController(IContextService contextService)
        {
            _context = contextService;
        }

        public IActionResult Index(int caseId)
        {
            var model = _context.GetCaseLogEntries(caseId);
            return View(model);
        }

        public IActionResult GetEntry(int logId)
        {
            var model = _context.GetLogEntry(logId);
            return View(model);
        }
        public PartialViewResult Create(int caseId)
        {
            var model = new CaseLogEntry
            {
                CaseId = caseId,
                EntryDate = DateTime.Today

            };
            return PartialView("_CaseLog", model);
        }

        [HttpGet]
        public PartialViewResult Edit(int logId)
        {
            var model = _context.GetLogEntry(logId);
            return PartialView("_CaseLog", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Save(CaseLogEntry log)
        {
            if (ModelState.IsValid)
            {
                if (log.Id == 0)
                {
                    _context.AddLogEntry(log);
                }
                else
                {
                    _context.UpdateLogEntry(log);
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Delete(int logId)
        {
            _context.DeleteLogEntry(logId);
        }
    }
}
