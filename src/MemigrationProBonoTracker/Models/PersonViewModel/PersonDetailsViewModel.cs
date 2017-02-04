using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemigrationProBonoTracker.Models.CaseViewModels;

namespace MemigrationProBonoTracker.Models.PersonViewModel
{
    public class PersonDetailsViewModel
    {
        public Person Person { get; set; }
        public CaseListViewModel Cases { get; set; }

    }
}
