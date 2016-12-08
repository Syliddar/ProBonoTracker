using System;
using System.Collections.Generic;
using static ProBonoTracker.Models.Enums;

namespace ProBonoTracker.Models
{
    public class Attorney : Person
    {
        public string BarNumber { get; set; }
        public string OrganizationName { get; set; }
        public List<string> SpecialSkill { get; set; }
        public RecruitmentMethod RecruitmentMethod { get; set; }
        public DateTime RecruitmentDate { get; set; }
        public double ClcContribution { get; set; }
        public double LatinoMemContribution { get; set; }
        public double MiaContribution { get; set; }
        public bool IsAssigningAttorney { get; set; }
        public bool InterestedVolunteer { get; set; }
        public bool DesiredVolunteer { get; set; }

        public int AssignedCases()
        {
            //TODO: Call contextService, return number of cases that have this atty assigned
            return 1;
        }
    }
}