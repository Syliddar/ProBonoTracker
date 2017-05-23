using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static MemigrationProBonoTracker.Models.Enums;

namespace MemigrationProBonoTracker.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get { return FirstName + " " + LastName; } }

        public PersonAddress Address { get; set; }

        public PersonPhoneNumber Phone { get; set; }

        [Required]
        [Display(Name = "Alien Number")]
        public string AlienNumber { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Country of Origin")]
        public Country Nationality { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }
    }
}