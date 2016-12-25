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

        // GET: Attorneys
        public IActionResult Index(bool? assigning)
        {
            var model = _context.GetAttorneyListingViewModel(assigning);
            return View(model);
        }

        // GET: Attorneys/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var attorney = _context.GetAttorneyDetails(id.Value);
            return View(attorney);
        }

        // GET: Attorneys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Attorneys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Attorney attorney)
        {
            if (ModelState.IsValid)
            {
                var success = _context.AddAttorney(attorney);
                if (success == 1)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "An internal error occurred. Please try again later.");
            }
            return View(attorney);
        }

        // GET: Attorneys/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var attorney = _context.GetAttorneyDetails(id.Value);
            return View(attorney);
        }

        // POST: Attorneys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Attorney attorney)
        {
            if (id != attorney.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var success = _context.UpdateAttorney(attorney);
                    if (success == 1)
                    {
                        return RedirectToAction("Index");
                    }
                    ModelState.AddModelError(string.Empty, "An internal error occurred. Please try again later.");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "An internal error occurred. Please try again later.");
                }
                return RedirectToAction("Index");
            }
            return View(attorney);
        }
        // POST: Attorneys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var success = _context.DeleteAttorney(id);
            if (success == 1)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "An internal error occurred. Please try again later.");
            return RedirectToAction("Index");
        }
    }
}
