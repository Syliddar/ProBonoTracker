using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MemigrationProBonoTracker.Models.Enums;

namespace MemigrationProBonoTracker.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }
        public List<PersonAddress> AddressList { get; set; }
        public List<PersonPhoneNumber> PhoneList { get; set; }
        public string Notes { get; set; }
        public int Age { get; set; }
        public NationalOrigin Nationality { get; set; }
        public Gender Gender { get; set; }
    }
}
