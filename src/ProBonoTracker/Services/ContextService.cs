using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProBonoTracker.Data;
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
        public int GetNumberOfAssignedCases(int attorneyId)
        {
            return 1;
        }
    }
}
