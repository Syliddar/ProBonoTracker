using System.ComponentModel.DataAnnotations;

namespace MemigrationProBonoTracker.Models
{
    public class Email
    {
        public int Id { get; set; }

        [EmailAddress]
        public string Address { get; set; }
    }
}