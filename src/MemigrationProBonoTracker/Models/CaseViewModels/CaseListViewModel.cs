using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemigrationProBonoTracker.Models.CaseViewModels
{
    public class CaseListViewModel
    {
        public string Title { get; set; }
        public List<Case> Cases { get; set; }
    }
}
