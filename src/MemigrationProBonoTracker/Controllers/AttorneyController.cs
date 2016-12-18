using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MemigrationProBonoTracker.Data;
using MemigrationProBonoTracker.Models;

namespace MemigrationProBonoTracker.Controllers
{
    public class AttorneyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttorneyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Attorneys
        public async Task<IActionResult> Index(bool? assigning)
        {
            return assigning.HasValue ? View(await _context.Attorneys.Where(x => x.IsAssigningAttorney == assigning.Value).ToListAsync()) : View(await _context.Attorneys.ToListAsync());
        }

        // GET: Attorneys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attorney = await _context.Attorneys.SingleOrDefaultAsync(m => m.Id == id);
            if (attorney == null)
            {
                return NotFound();
            }

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
        public async Task<IActionResult> Create([Bind("Id,AssignedCases,BarNumber,ClcContribution,DesiredVolunteer,FirstName,Gender,HasImmigrationExperience,HasJuvenileExperience,HasProbateExperience,InterestedVolunteer,IsAssigningAttorney,LastName,LatinoMemContribution,MiaContribution,Notes,OrganizationName,RecruitmentDate,RecruitmentMethod,SpeaksSpanish")] Attorney attorney)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attorney);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(attorney);
        }

        // GET: Attorneys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attorney = await _context.Attorneys.SingleOrDefaultAsync(m => m.Id == id);
            if (attorney == null)
            {
                return NotFound();
            }
            return View(attorney);
        }

        // POST: Attorneys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AssignedCases,BarNumber,ClcContribution,DesiredVolunteer,FirstName,Gender,HasImmigrationExperience,HasJuvenileExperience,HasProbateExperience,InterestedVolunteer,IsAssigningAttorney,LastName,LatinoMemContribution,MiaContribution,Notes,OrganizationName,RecruitmentDate,RecruitmentMethod,SpeaksSpanish")] Attorney attorney)
        {
            if (id != attorney.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attorney);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttorneyExists(attorney.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(attorney);
        }

        // GET: Attorneys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attorney = await _context.Attorneys.SingleOrDefaultAsync(m => m.Id == id);
            if (attorney == null)
            {
                return NotFound();
            }

            return View(attorney);
        }

        // POST: Attorneys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attorney = await _context.Attorneys.SingleOrDefaultAsync(m => m.Id == id);
            _context.Attorneys.Remove(attorney);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AttorneyExists(int id)
        {
            return _context.Attorneys.Any(e => e.Id == id);
        }
    }
}
