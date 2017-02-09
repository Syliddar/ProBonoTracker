using System.Collections.Generic;
using MemigrationProBonoTracker.Models.CaseViewModels;

namespace MemigrationProBonoTracker.Models.PersonViewModel
{
    public class PersonDetailsViewModel
    {
        public Person Person { get; set; }
        public CaseListViewModel Cases { get; set; }
        //public List<AssociatedPersonViewModel> AssociatedPeople { get; set; }
    }
}
