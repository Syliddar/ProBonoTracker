using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemigrationProBonoTracker.Models
{
    public class ContactLogEntry
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CaseId")]
        public int CaseId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Entry Date")]
        public DateTime EntryDate { get; set; }

        [Display(Name = "Entry Notes")]
        public string EntryNotes { get; set; }

        public virtual Case Case { get; set; }
    }
}