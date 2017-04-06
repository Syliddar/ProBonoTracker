using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MemigrationProBonoTracker.Models;
using MemigrationProBonoTracker.Models.PersonViewModel;
using MemigrationProBonoTracker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features.Authentication;

namespace MemigrationProBonoTracker.Controllers
{
    [Authorize]
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
            var model = new PersonDetailsViewModel
            {
                Person = _context.GetPerson(id.Value),
                Cases = _context.GetCaseListViewModelForPerson(id.Value),
                //AssociatedPeople = _context.GetAssociatedPeopleViewModelForPerson(id.Value)

            };
            if (model.Person == null)
            {
                return NotFound();
            }

            return View("Details",model);
        }

        // GET: People/Edit/5
        public IActionResult CreateEdit(int? id)
        {
            if (id == null)
            {
                var model = new Person();
                return View("CreateEdit", model);
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
                if (person.Id == 0)
                {
                    _context.AddPerson(person);

                }
                else
                {
                    _context.UpdatePerson(person);
                }
                return RedirectToAction("Details","People",new {id = person.Id});
            }
            else
            {
                return View("CreateEdit", person);
            }
        }


        // POST: People/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            try
            {
                _context.DeletePerson(id);
                return Json(new { success = true, responseText = "Your message successfuly sent!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message });
            }
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

        //public PartialViewResult AssociatedPersonLookupPartial()
        //{
        //    var model = _context.GetPeopleList();
        //    return PartialView("_AssPersonSearch", model);
        //}

        //public void RemovePersonAssociation(int caseId, int personId)
        //{

        //}
    }
}
