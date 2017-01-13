using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using MemigrationProBonoTracker.Models;
using MemigrationProBonoTracker.Models.AttorneyViewModels;
using MemigrationProBonoTracker.Models.CaseViewModels;
using MemigrationProBonoTracker.Models.PersonViewModel;

namespace MemigrationProBonoTracker.Services
{
    public interface IContextService
    {
        CaseListViewModel GetCaseListViewModel(bool? openCases);
        CaseDetailsViewModel GetCaseDetails(int id);
        int AddCase(CreateCaseViewModel @case);
        int UpdateCase(CaseDetailsViewModel @case);
        int DeleteCase(int id);
        List<CaseEventViewModel> GetUpcomingCaseEvents();
        List<CaseListItem> GetOpenCasesWithoutVolunteerAttorneys();
        int UpsertCaseEvent(CaseEvent @event);
        int DeleteCaseEvent(int eventId);
        CaseEvent GetCaseEvent(int eventId);

        List<Person> GetPeopleList();
        Person GetPerson(int id);
        int AddPerson(Person @person);
        int UpdatePerson(Person @person);
        int DeletePerson(int id);

        AttorneyListingViewModel GetAttorneyListingViewModel(bool? assigningAttorney);
        Attorney GetAttorneyDetails(int id);
        int AddAttorney(Attorney @attorney);
        int UpdateAttorney(Attorney @attorney);
        int DeleteAttorney(int id);
        AttorneyContactInfoViewModel GetAttorneyContactInfo(int id);
        PersonContactInfoViewModel GetPersonContactInfo(int id);
    }
}
