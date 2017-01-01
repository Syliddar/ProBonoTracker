using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MemigrationProBonoTracker.Models
{
    public class Case
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        [Display(Name = "Lead Client")]
        public Person LeadClient { get; set; }
        public List<AssociatedPerson> AssociatedPeopleList { get; set; }
        [Display(Name = "Assigning Attorney")]
        public Attorney AssigningAttorney { get; set; }
        [Display(Name = "Volunteer Attorney")]
        public Attorney VolunteerAttorney { get; set; }
        [Display(Name = "Volunteer Hours Worked")]
        public double AttorneyWorkedHours { get; set; }
        [Display(Name = "Case Type")]
        public Enums.CaseType Type { get; set; }
        [Display(Name = "Case Events")]
        public List<CaseEvent> CaseEvents { get; set; }
        [Display(Name = "Case Notes")]
        public string CaseNotes { get; set; }
    }
}