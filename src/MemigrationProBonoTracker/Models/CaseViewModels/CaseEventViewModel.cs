using System;
using System.ComponentModel.DataAnnotations;

namespace MemigrationProBonoTracker.Models.CaseViewModels
{
    public class CaseEventViewModel
    {
        public int CaseId { get; set; }
        public string ClientName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EventDate { get; set; }
        public string Event { get; set; }
    }
}