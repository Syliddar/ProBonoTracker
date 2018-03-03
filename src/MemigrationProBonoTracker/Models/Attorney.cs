using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MemigrationProBonoTracker.Models.Enums;

namespace MemigrationProBonoTracker.Models
{
    public class Attorney
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }

        [Display(Name = "Address")]
        //TFW TPC Inheritance isn't supported yet
        public AttorneyAddress Address { get; set; }

        [Display(Name = "Phone Number")]
        public AttorneyPhoneNumber Phone { get; set; }
        public Email Email { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Display(Name = "Bar Number")]
        public string BarNumber { get; set; }

        [Display(Name = "Organization")]
        public string OrganizationName { get; set; }

        [Display(Name = "Recruitment Method")]
        public RecruitmentMethod RecruitmentMethod { get; set; }

        [Display(Name = "Recruitment Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime RecruitmentDate { get; set; }

        [Display(Name = "CLC Memphis Contributions")]
        public double ClcContribution { get; set; }

        [Display(Name = "Latino Memphis Contributions")]
        public double LatinoMemContribution { get; set; }

        [Display(Name = "MIA Contributions")]
        public double MiaContribution { get; set; }

        [Display(Name = "Is Assigning attorney")]
        public bool IsAssigningAttorney { get; set; }

        [Display(Name = "Interested Volunteer")]
        public bool InterestedVolunteer { get; set; }

        [Display(Name = "Desired Volunteer")]
        public bool DesiredVolunteer { get; set; }

        [Display(Name = "Speaks Spanish")]
        public bool SpeaksSpanish { get; set; }

        [Display(Name = "Has Probate Court Experience")]
        public bool HasProbateExperience { get; set; }

        [Display(Name = "Has Immigration Experience")]
        public bool HasImmigrationExperience { get; set; }

        [Display(Name = "Has Juvenile Experience")]
        public bool HasJuvenileExperience { get; set; }

        [Display(Name = "Assigned Cases")]
        [NotMapped]
        public int AssignedCases { get; set; }
    }
}