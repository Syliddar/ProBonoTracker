using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MemigrationProBonoTracker.Data;
using MemigrationProBonoTracker.Models;
using MemigrationProBonoTracker.Services;

namespace MemigrationProBonoTracker.Controllers
{
    public class AttorneyController : Controller
    {
        private readonly IContextService _context;

        public AttorneyController(IContextService context)
        {
            _context = context;
        }

        public IActionResult Index(bool? assigning)
        {
            var model = _context.GetAttorneyListingViewModel(assigning);
            return View(model);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var attorney = _context.GetAttorneyDetails(id.Value);
            return View(attorney);
        }

        public IActionResult CreateEdit(int id = 0)
        {
            var model = new Attorney();
            if (id != 0)
            {
                model = _context.GetAttorneyDetails(id);
            }
            return View("CreateEdit", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Attorney attorney)
        {
            if (ModelState.IsValid)
            {
                var success = attorney.Id == 0 ? _context.AddAttorney(attorney) : _context.UpdateAttorney(attorney);
                if (success == 1)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "An internal error occurred. Please try again later.");
            }
            return View(attorney);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var success = _context.DeleteAttorney(id);
            if (success == 1)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "An internal error occurred. Please try again later.");
            return RedirectToAction("Index");
        }

        public PartialViewResult GetAttorneyLookupPartial(bool? assigning)
        {
            var model = _context.GetAttorneyListingViewModel(assigning);
            return PartialView("_AttorneySearch", model);
        }
    }
}
