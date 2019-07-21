using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MemigrationProBonoTracker.Models.PBTEnums;

namespace MemigrationProBonoTracker.Models
{
    public class Case
    {
        public int Id { get; set; }
        public bool Active { get; set; }

        [ForeignKey("LeadClient")]
        public int LeadClientId { get; set; }

        [ForeignKey("AssigningAttorney")]
        public int AssigningAttorneyId { get; set; }

        [ForeignKey("VolunteerAttorney")]
        public int? VolunteerAttorneyId { get; set; }


        [Display(Name = "Volunteer Hours Worked")]
        public double AttorneyWorkedHours { get; set; }

        [Display(Name = "Fees Paid")]
        [DataType(DataType.Currency)]
        public float FeesPaid { get; set; }

        [Display(Name = "Case Type")]
        public CaseType Type { get; set; }

        [Display(Name = "Consulting Status")]
        public ConsultingStatus ConsultStatus { get; set; }

        [Display(Name = "Case Notes")]
        public string CaseNotes { get; set; }
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }


        [Display(Name = "Lead Client")]
        public virtual Person LeadClient { get; set; }
        //public virtual List<AssociatedPerson> AssociatedPeopleList { get; set; }
        [Display(Name = "Case Events")]
        public virtual List<CaseEvent> CaseEvents { get; set; }
        public virtual Attorney AssigningAttorney { get; set; }
        [Display(Name = "Volunteer Attorney")]
        public virtual Attorney VolunteerAttorney { get; set; }
    }
}