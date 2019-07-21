using System;
using System.Collections.Generic;
using static MemigrationProBonoTracker.Models.PBTEnums;

namespace MemigrationProBonoTracker.Models.CaseViewModels
{
    public class CaseListViewModel
    {
        public string Title { get; set; }
        public List<CaseListItem> Cases { get; set; }
    }

    public class CaseListItem
    {
        public int CaseId { get; set; }
        public string ClientName { get; set; }
        public CaseType CaseType { get; set; }
        public string AssigningAttorneyName { get; set; }
        public string VolunteerAttorneyName { get; set; }
        public DateTime CaseCreatedDate { get; set; }

        public string NextCaseEventString => NextCaseEvent == null ? "" : NextCaseEvent.Event;

        public string NextCaseDateString => NextCaseEvent?.EventDate.ToString("dd MMM yyyy") ?? "";

        public CaseEvent NextCaseEvent { get; set; }
    }
}
