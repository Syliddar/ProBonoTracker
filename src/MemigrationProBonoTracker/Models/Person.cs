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
        //public List<Address> AddressList { get; set; }
        //public List<PhoneNumber> PhoneList { get; set; }
        public string Notes { get; set; }
        public int Age { get; set; }
        public NationalOrigin Nationality { get; set; }
        public Gender Gender { get; set; }


        ////Accessor Methods
        //public PhoneNumber PrimaryPhoneNumber()
        //{
        //    return PhoneList.Find(x => x.PrimaryContactNumber);
        //}
        //public Address PrimaryAddress()
        //{
        //    return AddressList.Find(x => x.PrimaryAddress);
        //}
    }
}
