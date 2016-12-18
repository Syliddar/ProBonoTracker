using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemigrationProBonoTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static MemigrationProBonoTracker.Models.Enums;

namespace MemigrationProBonoTracker.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                //if (!(context.Addresses.Any()))
                //{
                //    var AddressA = new Address { City = "City A", PrimaryAddress = true, State = States.TN, StreetAddress1 = "1111 Street Road", StreetAddress2 = "", ZipCode = "38104" };
                //    var AddressB = new Address { City = "City B", PrimaryAddress = false, State = States.TN, StreetAddress1 = "2222 Street Road", StreetAddress2 = "", ZipCode = "38104" };
                //    var AddressC = new Address { City = "City C", PrimaryAddress = false, State = States.TN, StreetAddress1 = "3333 Street Road", StreetAddress2 = "", ZipCode = "38104" };
                //    var AddressD = new Address { City = "City D", PrimaryAddress = false, State = States.TN, StreetAddress1 = "4444 Street Road", StreetAddress2 = "", ZipCode = "38104" };
                //    var AddressE = new Address { City = "City E", PrimaryAddress = true, State = States.TN, StreetAddress1 = "1234 Street Road", StreetAddress2 = "", ZipCode = "38104" };
                //    context.Addresses.AddRange(AddressA, AddressB, AddressC, AddressD, AddressE);
                //    context.SaveChanges();

                //    var PhoneA = new PhoneNumber { Number = "1111111", PrimaryContactNumber = true };
                //    var PhoneB = new PhoneNumber { Number = "2222222", PrimaryContactNumber = false };
                //    var PhoneC = new PhoneNumber { Number = "3333333", PrimaryContactNumber = false };
                //    var PhoneD = new PhoneNumber { Number = "4444444", PrimaryContactNumber = false };
                //    var PhoneE = new PhoneNumber { Number = "1234567", PrimaryContactNumber = true };
                //    context.PhoneNumbers.AddRange(PhoneA, PhoneB, PhoneC, PhoneD, PhoneE);
                //    context.SaveChanges();

                //    var Allison = new Attorney { AddressList = new List<Address> { AddressA, AddressB }, FirstName = "Allison", LastName = "Wannamaker", Gender = Gender.Female, PhoneList = new List<PhoneNumber> { PhoneA }, BarNumber = "TN42069", ClcContribution = 0, DesiredVolunteer = true, RecruitmentDate = new DateTime(2013, 01, 20), OrganizationName = "MidSouth Immigration Advocates", SpeaksSpanish = true, HasProbateExperience = true, HasImmigrationExperience=true, HasJuvenileExperience = true, LatinoMemContribution = 50, MiaContribution = double.MaxValue, IsAssigningAttorney = true, InterestedVolunteer = true, RecruitmentMethod = RecruitmentMethod.InPersonSeminar };
                //    var Sally = new Attorney { AddressList = new List<Address> { AddressC, AddressD }, FirstName = "Sally", LastName = "Joyner", Gender = Gender.Female, PhoneList = new List<PhoneNumber> { PhoneC }, BarNumber = "TN12345", DesiredVolunteer = true, RecruitmentDate = new DateTime(2012, 10, 15), OrganizationName = "MidSouth Immigration Advocates", SpeaksSpanish = true, HasProbateExperience = true, HasImmigrationExperience = true, HasJuvenileExperience = true, LatinoMemContribution = 50, ClcContribution = 10, MiaContribution = 68.50, IsAssigningAttorney = true, InterestedVolunteer = true, RecruitmentMethod = RecruitmentMethod.PersonalContact};
                //    var JoeB = new Attorney { AddressList = new List<Address> { AddressB, AddressE }, FirstName = "Joe", LastName = "Quinn", Gender = Gender.Other, PhoneList = new List<PhoneNumber> { PhoneC }, BarNumber = "TN1234", DesiredVolunteer = true, RecruitmentDate = new DateTime(2012, 10, 15), OrganizationName = "MidSouth Immigration Advocates", SpeaksSpanish = true, HasProbateExperience = true, HasImmigrationExperience = true, HasJuvenileExperience = true, LatinoMemContribution = 50, ClcContribution = 10, MiaContribution = 68.50, IsAssigningAttorney = false, InterestedVolunteer = true, RecruitmentMethod = RecruitmentMethod.Webinar };
                //    var LisaQ = new Attorney { AddressList = new List<Address> { AddressA, AddressB }, FirstName = "Lisa", LastName = "Qwerty", Gender = Gender.Female, PhoneList = new List<PhoneNumber> { PhoneA }, BarNumber = "TN42032", DesiredVolunteer = true, RecruitmentDate = new DateTime(2013, 01, 20), OrganizationName = "MidSouth Immigration Advocates", SpeaksSpanish = true, HasProbateExperience = true, HasImmigrationExperience = true, HasJuvenileExperience = true, LatinoMemContribution = 50, MiaContribution = 68.50, ClcContribution = 0, IsAssigningAttorney = false, InterestedVolunteer = true, RecruitmentMethod = RecruitmentMethod.PersonalContact};
                //    context.Attorneys.AddRange(Allison, Sally, JoeB, LisaQ);
                //    context.SaveChanges();

                //    var JohnD = new Person { AddressList = new List<Address> { AddressA }, Age = 32, FirstName = "John", LastName = "Deere", Gender = Gender.Male, Nationality = NationalOrigin.Guatemala, Notes = "Lorem Ipsum", PhoneList = new List<PhoneNumber> { PhoneB, PhoneE } };
                //    var BillyB = new Person { AddressList = new List<Address> { AddressA }, Age = 32, FirstName = "John", LastName = "Deere", Gender = Gender.Female, Nationality = NationalOrigin.Canada, Notes = "Lorem Ipsum", PhoneList = new List<PhoneNumber> { PhoneA, PhoneD } };
                //    var MattK = new Person { AddressList = new List<Address> { AddressA }, Age = 32, FirstName = "John", LastName = "Deere", Gender = Gender.Other, Nationality = NationalOrigin.Cuba, Notes = "Lorem Ipsum", PhoneList = new List<PhoneNumber> { PhoneD, PhoneE} };
                    

                //}
            }
        }
    }
}
