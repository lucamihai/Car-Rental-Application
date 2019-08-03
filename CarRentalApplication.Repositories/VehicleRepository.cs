using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CarRentalApplication.Database;
using CarRentalApplication.Domain.Entities;
using CarRentalApplication.Repositories.Mappers;

namespace CarRentalApplication.Repositories
{
    public class VehicleRepository
    {
        public CarRentalContext CarRentalContext { get; }
        private readonly VehicleMapper vehicleMapper;

        public VehicleRepository(CarRentalContext carRentalContext, VehicleMapper vehicleMapper)
        {
            CarRentalContext = carRentalContext;
            this.vehicleMapper = vehicleMapper;
        }

        public List<Vehicle> GetVehicles()
        {
            var vehicles = new List<Vehicle>();

            var databaseVehicles = CarRentalContext.Vehicles.ToList();

            foreach (var databaseVehicle in databaseVehicles)
            {
                vehicles.Add(vehicleMapper.GetDomainVehicleFromModelVehicle(databaseVehicle));
            }

            return vehicles;
        }

        public void DeleteAllVehicles()
        {
            var ceva = ((DbSet<Database.Models.Vehicle>) CarRentalContext.Vehicles);
                ceva.RemoveRange(CarRentalContext.Vehicles.ToList());
        }

        public void AddVehicle(Vehicle vehicle)
        {
            ValidateVehicle(vehicle);

            var databaseVehicle = vehicleMapper.GetModelVehicleFromDomainVehicle(vehicle);
            CarRentalContext.Vehicles.Add(databaseVehicle);
            CarRentalContext.SaveChanges();
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            ValidateVehicle(vehicle);

            var databaseVehicle = vehicleMapper.GetModelVehicleFromDomainVehicle(vehicle);
            CarRentalContext.Vehicles.Remove(databaseVehicle);
            CarRentalContext.SaveChanges();
        }

        private void ValidateVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException($"{nameof(vehicle)} must be provided");
            }

            vehicle.ValidateAndThrow();
        }
    }
}
