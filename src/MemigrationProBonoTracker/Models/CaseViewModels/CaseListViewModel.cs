using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemigrationProBonoTracker.Models.CaseViewModels
{
    public class CaseListViewModel
    {
        public string Title { get; set; }
        public List<CaseListItem> Cases { get; set; }
    }

    public class CaseListItem
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public Enums.CaseType CaseType { get; set; }
        public string AssigningAttorneyName { get; set; }
        public string VolunteerAttorneyName { get; set; }

        public string NextCaseEventString => NextCaseEventDate == null ? "" : NextCaseEventDate.Event;

        public string NextCaseDateString => NextCaseEventDate?.EventDate.ToString("dd MMM yyyy") ?? "";

        public CaseEventDate NextCaseEventDate { get; set; }
    }
}
