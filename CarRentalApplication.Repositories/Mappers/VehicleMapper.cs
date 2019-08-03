using System;
using CarRentalApplication.Domain.Entities;
using CarRentalApplication.Domain.Enums;

namespace CarRentalApplication.Repositories.Mappers
{
    //TODO: Remove virtual keywords from methods, and create interface for class (required for mocking)
    public class VehicleMapper
    {
        public virtual Vehicle GetDomainVehicleFromModelVehicle(Database.Models.Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException();
            }

            var domainVehicle = new Vehicle
            {
                Id = (short)vehicle.Id,
                Name = vehicle.Name,
                FuelPercentage = vehicle.FuelPercentage,
                DamagePercentage = vehicle.DamagePercentage
            };

            if (vehicle.VehicleType.Name == "Sedan")
            {
                domainVehicle.Type = VehicleType.Sedan;
            }

            if (vehicle.VehicleType.Name == "Minivan")
            {
                domainVehicle.Type = VehicleType.Minivan;
            }

            return domainVehicle;
        }

        public virtual Database.Models.Vehicle GetModelVehicleFromDomainVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException();
            }

            return new Database.Models.Vehicle
            {
                Id = vehicle.Id,
                Name = vehicle.Name,
                VehicleType = new Database.Models.VehicleType { Name = vehicle.Type.ToString() },
                FuelPercentage = vehicle.FuelPercentage,
                DamagePercentage = vehicle.DamagePercentage
            };
        }
    }
}
