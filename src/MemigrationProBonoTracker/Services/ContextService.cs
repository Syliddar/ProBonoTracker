﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MemigrationProBonoTracker.Data;
using MemigrationProBonoTracker.Models;
using MemigrationProBonoTracker.Models.CaseViewModels;
using System.Linq;
using MemigrationProBonoTracker.Models.AttorneyViewModels;
using Microsoft.EntityFrameworkCore;

namespace MemigrationProBonoTracker.Services
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ContextService : IContextService
    {
        private readonly ApplicationDbContext _context;

        public ContextService(ApplicationDbContext context)
        {
            _context = context;
        }

        #region BasicCaseMethods 
        public CaseListViewModel GetCaseListViewModel(bool? openCases)
        {
            var model = new CaseListViewModel();
            var today = DateTime.Today;
            if (openCases.HasValue)
            {
                model.Title = openCases.Value ? "Active Cases" : "Closed Cases";
                var modelCases = _context.Cases.Where(c => c.Active == openCases.Value)
                    .Include(c => c.AttorneyWorker)
                    .Include(c => c.AssigningAttorney)
                    .Include(c => c.LeadClient)
                    .Include(c => c.CaseEventDates);
                model.Cases = modelCases.Select(c => new CaseListItem
                {
                    CaseId = c.Id,
                    ClientName = c.LeadClient.FullName,
                    CaseType = c.Type,
                    AssigningAttorneyName = c.AssigningAttorney.FullName,
                    VolunteerAttorneyName = c.AttorneyWorker == null ? "Not yet assigned." : c.AttorneyWorker.FullName,
                    NextCaseEvent = c.CaseEventDates.OrderBy(e => Math.Abs((today - e.EventDate).Days)).FirstOrDefault()
                }).ToList();
            }
            else
            {
                model.Title = "All Cases";
                model.Cases = _context.Cases
                    .Include(c => c.AttorneyWorker)
                    .Include(c => c.AssigningAttorney)
                    .Include(c => c.LeadClient)
                    .Include(c => c.CaseEventDates).Select(c => new CaseListItem
                    {
                        CaseId = c.Id,
                        ClientName = c.LeadClient.FullName,
                        CaseType = c.Type,
                        AssigningAttorneyName = c.AssigningAttorney.FullName,
                        VolunteerAttorneyName = c.AttorneyWorker == null ? "Not yet assigned." : c.AttorneyWorker.FullName,
                        NextCaseEvent = c.CaseEventDates.OrderBy(e => Math.Abs((today - e.EventDate).Days)).FirstOrDefault()
                    }).ToList();
            }
            return model;
        }
        public Case GetCaseDetails(int id)
        {
            return _context.Cases.Find(id);
        }
        public int AddCase(CreateCaseViewModel @case)
        {
            var leadClient = @case.LeadClient.Id == 0 ? new Person
            {
                Age = @case.LeadClient.Age,
                FirstName = @case.LeadClient.FirstName,
                LastName = @case.LeadClient.LastName,
                Gender = @case.LeadClient.Gender,
                Nationality = @case.LeadClient.Nationality,
                Notes = @case.LeadClient.Notes
            } : GetPerson(@case.LeadClient.Id);
            _context.People.Add(leadClient);
            _context.SaveChanges();
            var assigningAttorney = GetAttorneyDetails(@case.AssigningAttorneyId);
            var newCase = new Case
            {
                Active = true,
                AssigningAttorney = assigningAttorney,
                CaseNotes = @case.CaseNotes,
                LeadClient = leadClient,
                Type = @case.Type
            };
            _context.Cases.Add(newCase);
            return _context.SaveChanges();
        }
        public int UpdateCase(Case @case)
        {
            _context.Cases.Update(@case);
            return _context.SaveChanges();
        }
        public int DeleteCase(int id)
        {
            var @case = _context.Cases.First(c => c.Id == id);
            _context.Cases.Remove(@case);
            return _context.SaveChanges();
        }
        public List<CaseEventViewModel> GetUpcomingCaseEvents()
        {
            var now = DateTime.Today;
            var dbResult = _context.CaseEvents.Include(e => e.ParentCase).ThenInclude(c => c.AttorneyWorker).Where(e => e.EventDate >= now && e.EventDate <= now.AddDays(14)).OrderBy(e => e.EventDate);
            var result = dbResult.Select(e => new CaseEventViewModel
            {
                CaseId = e.ParentCase.Id,
                ClientName = e.ParentCase.LeadClient.FullName,
                AssignedAttorneyId = e.ParentCase.AttorneyWorker == null ? 0 : e.ParentCase.AttorneyWorker.Id,
                EventDate = e.EventDate,
                Event = e.Event

            }).ToList();
            return result;
        }

        public List<CaseListItem> GetOpenCasesWithoutVolunteerAttorneys()
        {
            var today = DateTime.Today;
            var modelCases = _context.Cases.Where(c => c.Active && c.AttorneyWorker == null)
                       .Include(c => c.AssigningAttorney)
                       .Include(c => c.LeadClient)
                       .Include(c => c.CaseEventDates);
            return modelCases.Select(c => new CaseListItem
            {
                CaseId = c.Id,
                ClientName = c.LeadClient.FullName,
                CaseType = c.Type,
                AssigningAttorneyName = c.AssigningAttorney.FullName,
                VolunteerAttorneyName = "Not yet assigned.",
                NextCaseEvent = c.CaseEventDates.OrderBy(e => Math.Abs((today - e.EventDate).Days)).FirstOrDefault()
            }).ToList();
        }

        #endregion

        #region BasicPersonMethods
        public List<Person> GetPeopleList()
        {
            return _context.People.ToList();
        }
        public Person GetPerson(int id)
        {
            return _context.People.Find(id);
        }
        public int AddPerson(Person person)
        {
            _context.People.Add(person);
            return _context.SaveChanges();
        }
        public int UpdatePerson(Person person)
        {
            _context.People.Update(@person);
            return _context.SaveChanges();
        }
        public int DeletePerson(int id)
        {
            var @person = _context.People.First(p => p.Id == id);
            _context.People.Remove(@person);
            return _context.SaveChanges();
        }
        #endregion

        #region BasicAttorneyMethods
        public AttorneyListingViewModel GetAttorneyListingViewModel(bool? assigningAttorney)
        {
            var model = new AttorneyListingViewModel();
            if (assigningAttorney.HasValue)
            {
                model.Title = assigningAttorney.Value ? "Assigning Attorneys" : "Volunteer Attorney";
                var attorneys = _context.Attorneys.Where(c => c.IsAssigningAttorney == assigningAttorney.Value);
                List<AttorneyListItem> attorneyListItems = attorneys.Select(x => new AttorneyListItem
                {
                    Id = x.Id,
                    //AssignedCases = _context.Cases.Count(y => y.AttorneyWorker.Id == x.CaseId),
                    FullName = x.FullName,
                    Gender = x.Gender,
                    OrganizationName = x.OrganizationName,
                    InterestedVolunteer = x.InterestedVolunteer,
                    DesiredVolunteer = x.DesiredVolunteer,
                    SpeaksSpanish = x.SpeaksSpanish,
                    HasProbateExperience = x.HasProbateExperience,
                    HasImmigrationExperience = x.HasImmigrationExperience,
                    HasJuvenileExperience = x.HasJuvenileExperience
                }).ToList();
                model.AttorneyList = attorneyListItems;
            }
            else
            {
                model.Title = "All Attorneys";
                model.AttorneyList = _context.Attorneys.Select(x => new AttorneyListItem
                {
                    Id = x.Id,
                    AssignedCases = _context.Cases.Count(y => y.AttorneyWorker.Id == x.Id),
                    FullName = x.FullName,
                    Gender = x.Gender,
                    OrganizationName = x.OrganizationName,
                    InterestedVolunteer = x.InterestedVolunteer,
                    DesiredVolunteer = x.DesiredVolunteer,
                    SpeaksSpanish = x.SpeaksSpanish,
                    HasProbateExperience = x.HasProbateExperience,
                    HasImmigrationExperience = x.HasImmigrationExperience,
                    HasJuvenileExperience = x.HasJuvenileExperience
                }).ToList();
            }

            return model;
        }
        public Attorney GetAttorneyDetails(int id)
        {
            return _context.Attorneys.Find(id);
        }
        public int AddAttorney(Attorney attorney)
        {
            _context.Attorneys.Add(attorney);
            return _context.SaveChanges();
        }
        public int UpdateAttorney(Attorney attorney)
        {
            _context.Attorneys.Update(attorney);
            return _context.SaveChanges();

        }
        public int DeleteAttorney(int id)
        {
            var @attorney = _context.Attorneys.Find(id);
            _context.Attorneys.Remove(@attorney);
            return _context.SaveChanges();
        }

        public AttorneyContactInfoViewModel GetAttorneyContactInfo(int id)
        {
            var attorney = _context.Attorneys.Include(a => a.AddressList).Include(a => a.PhoneList).Include(a => a.EmailList).First(a => a.Id == id);
            var result = new AttorneyContactInfoViewModel
            {
                AttorneyName = attorney.FullName,
                AttorneyAddresses = attorney.AddressList,
                Notes = attorney.Notes,
                EmailList = attorney.EmailList,
                PhoneNumbers = attorney.PhoneList
            };
            return result;
        }
        #endregion
    }
}
