using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MemigrationProBonoTracker.Data;
using MemigrationProBonoTracker.Models;
using MemigrationProBonoTracker.Services;

namespace MemigrationProBonoTracker.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IContextService _context;

        public PeopleController(IContextService contextService)
        {
            _context = contextService;
        }

        // GET: People
        public IActionResult Index()
        {
            return View(_context.GetPeopleList());
        }

        // GET: People/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = _context.GetPerson(id.Value);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.AddPerson(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = _context.GetPerson(id.Value);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.UpdatePerson(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = _context.GetPerson(id.Value);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _context.DeletePerson(id);
            return RedirectToAction("Index");
        }

        public PartialViewResult PersonContactPartial(int id)
        {
            var model = _context.GetPersonContactInfo(id);
            return PartialView("_PersonContact", model);
        }

        public PartialViewResult PersonLookupPartial()
        {
            var model = _context.GetPeopleList();
            return PartialView("_PersonSearch", model);
        }
    }
}
