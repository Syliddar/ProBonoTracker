using System;
using System.ComponentModel.DataAnnotations;

namespace MemigrationProBonoTracker.Models.CaseViewModels
{
    public class CaseEventViewModel
    {
        public int CaseId { get; set; }
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }
        public int? VolunteerAttorneyId { get; set; }
        [Display(Name = "Event Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EventDate { get; set; }
        public string Event { get; set; }
    }
}