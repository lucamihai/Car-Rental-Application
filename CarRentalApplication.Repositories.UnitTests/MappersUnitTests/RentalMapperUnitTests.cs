using System;
using System.Diagnostics.CodeAnalysis;
using CarRentalApplication.Domain.Entities;
using CarRentalApplication.Repositories.Mappers;
using CarRentalApplication.UnitTests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CarRentalApplication.Repositories.UnitTests.MappersUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class RentalMapperUnitTests
    {
        private RentalMapper rentalMapper;
        private Mock<VehicleMapper> vehicleMapperMock;

        [TestInitialize]
        public void Setup()
        {
            vehicleMapperMock = new Mock<VehicleMapper>();
            rentalMapper = new RentalMapper(vehicleMapperMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetDomainRentalFromModelRentalThrowsArgumentNullExceptionForNullEntity()
        {
            rentalMapper.GetDomainRentalFromModelRental(null);
        }

        [TestMethod]
        public void GetDomainRentalFromModelRentalCallsVehicleMapperOnce()
        {
            var databaseRental = DatabaseEntities.GetRental1();

            vehicleMapperMock
                .Setup(x => x.GetDomainVehicleFromModelVehicle(databaseRental.Vehicle))
                .Returns(DomainEntities.GetSedan);

            rentalMapper.GetDomainRentalFromModelRental(databaseRental);

            vehicleMapperMock.Verify(x => x.GetDomainVehicleFromModelVehicle(It.IsAny<Database.Models.Vehicle>()), Times.Once);
        }

        [TestMethod]
        public void GetDomainRentalFromModelRentalReturnsExpectedEntity()
        {
            var databaseRental = DatabaseEntities.GetRental1();

            vehicleMapperMock
                .Setup(x => x.GetDomainVehicleFromModelVehicle(databaseRental.Vehicle))
                .Returns(DomainEntities.GetSedan);

            var domainRental = rentalMapper.GetDomainRentalFromModelRental(databaseRental);

            Assert.IsTrue(CompareMethods.RentalsAreTheSame(domainRental, databaseRental));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetGetModelRentalFromDomainRentalThrowsArgumentNullExceptionForNullEntity()
        {
            rentalMapper.GetModelRentalFromDomainRental(null);
        }

        [TestMethod]
        public void GetModelRentalFromDomainRentalCallsVehicleMapperOnce()
        {
            var domainRental = DomainEntities.GetRental1();

            vehicleMapperMock
                .Setup(x => x.GetModelVehicleFromDomainVehicle(domainRental.Vehicle))
                .Returns(DatabaseEntities.GetSedan);

            rentalMapper.GetModelRentalFromDomainRental(domainRental);

            vehicleMapperMock.Verify(x => x.GetModelVehicleFromDomainVehicle(It.IsAny<Vehicle>()), Times.Once);
        }

        [TestMethod]
        public void GetModelRentalFromDomainRentalReturnsExpectedEntity()
        {
            var domainRental = DomainEntities.GetRental1();

            vehicleMapperMock
                .Setup(x => x.GetModelVehicleFromDomainVehicle(domainRental.Vehicle))
                .Returns(DatabaseEntities.GetSedan);

            var databaseRental = rentalMapper.GetModelRentalFromDomainRental(domainRental);

            Assert.IsTrue(CompareMethods.RentalsAreTheSame(domainRental, databaseRental));
        }
    }
}
