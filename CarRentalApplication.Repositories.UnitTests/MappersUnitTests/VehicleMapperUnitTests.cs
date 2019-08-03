using System;
using System.Diagnostics.CodeAnalysis;
using CarRentalApplication.Repositories.Mappers;
using CarRentalApplication.UnitTests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarRentalApplication.Repositories.UnitTests.MappersUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class VehicleMapperUnitTests
    {
        private VehicleMapper vehicleMapper;

        [TestInitialize]
        public void Setup()
        {
            vehicleMapper = new VehicleMapper();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetDomainVehicleFromModelVehicleThrowsArgumentNullExceptionForNullEntity()
        {
            vehicleMapper.GetDomainVehicleFromModelVehicle(null);
        }

        [TestMethod]
        public void GetDomainVehicleFromModelVehicleReturnsExceptedEntity()
        {
            var databaseVehicle = DatabaseEntities.GetSedan();

            var domainVehicle = vehicleMapper.GetDomainVehicleFromModelVehicle(databaseVehicle);

            Assert.IsTrue(CompareMethods.VehiclesAreTheSame(domainVehicle, databaseVehicle));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetModelVehicleFromDomainVehicleThrowsArgumentNullExceptionForNullEntity()
        {
            vehicleMapper.GetModelVehicleFromDomainVehicle(null);
        }

        [TestMethod]
        public void GetModelVehicleFromDomainVehicleReturnsExpectedEntity()
        {
            var domainVehicle = DomainEntities.GetSedan();

            var databaseVehicle = vehicleMapper.GetModelVehicleFromDomainVehicle(domainVehicle);

            Assert.IsTrue(CompareMethods.VehiclesAreTheSame(domainVehicle, databaseVehicle));
        }
    }
}
