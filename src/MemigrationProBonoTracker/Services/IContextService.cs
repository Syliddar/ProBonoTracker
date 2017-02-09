using System.Collections.Generic;
using MemigrationProBonoTracker.Models;
using MemigrationProBonoTracker.Models.AttorneyViewModels;
using MemigrationProBonoTracker.Models.CaseViewModels;
using MemigrationProBonoTracker.Models.PersonViewModel;

namespace MemigrationProBonoTracker.Services
{
    public interface IContextService
    {
        int AddCase(CreateCaseViewModel @case);
        int UpdateCase(CaseDetailsViewModel @case);
        int DeleteCase(int id);
        CaseListViewModel GetCaseListViewModel(bool? openCases);
        CaseListViewModel GetCaseListViewModelForPerson(int personId);
        CaseDetailsViewModel GetCaseDetails(int id);
        List<CaseListItem> GetOpenCasesWithoutVolunteerAttorneys();

        int UpsertCaseEvent(CaseEvent @event);
        int DeleteCaseEvent(int eventId);
        List<CaseEventViewModel> GetUpcomingCaseEvents();
        CaseEvent GetCaseEvent(int eventId);
        List<CaseEvent> GetCaseEventList(int caseId);


        List<Person> GetPeopleList();
        Person GetPerson(int id);
        int AddPerson(Person @person);
        int UpdatePerson(Person @person);
        int DeletePerson(int id);
        //List<AssociatedPersonViewModel> GetAssociatedPeopleViewModelForPerson(int idValue);

        AttorneyListingViewModel GetAttorneyListingViewModel(bool? assigningAttorney);
        AttorneyDetailsViewModel GetAttorneyDetails(int id);
        int AddAttorney(Attorney @attorney);
        int UpdateAttorney(Attorney @attorney);
        int DeleteAttorney(int id);
        AttorneyContactInfoViewModel GetAttorneyContactInfo(int id);
        PersonContactInfoViewModel GetPersonContactInfo(int id);


        CaseLogListViewModel GetCaseLogEntries(int caseId);
        CaseLogEntry GetLogEntry(int logId);
        int AddLogEntry(CaseLogEntry log);
        int UpdateLogEntry(CaseLogEntry log);
        int DeleteLogEntry(int logId);

    }
}
