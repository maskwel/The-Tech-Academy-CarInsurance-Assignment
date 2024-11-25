namespace CarInsurance.Models
{
    public class Insuree
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateOnly CarYear { get; set; }
        public string? CarMake { get; set; }
        public string? CarModel { get; set; }
        public bool DUI { get; set; }
        public int SpeedingTickets { get; set; }
        public string? CoverageType { get; set; }
        public int Quote { get; set; }
    }
}
