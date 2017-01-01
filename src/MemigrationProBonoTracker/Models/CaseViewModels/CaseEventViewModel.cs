using System;
using System.ComponentModel.DataAnnotations;

namespace MemigrationProBonoTracker.Models.CaseViewModels
{
    public class CaseEventViewModel
    {
        public int CaseId { get; set; }
        [Display(Name = "Client Name")]
        public string ClientName { get; set; }
        public int AssignedAttorneyId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }
        public string Event { get; set; }
    }
}