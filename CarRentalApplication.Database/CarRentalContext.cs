using System.Data.Entity;
using CarRentalApplication.Database.Models;

namespace CarRentalApplication.Database
{
    public class CarRentalContext : DbContext
    {
        //TODO: Remove virtual keywords from methods, and create interface for class (required for mocking)
        public virtual IDbSet<Vehicle> Vehicles { get; set; }
        public virtual IDbSet<Rental> Rentals { get; set; }

        public CarRentalContext(string connectionString) : base(connectionString) { }
    }
}
