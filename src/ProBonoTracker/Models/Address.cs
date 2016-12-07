namespace ProBonoTracker.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public Enums.States State { get; set; }

    }
}