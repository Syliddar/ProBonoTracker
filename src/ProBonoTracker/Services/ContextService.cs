using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProBonoTracker.Data;
using ProBonoTracker.Models;
using ProBonoTracker.Services.Interfaces;

namespace ProBonoTracker.Services
{
    public class ContextService : IContextService
    {
        private ApplicationDbContext _db;
        public ContextService(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        //Data Accessors
        public int GetNumberOfAssignedCases(int attorneyId)
        {
            return _db.Cases.Count(x => x.AttorneyWorker.Id == attorneyId);
        }

        public List<Case> GetCasesWithEventsThisWeek()
        {
            return _db.Cases.Where(x => x.MajorDates.Any(y => y.EventDate < DateTime.Today.AddDays(7))).Include(x => x.MajorDates).ToList();
        }
    }
}
