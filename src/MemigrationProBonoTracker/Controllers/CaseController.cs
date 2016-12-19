using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MemigrationProBonoTracker.Models;
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
        public async Task<IActionResult> Index(bool? open)
        {
            var model = await _context.GetCaseListViewModel(open);
            return View(model);
        }

        // GET: Cases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var @case = await _context.GetCaseDetails(id.Value);
            if (@case == null)
            {
                return NotFound();
            }

            return View(@case);
        }

        // GET: Cases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Case @case)
        {
            if (ModelState.IsValid)
            {
                _context.AddCase(@case);
                return RedirectToAction("Index");
            }
            return View(@case);
        }

        // GET: Cases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var @case = await _context.GetCaseDetails(id.Value);
            if (@case == null)
            {
                return NotFound();
            }
            return View(@case);
        }

        // POST: Cases/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Case @case)
        {
            if (ModelState.IsValid)
            {
                _context.UpdateCase(@case);
                return RedirectToAction("Index");
            }
            return View(@case);

        }

        // POST: Cases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _context.DeleteCase(id);

            return RedirectToAction("Index");
        }


    }
}
