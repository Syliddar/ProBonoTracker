using System.Collections.Generic;
using System.Threading.Tasks;
using MemigrationProBonoTracker.Data;
using MemigrationProBonoTracker.Models;
using MemigrationProBonoTracker.Models.CaseViewModels;
using Microsoft.Data.Entity;
using System.Linq;
using MemigrationProBonoTracker.Models.AttorneyViewModels;

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

        public CaseListViewModel GetCaseListViewModel(bool? openCases)
        {
            var model = new CaseListViewModel();
            if (openCases.HasValue)
            {
                model.Title = openCases.Value ? "Active Cases" : "Closed Cases";
                model.Cases = _context.Cases.Where(c => c.Active == openCases.Value)
                    .Include(c => c.LeadClient)
                    .Include(c => c.AssigningAttorney)
                    .Include(c => c.AttorneyWorker)
                    .Include(c => c.MajorDates)
                    .ToList();
            }
            else
            {
                model.Title = "All Cases";
                model.Cases = _context.Cases.ToList();
            }

            return model;
        }

        public AttorneyListingViewModel GetAttorneyListingViewModel(bool? assigningAttorney)
        {
            var model = new AttorneyListingViewModel();
            if (assigningAttorney.HasValue)
            {
                model.Title = assigningAttorney.Value ? "Assigning Attorneys" : "Volunteer Attorney";
                var attorneys = _context.Attorneys.Where(c => c.IsAssigningAttorney == assigningAttorney.Value);
                List<AttorneyListItem> foo = attorneys.Select(x => new AttorneyListItem
                {
                    Id = x.Id,
                    //AssignedCases = _context.Cases.Count(y => y.AttorneyWorker.Id == x.Id),
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
                model.AttorneyList = foo;
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

        public Case GetCaseDetails(int id)
        {
            return _context.Cases.Find(id);
        }
        public int AddCase(Case @case)
        {
            _context.Add(@case);
            return _context.SaveChanges();
        }
        public int UpdateCase(Case @case)
        {
            _context.Update(@case);
            return _context.SaveChanges();
        }
        public int DeleteCase(int id)
        {
            var @case = _context.Cases.First(c => c.Id == id);
            _context.Cases.Remove(@case);
            return _context.SaveChanges();
        }
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
            _context.Add(person);
            return _context.SaveChanges();
        }
        public int UpdatePerson(Person person)
        {
            _context.Update(@person);
            return _context.SaveChanges();
        }
        public int DeletePerson(int id)
        {
            var @person = _context.People.First(p => p.Id == id);
            _context.People.Remove(@person);
            return _context.SaveChanges();
        }
    }
}
