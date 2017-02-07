using System.Collections.Generic;
using MemigrationProBonoTracker.Models.CaseViewModels;

namespace MemigrationProBonoTracker.Models.AttorneyViewModels
{
    public class AttorneyDetailsViewModel
    {
        public Attorney Attorney { get; set; }
        public List<AttorneyCasesViewModel> CaseList { get; set; }
    }
}