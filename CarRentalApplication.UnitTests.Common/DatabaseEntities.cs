using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CarRentalApplication.Database.Models;

namespace CarRentalApplication.UnitTests.Common
{
    [ExcludeFromCodeCoverage]
    public static class DatabaseEntities
    {
        public static List<Vehicle> GetVehicles()
        {
            return new List<Vehicle>
            {
                GetSedan(),
                GetMinivan()
            };
        }

        public static Vehicle GetSedan()
        {
            return new Vehicle
            {
                Id = Constants.Id1,
                Name = Constants.Name1,
                VehicleType = GetVehicleTypeSedan(),
                FuelPercentage = Constants.FuelPercentage1,
                DamagePercentage = Constants.DamagePercentage1
            };
        }

        public static Vehicle GetMinivan()
        {
            return new Vehicle
            {
                Id = Constants.Id2,
                Name = Constants.Name2,
                VehicleType = GetVehicleTypeMinivan(),
                FuelPercentage = Constants.FuelPercentage2,
                DamagePercentage = Constants.DamagePercentage2
            };
        }

        public static VehicleType GetVehicleTypeSedan()
        {
            return new VehicleType
            {
                Name = "Sedan"
            };
        }

        public static VehicleType GetVehicleTypeMinivan()
        {
            return new VehicleType
            {
                Name = "Minivan"
            };
        }

        public static Vehicle GetInvalidVehicle()
        {
            return new Vehicle();
        }

        public static List<Rental> GetRentals()
        {
            return new List<Rental>
            {
                GetRental1(),
                GetRental2()
            };
        }

        public static Rental GetRental1()
        {
            return new Rental
            {
                Id = Constants.Id1,
                Vehicle = GetSedan(),
                OwnerName = DomainEntities.GetPerson1().Name,
                OwnerPhone = DomainEntities.GetPerson1().PhoneNumber,
                ReturnDate = Constants.ReturnDate1
            };
        }

        public static Rental GetRental2()
        {
            return new Rental
            {
                Id = Constants.Id2,
                Vehicle = GetMinivan(),
                OwnerName = DomainEntities.GetPerson2().Name,
                OwnerPhone = DomainEntities.GetPerson2().PhoneNumber,
                ReturnDate = Constants.ReturnDate2
            };
        }

        public static Rental GetInvalidRental()
        {
            return new Rental();
        }

    }
}
