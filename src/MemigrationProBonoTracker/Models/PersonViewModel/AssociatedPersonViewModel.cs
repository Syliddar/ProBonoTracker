namespace MemigrationProBonoTracker.Models.PersonViewModel
{
    public class AssociatedPersonViewModel
    {
        public int RelationId { get; set; }
        public int AssociatedPersonId { get; set; }
        public string FullName { get; set; }
        public string Relation { get; set; }
    }
}