using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemigrationProBonoTracker.Models;
using MemigrationProBonoTracker.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MemigrationProBonoTracker.Controllers
{
    public class ContactLogController : Controller
    {
        private readonly IContextService _context;
        public ContactLogController(IContextService contextService)
        {
            _context = contextService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Index(int caseId)
        {
            var model = _context.GetCaseContactLogEntries(caseId);
            return View(model);
        }

        public IActionResult GetEntry(int logId)
        {
            var model = _context.GetLogEntry(logId);
            return View(model);
        }
        public IActionResult Create(int caseId)
        {
            var model = new ContactLogEntry
            {
                CaseId = caseId

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ContactLogEntry log)
        {
            if (ModelState.IsValid)
            {
                _context.AddLogEntry(log);
            }
            return Index(log.CaseId);
        }

        [HttpGet]
        public IActionResult Edit(int logId)
        {
            var model = _context.GetLogEntry(logId);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ContactLogEntry log)
        {
            if (ModelState.IsValid)
            {
                _context.UpdateLogEntry(log);
            }
            return Index(log.CaseId);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Delete(int logId)
        {
            _context.DeleteLogEntry(logId);
        }
    }
}
