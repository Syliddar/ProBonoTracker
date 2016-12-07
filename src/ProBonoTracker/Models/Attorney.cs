using System.Collections.Generic;

namespace ProBonoTracker.Models
{
    public class Attorney
    {
        public int Id { get; set; }
        public string AttorneyName { get; set; }
        public string OrganizationName { get; set; }
        public List<PhoneNumber> ContactNumbers { get; set; }
        public bool IsAssigningAttorney { get; set; }

        //Accessor Methods
        public PhoneNumber PrimaryPhoneNumber()
        {
            return ContactNumbers.Find(x => x.PrimaryContactNumber);
        }

    }
}