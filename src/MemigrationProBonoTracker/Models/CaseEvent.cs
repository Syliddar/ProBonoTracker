using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemigrationProBonoTracker.Models
{
    public class CaseEvent
    {
        public int Id { get; set; }
        [ForeignKey("CaseId")]
        public int CaseId { get; set; }
        public string Event { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EventDate { get; set; }

        public virtual Case ParentCase { get; set; }
    }
}