namespace ProBonoTracker.Models
{
    public class AssociatedPerson
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public string Relationship { get; set; }
    }
}