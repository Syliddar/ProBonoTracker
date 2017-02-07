using System.Collections.Generic;

namespace MemigrationProBonoTracker.Models.PersonViewModel
{
    public class PersonContactInfoViewModel
    {
        public string PersonName { get; set; }
        public PersonPhoneNumber PhoneNumbers { get; set; }
        public PersonAddress PersonAddresses { get; set; }
    }
}