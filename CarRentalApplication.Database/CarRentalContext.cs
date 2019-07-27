using System.Data.Entity;
using CarRentalApplication.Database.Models;

namespace CarRentalApplication.Database
{
    public class CarRentalContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public CarRentalContext(string connectionString) : base(connectionString) { }
    }
}
