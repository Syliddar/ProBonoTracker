using System.Collections.Generic;

namespace MemigrationProBonoTracker.Models.AttorneyViewModels
{
    public class AttorneyListingViewModel
    {
        public List<AttorneyListItem> AttorneyList { get; set; }
        public string Title { get; set; }
    }

    public class AttorneyListItem
    {
        public int Id { get; set; }
        public int AssignedCases { get; set; }
        public string FullName { get; set; }
        public Enums.Gender Gender { get; set; }
        public string OrganizationName { get; set; }
        public bool InterestedVolunteer { get; set; }
        public bool DesiredVolunteer { get; set; }
        public bool SpeaksSpanish { get; set; }
        public bool HasProbateExperience { get; set; }
        public bool HasImmigrationExperience { get; set; }
        public bool HasJuvenileExperience { get; set; }
    }
}
