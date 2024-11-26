namespace CarInsurance.ViewModels
{
    public class ViewInsuree
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CarYear { get; set; }
        public string? CarMake { get; set; }
        public string? CarModel { get; set; }
        public bool DUI { get; set; }
        public int SpeedingTickets { get; set; }
        public string? CoverageType { get; set; }
        public decimal Quote { get; set; }
    }
}
