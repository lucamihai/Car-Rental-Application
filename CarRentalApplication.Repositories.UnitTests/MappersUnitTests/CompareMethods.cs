using System.Diagnostics.CodeAnalysis;
using CarRentalApplication.Domain.Entities;

namespace CarRentalApplication.Repositories.UnitTests.MappersUnitTests
{
    [ExcludeFromCodeCoverage]
    internal static class CompareMethods
    {
        public static bool VehiclesAreTheSame(Vehicle domainVehicle, Database.Models.Vehicle databaseVehicle)
        {
            return
                domainVehicle.Id == databaseVehicle.Id &&
                domainVehicle.Name == databaseVehicle.Name &&
                domainVehicle.Type.ToString() == databaseVehicle.VehicleType.Name &&
                domainVehicle.FuelPercentage == databaseVehicle.FuelPercentage &&
                domainVehicle.DamagePercentage == databaseVehicle.DamagePercentage;
        }

        public static bool RentalsAreTheSame(Rental domainRental, Database.Models.Rental databaseRental)
        {
            return
                domainRental.Id == databaseRental.Id &&
                domainRental.Owner.Name == databaseRental.OwnerName &&
                domainRental.Owner.PhoneNumber == databaseRental.OwnerPhone &&
                domainRental.ReturnDate == databaseRental.ReturnDate &&
                VehiclesAreTheSame(domainRental.Vehicle, databaseRental.Vehicle);
        }
    }
}
