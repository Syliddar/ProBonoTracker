using static MemigrationProBonoTracker.Models.PBTEnums;

namespace MemigrationProBonoTracker.Models.AttorneyViewModels
{
    public class AttorneyCasesViewModel
    {
        public int CaseId { get; set; }
        public string LeadClientName { get; set; }
        public bool Active { get; set; }
        public CaseType Type { get; set; }
    }
}