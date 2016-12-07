using System.Collections.Generic;

namespace ProBonoTracker.Models
{
    public class Volunteer : Person
    {
        public string BarNumber { get; set; }
        public string OrganizationName { get; set; }
        public List<string> SpecialSkill { get; set; }
        public string RecruitmentMethod { get; set; }
        public Dictionary<string, double> FinancialContributions { get; set; }
        
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