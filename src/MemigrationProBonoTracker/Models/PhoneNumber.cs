using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using MemigrationProBonoTracker.Models;

namespace MemigrationProBonoTracker.Models
{
    public class PersonPhoneNumber
    {
        public int Id { get; set; }
        [Phone]
        [UIHint("PhoneNumFormatter")]
        public string Number { get; set; }
        public Enums.NumberType Type { get; set; }
    }

    public class AttorneyPhoneNumber
    {
        public int Id { get; set; }
        [Phone]
        [UIHint("PhoneNumFormatter")]
        public string Number { get; set; }
        public Enums.NumberType Type { get; set; }
    }
}