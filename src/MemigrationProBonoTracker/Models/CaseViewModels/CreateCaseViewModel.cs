using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static MemigrationProBonoTracker.Models.PBTEnums;

namespace MemigrationProBonoTracker.Models.CaseViewModels
{
    public class CreateCaseViewModel
    {
        public int Id { get; set; }
        public Person LeadClient { get; set; }
        public bool Active { get; set; }
        //public List<AssociatedPerson> AssociatedPeopleList { get; set; }
        [Display(Name = "Assigning Attorney")]
        public Attorney AssigningAttorney { get; set; }
        [Display(Name = "Volunteer Attorney")]
        public Attorney VolunteerAttorney { get; set; }

        [Required(ErrorMessage = "Assigning Attorney is Required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Assigning Attorney is Required.")]
        public int AssigningAttorneyId { get; set; }
        public int VolunteerAttorneyId { get; set; }


        [Display(Name = "Case Type")]
        public CaseType Type { get; set; }
        [Display(Name = "Case Events")]
        public List<CaseEvent> CaseEvents { get; set; }
        [Display(Name = "Volunteer Hours Worked")]
        public double AttorneyWorkedHours { get; set; }
        [Display(Name = "Case Notes")]
        public string CaseNotes { get; set; }
    }
}
