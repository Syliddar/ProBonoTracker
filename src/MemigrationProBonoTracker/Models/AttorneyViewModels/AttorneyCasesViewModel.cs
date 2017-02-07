namespace MemigrationProBonoTracker.Models.AttorneyViewModels
{
    public class AttorneyCasesViewModel
    {
        public int CaseId { get; set; }
        public string LeadClientName { get; set; }
        public bool Active { get; set; }
        public Enums.CaseType Type { get; set; }
    }
}