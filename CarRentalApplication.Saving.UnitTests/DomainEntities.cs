using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CarRentalApplication.Domain.Entities;

namespace CarRentalApplication.Saving.UnitTests
{
    [ExcludeFromCodeCoverage]
    internal static class DomainEntities
    {
        public static List<Vehicle> GetVehicles()
        {
            return new List<Vehicle>
            {
                GetVehicle1(),
                GetVehicle2()
            };
        }

        public static Vehicle GetVehicle1()
        {
            return new Vehicle
            {
                Id = Constants.Id1,
                Name = Constants.Name1,
                FuelPercentage = Constants.FuelPercentage1,
                DamagePercentage = Constants.DamagePercentage1
            };
        }

        public static Vehicle GetVehicle2()
        {
            return new Vehicle
            {
                Id = Constants.Id2,
                Name = Constants.Name2,
                FuelPercentage = Constants.FuelPercentage2,
                DamagePercentage = Constants.DamagePercentage2
            };
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
                Vehicle = GetVehicle1(),
                Owner = GetPerson1(),
                ReturnDate = Constants.ReturnDate1
            };
        }

        public static Rental GetRental2()
        {
            return new Rental
            {
                Id = Constants.Id2,
                Vehicle = GetVehicle2(),
                Owner = GetPerson2(),
                ReturnDate = Constants.ReturnDate2
            };
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
