using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemigrationProBonoTracker.Models.CaseViewModels;

namespace MemigrationProBonoTracker.Models
{
    public class HomeViewModel
    {
        public List<CaseEventViewModel> UpcomingCaseEvents { get; set; }

    }
}
