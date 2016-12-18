using System;
using static MemigrationProBonoTracker.Models.Enums;

namespace MemigrationProBonoTracker.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public States? State { get; set; }
        public string ZipCode { get; set; }
        public bool PrimaryAddress { get; set; }
    }
}