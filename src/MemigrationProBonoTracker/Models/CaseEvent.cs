using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemigrationProBonoTracker.Models
{
    public class CaseEvent
    {
        public int Id { get; set; }
        [ForeignKey("CaseId")]
        public Case ParentCase { get; set; }
        public string Event { get; set; }
        public DateTime EventDate { get; set; }
    }
}