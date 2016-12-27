using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemigrationProBonoTracker.Models.CaseViewModels
{
    public class CreateCaseViewModel
    {
        public int Id { get; set; }
        public Person LeadClient { get; set; }
        public List<AssociatedPerson> AssociatedPeopleList { get; set; }
        public int AssigningAttorneyId { get; set; }
        public int AttorneyWorkerId { get; set; }
        public Enums.CaseType Type { get; set; }
        public List<CaseEventDate> CaseEventDates { get; set; }
        public string CaseNotes { get; set; }
    }
}
