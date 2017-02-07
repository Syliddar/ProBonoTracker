using System.Collections.Generic;

namespace MemigrationProBonoTracker.Models.AttorneyViewModels
{
    public class AttorneyContactInfoViewModel
    {
        public string AttorneyName { get; set; }
        public AttorneyPhoneNumber PhoneNumbers { get; set; }
        public AttorneyAddress AttorneyAddresses { get; set; }
        public Email EmailList { get; set; }
        public string Notes { get; set; }
    }
}