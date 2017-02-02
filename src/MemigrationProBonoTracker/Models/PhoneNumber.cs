using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using MemigrationProBonoTracker.Models;
using Microsoft.Data.Entity.Storage;
using System.Linq;

namespace MemigrationProBonoTracker.Models
{
    public class PersonPhoneNumber
    {
        public int Id { get; set; }
        [Phone]
        [UIHint("PhoneNumFormatter")]
        [DataType(DataType.PhoneNumber)]
        public string Number { get; set; }
        public Enums.NumberType Type { get; set; }
    }

    public class AttorneyPhoneNumber
    {
        public int Id { get; set; }
        [Phone]
        [UIHint("PhoneNumFormatter")]
        public string Number { get; set; }
        public Enums.NumberType Type { get; set; }
    }
}