using System.Collections.Generic;

namespace MemigrationProBonoTracker.Models.PersonViewModel
{
    public class PersonContactInfoViewModel
    {
        public string PersonName { get; set; }
        public List<PersonPhoneNumber> PhoneNumbers { get; set; }
        public List<PersonAddress> PersonAddresses { get; set; }
    }
}