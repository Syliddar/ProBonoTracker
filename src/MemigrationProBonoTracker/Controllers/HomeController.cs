using MemigrationProBonoTracker.Models;
using MemigrationProBonoTracker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MemigrationProBonoTracker.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IContextService _context;
        public HomeController(IContextService context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                OpenCases = _context.GetOpenCasesWithoutVolunteerAttorneys(),
                UpcomingCaseEvents = _context.GetUpcomingCaseEvents()
            };
            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
