using System;
using static MemigrationProBonoTracker.Models.Enums;

namespace MemigrationProBonoTracker.Models
{
    public class PersonAddress
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public bool PrimaryAddress { get; set; }
    }


    public class AttorneyAddress
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public bool PrimaryAddress { get; set; }
    }
}