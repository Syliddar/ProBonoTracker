using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemigrationProBonoTracker.Models.CaseViewModels
{
    public class CaseLogListViewModel
    {
        public List<CaseLogEntry> LogList { get; set; }
        public int CaseId { get; set; }
    }
}
