using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CarRentalApplication.Domain.Entities;
using CarRentalApplication.Domain.Enums;

namespace CarRentalApplication.UnitTests.Common
{
    [ExcludeFromCodeCoverage]
    public static class DomainEntities
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
                Type = VehicleType.Sedan,
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
                Type = VehicleType.Minivan,
                FuelPercentage = Constants.FuelPercentage2,
                DamagePercentage = Constants.DamagePercentage2
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
                Owner = GetPerson1(),
                ReturnDate = Constants.ReturnDate1
            };
        }

        public static Rental GetRental2()
        {
            return new Rental
            {
                Id = Constants.Id2,
                Vehicle = GetMinivan(),
                Owner = GetPerson2(),
                ReturnDate = Constants.ReturnDate2
            };
        }

        public static Rental GetInvalidRental()
        {
            return new Rental();
        }

        public static Person GetPerson1()
        {
            return new Person(Constants.Name1, Constants.PhoneNumber1);
        }

        public static Person GetPerson2()
        {
            return new Person(Constants.Name2, Constants.PhoneNumber2);
        }
    }
}
