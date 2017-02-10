using System;
using Microsoft.AspNetCore.Mvc;
using MemigrationProBonoTracker.Models;
using MemigrationProBonoTracker.Models.CaseViewModels;
using MemigrationProBonoTracker.Services;

namespace MemigrationProBonoTracker.Controllers
{
    public class CaseController : Controller
    {
        private readonly IContextService _context;

        public CaseController(IContextService contextService)
        {
            _context = contextService;
        }

        // GET: Cases
        public IActionResult Index(bool? open)
        {
            var model = _context.GetCaseListViewModel(open);
            return View(model);
        }

        // GET: Cases/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var @case = _context.GetCaseDetails(id.Value);
            if (@case == null)
            {
                return NotFound();
            }

            return View(@case);
        }

        // GET: Cases/Create
        public IActionResult Create()
        {
            var newCase = new CreateCaseViewModel
            {
                Active = true
            };
            return View();
        }

        // POST: Cases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCaseViewModel @case)
        {
            var caseId = _context.AddCase(@case);
            return RedirectToAction("Details", new {id = caseId });
        }

        // GET: Cases/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var @case = _context.GetCaseDetails(id.Value);
            if (@case == null)
            {
                return NotFound();
            }
            return View(@case);
        }

        // POST: Cases/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CaseDetailsViewModel @case)
        {
            if (ModelState.IsValid)
            {
                _context.UpdatePerson(@case.LeadClient);
                _context.UpdateCase(@case);
                return RedirectToAction("Details", new {id = @case.Id});
            }
            return View(@case);
        }

        // POST: Cases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _context.DeleteCase(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public void DeleteCaseEvent(int id)
        {
            _context.DeleteCaseEvent(id);
        }

        public IActionResult CloseCase(int caseId)
        {
            var model = _context.GetCaseDetails(caseId);
            return View("CloseCase", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CloseCase(CaseDetailsViewModel caseDetails)
        {
            if (ModelState.IsValid)
            {
                _context.UpdatePerson(caseDetails.LeadClient);
                _context.UpdateCase(caseDetails);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
        public PartialViewResult CreateCaseEventPartial(int parentId)
        {
            var model = new CaseEvent
            {
                EventDate = DateTime.Today,
                CaseId = parentId
            };
            return PartialView("_CreateEditCaseEvent", model);
        }
        public PartialViewResult EditCaseEventPartial(int eventId)
        {
            var model = _context.GetCaseEvent(eventId);
            return PartialView("_CreateEditCaseEvent", model);
        }

        [HttpPost]
        public PartialViewResult ModalCaseEventCreateSave(CaseEvent @caseEvent)
        {
            _context.UpsertCaseEvent(@caseEvent);
            var model = _context.GetCaseEventList(@caseEvent.CaseId);
            return PartialView("_CaseEventList", model);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public JsonResult RemoveAssociatedPerson(int id)
        //{
        //    var result = Json(1);


        //    return result;
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public JsonResult AddAssociatedPerson(int personId, int caseId)
        //{
        //    var result = Json(1);


        //    return result;
        //}
    }
}
