using System.Diagnostics.CodeAnalysis;

namespace CarRentalApplication.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; protected set; }
        public short FuelPercentage { get; set; }
        public short DamagePercentage { get; set; }
    }
}
