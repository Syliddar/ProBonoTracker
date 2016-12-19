using System;

namespace MemigrationProBonoTracker.Models
{
    public class ContactLogEntry
    {
        public int Id { get; set; }
        public Case Case { get; set; }
        public DateTime EntryDate { get; set; }
        public string EntryNotes { get; set; }
    }
}