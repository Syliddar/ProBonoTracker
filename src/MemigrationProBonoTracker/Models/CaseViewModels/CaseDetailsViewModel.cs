using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MemigrationProBonoTracker.Models.PersonViewModel;

namespace MemigrationProBonoTracker.Models.CaseViewModels
{
    public class CaseDetailsViewModel
    {
        public int Id { get; set; }
        public Person LeadClient { get; set; }
        public bool Active { get; set; }
        //public List<AssociatedPersonViewModel> AssociatedPeopleList { get; set; }

        public int VolunteerAttorneyId { get; set; }
        [Display(Name = "Volunteer Attorney Name")]
        public string VolunteerAttorneyFullName { get; set; }
        [Display(Name = "Volunteer Attorney Organization")]
        public string VolunteerAttorneyOrganizationName { get; set; }

        public int AssigningAttorneyId { get; set; }

        [Display(Name = "Assigning Attorney Name")]
        public string AssigningAttorneyFullName { get; set; }

        [Display(Name = "Assigning Attorney Organization")]
        public string AssigningAttorneyOrganizationName { get; set; }

        [Display(Name = "Case Type")]
        public Enums.CaseType Type { get; set; }
        [Display(Name = "Case Events")]
        public List<CaseEvent> CaseEvents { get; set; }
        [Display(Name = "Volunteer Hours Worked")]
        public double AttorneyWorkedHours { get; set; }
        [Display(Name = "Case Notes")]
        public string CaseNotes { get; set; }
        public List<CaseLogEntry> CaseLogEntries { get; set; }
        [Display(Name="Total Fees Paid")]
        public double FeesPaid { get; set; }

        [Display(Name = "Is Idiot")]
        public bool DesiredVolunteer{ get; set; }
        [Display(Name = "Interested in Volunteering Again")]
        public bool InterestedVolunteer{ get; set; }
    }
}