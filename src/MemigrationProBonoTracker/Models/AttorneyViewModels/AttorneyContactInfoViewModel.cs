using System.Collections.Generic;

namespace MemigrationProBonoTracker.Models.AttorneyViewModels
{
    public class AttorneyContactInfoViewModel
    {
        public string AttorneyName { get; set; }
        public List<AttorneyPhoneNumber> PhoneNumbers { get; set; }
        public List<AttorneyAddress> AttorneyAddresses { get; set; }
        public string Notes { get; set; }
    }
}