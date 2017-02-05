using System;
using System.Collections.Generic;
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
                if (model.AddressList == null)
                {
                    model.AddressList = new List<AttorneyAddress>();
                }
                if (model.PhoneList== null)
                {
                    model.PhoneList = new List<AttorneyPhoneNumber>();
                }
            }
            return View("CreateEdit", model);
        }

        public PartialViewResult CreatePartial()
        {
            var model = new Attorney
            {
                IsAssigningAttorney = false,
                RecruitmentDate = DateTime.Today
            };
            return PartialView("_AttorneyCreate", model);
        }

        public JsonResult ModalCreateSave(Attorney newAtty)
        {
            _context.AddAttorney(newAtty);
            var jsonResult = Json(newAtty);
            return new JsonResult(jsonResult);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Attorney attorney)
        {
            if (ModelState.IsValid)
            {
                var i = attorney.Id == 0 ? _context.AddAttorney(attorney) : _context.UpdateAttorney(attorney);
                return Details(attorney.Id);
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

        public PartialViewResult GetAttorneyContactInfoPartial(int id)
        {
            var model = _context.GetAttorneyContactInfo(id);
            return PartialView("_AttorneyContact", model);
        }
    }
}
