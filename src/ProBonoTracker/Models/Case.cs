using System.Collections.Generic;

namespace ProBonoTracker.Models
{
    public class Case
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public Address ClientAddress { get; set; }
        public List<PhoneNumber> ClientPhoneNumbers { get; set; }
        public Attorney AssigningAttorney { get; set; }
        public Attorney CaseAttorney { get; set; }

        //Accessor Methods
        public PhoneNumber PrimaryPhoneNumber()
        {
            return ClientPhoneNumbers.Find(x => x.PrimaryContactNumber);
        }
    }
}
