using CarRentalApplication.Domain.Enums;

namespace CarRentalApplication.Database.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public VehicleType Type { get; set; }
        public short FuelPercentage { get; set; }
        public short DamagePercentage { get; set; }
    }
}
