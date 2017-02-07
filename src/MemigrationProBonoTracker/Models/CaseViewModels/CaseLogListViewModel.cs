using System.Collections.Generic;

namespace MemigrationProBonoTracker.Models.CaseViewModels
{
    public class CaseLogListViewModel
    {
        public List<CaseLogEntry> LogList { get; set; }
        public int CaseId { get; set; }
    }
}
