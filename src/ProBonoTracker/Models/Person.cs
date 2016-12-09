using System.Collections.Generic;
using static ProBonoTracker.Models.Enums;

namespace ProBonoTracker.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        public List<Address> AddressList { get; set; }
        public List<PhoneNumber> PhoneList { get; set; }
        public string Notes { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public Gender Gender { get; set; }


        //Accessor Methods
        public PhoneNumber PrimaryPhoneNumber()
        {
            return PhoneList.Find(x => x.PrimaryContactNumber);
        }
        public Address PrimaryAddress()
        {
            return AddressList.Find(x => x.PrimaryAddress);
        }
    }
}
