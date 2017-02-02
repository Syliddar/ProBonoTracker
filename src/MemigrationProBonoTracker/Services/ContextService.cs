using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MemigrationProBonoTracker.Data;
using MemigrationProBonoTracker.Models;
using MemigrationProBonoTracker.Models.CaseViewModels;
using System.Linq;
using MemigrationProBonoTracker.Models.AttorneyViewModels;
using MemigrationProBonoTracker.Models.PersonViewModel;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;

namespace MemigrationProBonoTracker.Services
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ContextService : IContextService
    {
        private readonly ApplicationDbContext _db;

        public ContextService(ApplicationDbContext db)
        {
            _db = db;
        }

        #region CaseMethods 
        public CaseListViewModel GetCaseListViewModel(bool? openCases)
        {
            var model = new CaseListViewModel();
            var today = DateTime.Today;
            if (openCases.HasValue)
            {
                model.Title = openCases.Value ? "Active Cases" : "Closed Cases";
                var modelCases = _db.Cases.Where(c => c.Active == openCases.Value)
                    .Include(c => c.VolunteerAttorney)
                    .Include(c => c.AssigningAttorney)
                    .Include(c => c.LeadClient)
                    .Include(c => c.CaseEvents);
                model.Cases = modelCases.Select(c => new CaseListItem
                {
                    CaseId = c.Id,
                    ClientName = c.LeadClient.FullName,
                    CaseType = c.Type,
                    AssigningAttorneyName = c.AssigningAttorney.FullName,
                    VolunteerAttorneyName = c.VolunteerAttorney == null ? "Not yet assigned." : c.VolunteerAttorney.FullName,
                    NextCaseEvent = c.CaseEvents.OrderBy(e => Math.Abs((today - e.EventDate).Days)).FirstOrDefault()
                }).ToList();
            }
            else
            {
                model.Title = "All Cases";
                model.Cases = _db.Cases
                    .Include(c => c.VolunteerAttorney)
                    .Include(c => c.AssigningAttorney)
                    .Include(c => c.LeadClient)
                    .Include(c => c.CaseEvents).Select(c => new CaseListItem
                    {
                        CaseId = c.Id,
                        ClientName = c.LeadClient.FullName,
                        CaseType = c.Type,
                        AssigningAttorneyName = c.AssigningAttorney.FullName,
                        VolunteerAttorneyName = c.VolunteerAttorney == null ? "Not yet assigned." : c.VolunteerAttorney.FullName,
                        NextCaseEvent = c.CaseEvents.OrderBy(e => Math.Abs((today - e.EventDate).Days)).FirstOrDefault()
                    }).ToList();
            }
            return model;
        }
        public CaseDetailsViewModel GetCaseDetails(int id)
        {
            var dbResult = _db.Cases
                .Include(c => c.LeadClient)
                .Include(c => c.AssigningAttorney)
                .Include(c => c.VolunteerAttorney)
                .Include(c => c.CaseEvents)
                .Include(c => c.AssociatedPeopleList).ThenInclude(p => p.Person)
                .FirstOrDefault(c => c.Id == id);

            if (dbResult != null)
                return new CaseDetailsViewModel
                {
                    Id = dbResult.Id,
                    LeadClient = dbResult.LeadClient,
                    Active = dbResult.Active,
                    AssociatedPeopleList = dbResult.AssociatedPeopleList,
                    AssigningAttorney = dbResult.AssigningAttorney,
                    VolunteerAttorneyFullName = dbResult.VolunteerAttorney?.FullName ?? "",
                    VolunteerAttorneyOrganizationName = dbResult.VolunteerAttorney?.OrganizationName ?? "",
                    VolunteerAttorneyId = dbResult.VolunteerAttorney?.Id ?? 0,
                    AssigningAttorneyId = dbResult.AssigningAttorney.Id,
                    AttorneyWorkedHours = dbResult.AttorneyWorkedHours,
                    CaseEvents = dbResult.CaseEvents,
                    CaseNotes = dbResult.CaseNotes,
                    CaseLogEntries = _db.LogEntries.Where(l => l.Case == dbResult).ToList(),
                };
            return new CaseDetailsViewModel();
        }
        public int AddCase(CreateCaseViewModel @case)
        {
            var leadClient = @case.LeadClient.Id == 0 ? new Person
            {
                FirstName = @case.LeadClient.FirstName,
                LastName = @case.LeadClient.LastName,
                DateOfBirth = @case.LeadClient.DateOfBirth,
                Gender = @case.LeadClient.Gender,
                Nationality = @case.LeadClient.Nationality,
                Notes = @case.LeadClient.Notes
            }
                : GetPerson(@case.LeadClient.Id);
            _db.People.Add(leadClient);
            _db.SaveChanges();
            var assigningAttorney = GetAttorneyDetails(@case.AssigningAttorneyId);
            var newCase = new Case
            {
                Active = true,
                AssigningAttorney = assigningAttorney,
                CaseNotes = @case.CaseNotes,
                LeadClient = leadClient,
                Type = @case.Type
            };
            _db.Cases.Add(newCase);
            return _db.SaveChanges();
        }
        public int UpdateCase(CaseDetailsViewModel viewModel)
        {
            var @case = _db.Cases.Find(viewModel.Id);
            foreach (var caseEvent in viewModel.CaseEvents)
            {
                if (caseEvent.Id == 0)
                {
                    caseEvent.ParentCase = @case;
                    _db.CaseEvents.Add(caseEvent);
                }
                else
                {
                    var @event = _db.CaseEvents.Find(caseEvent.Id);
                    @event.EventDate = caseEvent.EventDate;
                    @event.Event = caseEvent.Event;
                }

                _db.SaveChanges();
            }
            @case.Active = viewModel.Active;
            @case.AssociatedPeopleList = viewModel.AssociatedPeopleList;
            @case.AssigningAttorney = _db.Attorneys.Find(viewModel.AssigningAttorneyId);
            @case.VolunteerAttorney = _db.Attorneys.Find(viewModel.VolunteerAttorneyId);
            @case.AttorneyWorkedHours = viewModel.AttorneyWorkedHours;
            @case.CaseNotes = viewModel.CaseNotes;
            return _db.SaveChanges();
        }
        public int DeleteCase(int id)
        {
            var @case = _db.Cases.First(c => c.Id == id);
            _db.Cases.Remove(@case);
            return _db.SaveChanges();
        }
        public List<CaseEventViewModel> GetUpcomingCaseEvents()
        {
            var result = new List<CaseEventViewModel>();
            //var now = DateTime.Today;
            //var dbResult = _db.CaseEvents.Include(e => e.ParentCase).ThenInclude(c => c.VolunteerAttorney).Where(e => e.EventDate >= now && e.EventDate <= now.AddDays(14)).OrderBy(e => e.EventDate);
            ////var result = dbResult.Select(e => new CaseEventViewModel
            //{
            //    CaseId = e.CaseId,
            //    ClientName = e.ParentCase.LeadClient.FullName,
            //    AssignedAttorneyId = e.ParentCase.VolunteerAttorney == null ? 0 : e.ParentCase.VolunteerAttorney.Id,
            //    EventDate = e.EventDate,
            //    Event = e.Event

            //}).ToList();
            return result;
        }
        public List<CaseListItem> GetOpenCasesWithoutVolunteerAttorneys()
        {
            var today = DateTime.Today;
            var modelCases = _db.Cases.Where(c => c.Active && c.VolunteerAttorney == null)
                       .Include(c => c.AssigningAttorney)
                       .Include(c => c.LeadClient)
                       .Include(c => c.CaseEvents);
            return modelCases.Select(c => new CaseListItem
            {
                CaseId = c.Id,
                ClientName = c.LeadClient.FullName,
                CaseType = c.Type,
                AssigningAttorneyName = c.AssigningAttorney.FullName,
                VolunteerAttorneyName = "Not yet assigned.",
                NextCaseEvent = c.CaseEvents.OrderBy(e => Math.Abs((today - e.EventDate).Days)).FirstOrDefault()
            }).ToList();
        }

        public int UpsertCaseEvent(CaseEvent @event)
        {
            if (@event.Id == 0)
            {
                _db.Add(@event);
            }
            else
            {
                _db.Update(@event);
            }
            return _db.SaveChanges();
        }

        public int DeleteCaseEvent(int eventId)
        {
            var @caseEvent = _db.CaseEvents.Find(eventId);
            _db.CaseEvents.Remove(@caseEvent);
            return _db.SaveChanges();
        }

        public CaseEvent GetCaseEvent(int eventId)
        {
            return _db.CaseEvents.Find(eventId);
        }

        public List<CaseEvent> GetCaseEventList(int caseId)
        {
            return _db.CaseEvents.Where(c => c.CaseId == caseId).ToList();
        }

        #endregion

        #region PersonMethods
        public List<Person> GetPeopleList()
        {
            return _db.People.ToList();
        }
        public Person GetPerson(int id)
        {
            var result = _db.People
                .Include(p => p.AddressList)
                .Include(p => p.PhoneList)
                .FirstOrDefault(p => p.Id == id);

            if (result != null)
            {
                if (result.AddressList == null)
                {
                    result.AddressList = new List<PersonAddress>();
                }
                if (result.PhoneList == null)
                {
                    result.PhoneList = new List<PersonPhoneNumber>();
                }
            }
            return result;
        }
        public int AddPerson(Person person)
        {
            _db.People.Add(person);
            return _db.SaveChanges();
        }
        public int UpdatePerson(Person person)
        {
            _db.People.Update(@person);
            return _db.SaveChanges();
        }
        public int DeletePerson(int id)
        {
            var @person = _db.People.First(p => p.Id == id);
            _db.People.Remove(@person);
            return _db.SaveChanges();
        }
        public PersonContactInfoViewModel GetPersonContactInfo(int id)
        {
            var person = _db.People
                .Include(p => p.AddressList)
                .Include(p => p.PhoneList)
                .FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                var result = new PersonContactInfoViewModel
                {
                    PersonAddresses = person.AddressList,
                    PersonName = person.FullName,
                    PhoneNumbers = person.PhoneList
                };
                return result;
            }
            return new PersonContactInfoViewModel
            {
                PhoneNumbers = new List<PersonPhoneNumber>(),
                PersonAddresses = new List<PersonAddress>()
            };
        }


        #endregion

        #region CaseLogMethods

        public CaseLogListViewModel GetCaseLogEntries(int caseId)
        {
            var result = new CaseLogListViewModel
            {
                CaseId = caseId,
                LogList = _db.LogEntries.Where(x => x.CaseId == caseId).OrderBy(x => x.EntryDate).ToList()
            };
            return result;
        }

        public CaseLogEntry GetLogEntry(int logId)
        {
            return _db.LogEntries.FirstOrDefault(x => x.Id == logId);
        }

        public int AddLogEntry(CaseLogEntry log)
        {
            _db.LogEntries.Add(log);
            return _db.SaveChanges();
        }

        public int UpdateLogEntry(CaseLogEntry log)
        {
            _db.LogEntries.Update(log);
            return _db.SaveChanges();
        }

        public int DeleteLogEntry(int logId)
        {
            var log = _db.LogEntries.Find(logId);
            _db.LogEntries.Remove(log);
            return _db.SaveChanges();
        }


        #endregion

        #region AttorneyMethods
        public AttorneyListingViewModel GetAttorneyListingViewModel(bool? assigningAttorney)
        {
            var model = new AttorneyListingViewModel();
            if (assigningAttorney.HasValue)
            {
                model.Title = assigningAttorney.Value ? "Assigning Attorneys" : "Volunteer Attorney";
                //TODO: Extract this to Service
                var attorneys = _db.Attorneys.Where(c => c.IsAssigningAttorney == assigningAttorney.Value);
                List<AttorneyListItem> attorneyListItems = attorneys.Select(x => new AttorneyListItem
                {
                    Id = x.Id,
                    //AssignedCases = _db.Cases.Count(y => y.VolunteerAttorney.Id == x.CaseId),
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

                //TODO: Extract this to Service
                model.AttorneyList = _db.Attorneys.Select(x => new AttorneyListItem
                {
                    Id = x.Id,
                    //AssignedCases = _db.Cases.Count(y => y.VolunteerAttorney.Id == x.Id),
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
            return _db.Attorneys.Find(id);
        }
        public int AddAttorney(Attorney attorney)
        {
            _db.Attorneys.Add(attorney);
            return _db.SaveChanges();
        }
        public int UpdateAttorney(Attorney attorney)
        {
            _db.Attorneys.Update(attorney);
            return _db.SaveChanges();

        }
        public int DeleteAttorney(int id)
        {
            var @attorney = _db.Attorneys.Find(id);
            _db.Attorneys.Remove(@attorney);
            return _db.SaveChanges();
        }

        public AttorneyContactInfoViewModel GetAttorneyContactInfo(int id)
        {
            var attorney = _db.Attorneys.Include(a => a.AddressList).Include(a => a.PhoneList).Include(a => a.EmailList).First(a => a.Id == id);
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
