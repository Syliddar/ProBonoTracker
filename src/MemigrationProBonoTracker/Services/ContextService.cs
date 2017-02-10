using System;
using System.Collections.Generic;
using MemigrationProBonoTracker.Data;
using MemigrationProBonoTracker.Models;
using MemigrationProBonoTracker.Models.CaseViewModels;
using System.Linq;
using MemigrationProBonoTracker.Models.AttorneyViewModels;
using MemigrationProBonoTracker.Models.PersonViewModel;
using Microsoft.DotNet.Cli.Utils;
using Microsoft.EntityFrameworkCore;

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
        public CaseListViewModel GetCaseListViewModelForPerson(int personId)
        {
            var model = new CaseListViewModel();
            var today = DateTime.Today;
            var modelCases = _db.Cases.Where(c => c.LeadClientId == personId)
                .Include(c => c.VolunteerAttorney)
                .Include(c => c.AssigningAttorney)
                .Include(c => c.CaseEvents);
            model.Cases = modelCases.Select(c => new CaseListItem
            {
                CaseId = c.Id,
                ClientName = "",
                CaseType = c.Type,
                AssigningAttorneyName = c.AssigningAttorney.FullName,
                VolunteerAttorneyName = c.VolunteerAttorney == null ? "Not yet assigned." : c.VolunteerAttorney.FullName,
                NextCaseEvent = c.CaseEvents.OrderBy(e => Math.Abs((today - e.EventDate).Days)).FirstOrDefault()
            }).ToList();

            return model;
        }
        public CaseDetailsViewModel GetCaseDetails(int id)
        {
            var dbResult = _db.Cases
                .Include(c => c.LeadClient)
                .Include(c => c.AssigningAttorney)
                .Include(c => c.VolunteerAttorney)
                .Include(c => c.CaseEvents)
                .FirstOrDefault(c => c.Id == id);
            //.Include(c => c.AssociatedPeopleList).ThenInclude(p => p.Person)

            if (dbResult != null)
            {
                //var associatedPeopleList = dbResult.AssociatedPeopleList.Select(x => new AssociatedPersonViewModel
                //{
                //    AssociatedPersonId = x.Person.Id,
                //    FullName = x.Person.FullName,
                //    Relation = x.Relationship
                //}).ToList();
                return new CaseDetailsViewModel
                {
                    Id = dbResult.Id,
                    LeadClient = dbResult.LeadClient,
                    Active = dbResult.Active,
                    //AssociatedPeopleList = associatedPeopleList,
                    AssigningAttorneyFullName = dbResult.AssigningAttorney.FullName,
                    VolunteerAttorneyFullName = dbResult.VolunteerAttorney?.FullName ?? "",
                    VolunteerAttorneyOrganizationName = dbResult.VolunteerAttorney?.OrganizationName ?? "",
                    AssigningAttorneyOrganizationName = dbResult.AssigningAttorney?.OrganizationName ?? "",
                    VolunteerAttorneyId = dbResult.VolunteerAttorney?.Id ?? 0,
                    AssigningAttorneyId = dbResult.AssigningAttorney.Id,
                    AttorneyWorkedHours = dbResult.AttorneyWorkedHours,
                    Type = dbResult.Type,
                    CaseEvents = dbResult.CaseEvents,
                    CaseNotes = dbResult.CaseNotes,
                    CaseLogEntries = _db.LogEntries.Where(l => l.Case == dbResult).ToList(),
                };
            }
            return new CaseDetailsViewModel();
        }
        public int AddCase(CreateCaseViewModel @case)
        {
            Person leadClient;
            if (@case.LeadClient.Id == 0)
            {
                leadClient = new Person
                {
                    FirstName = @case.LeadClient.FirstName,
                    LastName = @case.LeadClient.LastName,
                    DateOfBirth = @case.LeadClient.DateOfBirth,
                    Gender = @case.LeadClient.Gender,
                    Nationality = @case.LeadClient.Nationality,
                    Notes = @case.LeadClient.Notes
                };
                _db.People.Add(leadClient);
                _db.SaveChanges();
            }
            else
            {
                leadClient = GetPerson(@case.LeadClient.Id);
            }
            var assigningAttorney = _db.Attorneys.Find(@case.AssigningAttorneyId);
            var newCase = new Case
            {
                Active = true,
                AssigningAttorney = assigningAttorney,
                CaseNotes = @case.CaseNotes,
                LeadClient = leadClient,
                Type = @case.Type,
                DateCreated = DateTime.Now
            };
            _db.Cases.Add(newCase);
            _db.SaveChanges();
            var createdLog = new CaseLogEntry
            {
                CaseId = newCase.Id,
                EntryDate = DateTime.Today,
                EntryNotes = "Case Created"
            };
            _db.LogEntries.Add(createdLog);
            _db.SaveChanges();
            return newCase.Id;
        }
        public int UpdateCase(CaseDetailsViewModel viewModel)
        {
            var @case = _db.Cases.Find(viewModel.Id);
            if (viewModel.CaseEvents != null && viewModel.CaseEvents.Any())
            {
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
            }
            @case.Active = viewModel.Active;
            //@case.AssociatedPeopleList = viewModel.AssociatedPeopleList.Select(x => new AssociatedPerson
            //{
            //    Id = x.RelationId,
            //    PersonId = x.AssociatedPersonId,
            //    Relationship = x.Relation
            //}).ToList();
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
            var now = DateTime.Today;
            var dbResult = _db.CaseEvents
                .Include(ce => ce.ParentCase)
                .Include(ce => ce.ParentCase.LeadClient)
                .Where(e => e.EventDate >= now && e.EventDate <= now.AddDays(14)).OrderBy(e => e.EventDate);
            var result = dbResult.Select(e => new CaseEventViewModel
            {
                CaseId = e.CaseId,
                ClientName = e.ParentCase.LeadClient.FullName,
                VolunteerAttorneyId = e.ParentCase.VolunteerAttorneyId,
                EventDate = e.EventDate,
                Event = e.Event

            }).ToList();
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
                CaseCreatedDate = c.DateCreated,
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
                .Include(p => p.Address)
                .Include(p => p.Phone)
                .FirstOrDefault(p => p.Id == id);
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
            var @person = GetPerson(id);
            _db.People.Remove(@person);
            return _db.SaveChanges();
        }
        public PersonContactInfoViewModel GetPersonContactInfo(int id)
        {
            var person = _db.People
                .Include(p => p.Address)
                .Include(p => p.Phone)
                .FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                var result = new PersonContactInfoViewModel
                {
                    PersonAddresses = person.Address,
                    PersonName = person.FullName,
                    PhoneNumbers = person.Phone
                };
                return result;
            }
            return new PersonContactInfoViewModel
            {
                PhoneNumbers = new PersonPhoneNumber(),
                PersonAddresses = new PersonAddress()
            };
        }

        //public List<AssociatedPersonViewModel> GetAssociatedPeopleViewModelForPerson(int id)
        //{
        //    var result = new List<AssociatedPersonViewModel>();
        //    var dbResult = _db.Cases.Where(ca => ca.LeadClientId == id).Include(ca => ca.AssociatedPeopleList).ThenInclude(ap => ap.Person);
        //    foreach (var @case in dbResult)
        //    {
        //        foreach (var associatedPerson in @case.AssociatedPeopleList)
        //        {
        //            if (result.Any(r => r.AssociatedPersonId == associatedPerson.Id) == false)
        //            {
        //                result.Add(new AssociatedPersonViewModel
        //                {
        //                    AssociatedPersonId = associatedPerson.Person.Id,
        //                    FullName = associatedPerson.Person.FullName,
        //                    Relation = associatedPerson.Relationship
        //                });
        //            }
        //        }
        //    }
        //    return result;
        //}

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
                    AssignedCases = _db.Cases.Count(y => y.VolunteerAttorneyId == x.Id),
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
                    AssignedCases = _db.Cases.Count(y => y.VolunteerAttorneyId == x.Id),
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
        public AttorneyDetailsViewModel GetAttorneyDetails(int id)
        {
            var viewModel = new AttorneyDetailsViewModel();
            var dbResult = _db.Attorneys.Include(x => x.Phone).Include(x => x.Address).FirstOrDefault(x => x.Id == id);
            if (dbResult != null)
            {
                dbResult.AssignedCases = _db.Cases.Count(y => y.VolunteerAttorney.Id == dbResult.Id && y.Active);
                viewModel.Attorney = dbResult;
                viewModel.CaseList = _db.Cases
                    .Include(x => x.LeadClient)
                    .Where(x => x.VolunteerAttorneyId == id).Select(x => new AttorneyCasesViewModel
                    {
                        Active = x.Active,
                        CaseId = x.Id,
                        LeadClientName = x.LeadClient.FullName,
                        Type = x.Type
                    }).ToList();
            }
            return viewModel;
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
            var attorney = _db.Attorneys.Include(a => a.Address).Include(a => a.Phone).Include(a => a.Email).First(a => a.Id == id);
            var result = new AttorneyContactInfoViewModel
            {
                AttorneyName = attorney.FullName,
                AttorneyAddresses = attorney.Address,
                Notes = attorney.Notes,
                EmailList = attorney.Email,
                PhoneNumbers = attorney.Phone
            };
            return result;
        }
        public int UpdateAttorneyOnCaseClose(CaseDetailsViewModel @case)
        {
            var atty = _db.Attorneys.Find(@case.VolunteerAttorneyId);
            atty.InterestedVolunteer = @case.InterestedVolunteer;
            atty.DesiredVolunteer = @case.DesiredVolunteer;
            return _db.SaveChanges();
        }

        #endregion
    }
}
