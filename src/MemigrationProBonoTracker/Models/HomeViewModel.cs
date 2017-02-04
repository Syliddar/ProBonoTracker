using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemigrationProBonoTracker.Models.CaseViewModels;

namespace MemigrationProBonoTracker.Models
{
    public class HomeViewModel
    {
        public List<CaseEventViewModel> UpcomingCaseEvents { get; set; }
        public List<CaseListItem> OpenCases { get; set; }

        public List<CaseListItem> OldOpenCases
        {
            get
            {
                var compareDate = DateTime.Now.AddDays(-60);
                return OpenCases
                  .Where(x => x.CaseCreatedDate < compareDate && 
                  x.VolunteerAttorneyName == "Not yet assigned.")
                  .ToList();
            }
        }
    }
}
