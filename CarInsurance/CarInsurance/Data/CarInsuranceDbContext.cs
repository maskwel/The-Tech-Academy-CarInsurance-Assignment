using CarInsurance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarInsurance.Data
{
    public class CarInsuranceDbContext : DbContext
    {
        public CarInsuranceDbContext(DbContextOptions<CarInsuranceDbContext> options) : base(options) { }
        
        public DbSet<Insuree> Insurees { get; set; }
    }
}
