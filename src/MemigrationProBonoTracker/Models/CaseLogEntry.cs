using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemigrationProBonoTracker.Models
{
    public class CaseLogEntry
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CaseId")]
        public int CaseId { get; set; }

        [DataType(DataType.Date)]       
        [Display(Name = "Entry Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EntryDate { get; set; }

        [Display(Name = "Log Entry")]
        public string EntryNotes { get; set; }

        public virtual Case Case { get; set; }
    }
}