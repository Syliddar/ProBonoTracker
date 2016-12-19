using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemigrationProBonoTracker.Data;
using MemigrationProBonoTracker.Models;
using MemigrationProBonoTracker.Models.CaseViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Data.Entity;

namespace MemigrationProBonoTracker.Services
{
    public class ContextService : IContextService
    {
        private readonly ApplicationDbContext _context;

        public ContextService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CaseListViewModel> GetCaseListViewModel(bool? openCases)
        {
            var model = new CaseListViewModel();
            if (openCases.HasValue)
            {
                model.Title = openCases.Value ? "Active Cases" : "Closed Cases";
                model.Cases = await _context.Cases.Where(c => c.Active == openCases.Value)
                    .Include(c => c.LeadClient)
                    .Include(c => c.AssigningAttorney)
                    .Include(c => c.AttorneyWorker)
                    .Include(c => c.MajorDates)
                    .ToListAsync();
            }
            else
            {
                model.Title = "All Cases";
                model.Cases = await _context.Cases.ToListAsync();
            }

            return model;
        }

        public Task<Case> GetCaseDetails(int id)
        {
            return _context.Cases.SingleOrDefaultAsync(c => c.Id == id);
        }

        public void AddCase(Case @case)
        {
            _context.Add(@case);
            _context.SaveChangesAsync();
        }

        public void UpdateCase(Case @case)
        {
            _context.Update(@case);
            _context.SaveChangesAsync();
        }

        public void DeleteCase(int id)
        {
            var @case = _context.Cases.First(c => c.Id == id);
            _context.Cases.Remove(@case);
            _context.SaveChangesAsync();
        }
    }
}
