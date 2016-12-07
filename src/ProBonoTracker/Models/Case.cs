using System;
using System.Collections.Generic;
using static ProBonoTracker.Models.Enums;

namespace ProBonoTracker.Models
{
    public class Case
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public Person LeadClient { get; set; }
        public List<AssociatedPerson> AssociatedPeopleList { get; set; }

        public Volunteer AssigningVolunteer { get; set; }
        public Volunteer VolunteerWorker { get; set; }
        public double VolunteerWorkHours { get; set; }
        public CaseType Type { get; set; }
        public Dictionary<DateTime, string> MajorDates { get; set; }
        public List<ContactLogEntry> ContactLogEntries { get; set; }
        public string CaseNotes { get; set; }
    }
}