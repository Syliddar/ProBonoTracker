using System;

namespace ProBonoTracker.Models
{
    public class ContactLogEntry
    {
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public string EntryNotes { get; set; }
    }
}