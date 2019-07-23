using CarRentalApplication.Domain.Entities;

namespace CarRentalApplication.Repositories.Mappers
{
    public class VehicleMapper
    {
        public Vehicle GetDomainVehicleFromModelVehicle(Database.Models.Vehicle vehicle)
        {
            return new Vehicle
            {
                Id = (short)vehicle.Id,
                Name = vehicle.Name,
                Type = vehicle.Type,
                FuelPercentage = vehicle.FuelPercentage,
                DamagePercentage = vehicle.DamagePercentage
            };
        }

        public Database.Models.Vehicle GetModelVehicleFromDomainVehicle(Vehicle vehicle)
        {
            return new Database.Models.Vehicle
            {
                Id = vehicle.Id,
                Name = vehicle.Name,
                Type = vehicle.Type,
                FuelPercentage = vehicle.FuelPercentage,
                DamagePercentage = vehicle.DamagePercentage
            };
        }
    }
}
