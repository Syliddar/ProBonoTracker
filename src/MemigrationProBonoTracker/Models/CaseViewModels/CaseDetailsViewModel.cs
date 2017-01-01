using System.Collections.Generic;

namespace MemigrationProBonoTracker.Models.CaseViewModels
{
    public class CaseDetailsViewModel
    {
        public Case Case { get; set; }
        public List<ContactLogEntry> ContactLogEntries { get; set; }
    }
}