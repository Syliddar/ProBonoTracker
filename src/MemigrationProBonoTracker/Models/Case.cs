using System.Collections.Generic;

namespace MemigrationProBonoTracker.Models
{
    public class Case
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public Person LeadClient { get; set; }
        public List<AssociatedPerson> AssociatedPeopleList { get; set; }
        public Attorney AssigningAttorney { get; set; }
        public Attorney AttorneyWorker { get; set; }
        public double AttorneyWorkedHours { get; set; }
        public Enums.CaseType Type { get; set; }
        public List<CaseEventDate> MajorDates { get; set; }
        public string CaseNotes { get; set; }
    }
}