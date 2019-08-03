using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CarRentalApplication.Database;
using CarRentalApplication.Domain.Entities;
using CarRentalApplication.Repositories.Mappers;
using CarRentalApplication.UnitTests.Common;
using FluentValidation;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CarRentalApplication.Repositories.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class VehicleRepositoryUnitTests
    {
        private VehicleRepository vehicleRepository;
        private Mock<CarRentalContext> carRentalContextMock;
        private Mock<VehicleMapper> vehicleMapperMock;

        private List<Database.Models.Vehicle> databaseVehicles;

        [TestInitialize]
        public void Setup()
        {
            databaseVehicles = DatabaseEntities.GetVehicles();

            vehicleMapperMock = new Mock<VehicleMapper>();
            carRentalContextMock = new Mock<CarRentalContext>("connection string");

            SetupCarRentalContext();
            SetupVehicleMapper();

            vehicleRepository = new VehicleRepository(carRentalContextMock.Object, vehicleMapperMock.Object);
        }

        private void SetupCarRentalContext()
        {
            var queryableDatabaseVehicles = databaseVehicles.AsQueryable();
            var vehiclesDbSetMock = new Mock<IDbSet<Database.Models.Vehicle>>();
            vehiclesDbSetMock.Setup(x => x.ElementType).Returns(queryableDatabaseVehicles.ElementType);
            vehiclesDbSetMock.Setup(x => x.Expression).Returns(queryableDatabaseVehicles.Expression);
            vehiclesDbSetMock.Setup(x => x.Provider).Returns(queryableDatabaseVehicles.Provider);
            vehiclesDbSetMock.Setup(x => x.GetEnumerator()).Returns(queryableDatabaseVehicles.GetEnumerator());

            carRentalContextMock.Setup(x => x.Vehicles).Returns(vehiclesDbSetMock.Object);
        }

        private void SetupVehicleMapper()
        {
            vehicleMapperMock
                .Setup(x => x.GetDomainVehicleFromModelVehicle(databaseVehicles[0]))
                .Returns(DomainEntities.GetVehicles()[0]);

            vehicleMapperMock
                .Setup(x => x.GetDomainVehicleFromModelVehicle(databaseVehicles[1]))
                .Returns(DomainEntities.GetVehicles()[1]);
        }

        [TestMethod]
        public void GetVehiclesReturnsExpectedList()
        {
            var vehicles = vehicleRepository.GetVehicles();

            var compareLogic = new CompareLogic();
            Assert.IsTrue(compareLogic.Compare(DomainEntities.GetVehicles(), vehicles).AreEqual);
        }

        [TestMethod]
        public void DeleteAllVehiclesCallsCarRentalContextVehiclesOnce()
        {
            vehicleRepository.DeleteAllVehicles();

            carRentalContextMock.Verify(x => x.Vehicles, Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddVehicleThrowsArgumentNullExceptionForNullVehicle()
        {
            vehicleRepository.AddVehicle(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void AddVehicleThrowsValidationExceptionExceptionForInvalidVehicle()
        {
            vehicleRepository.AddVehicle(DomainEntities.GetInvalidVehicle());
        }

        [TestMethod]
        public void AddVehicleCallsCarRentalContextVehiclesOnce()
        {
            vehicleRepository.AddVehicle(DomainEntities.GetSedan());

            carRentalContextMock.Verify(x => x.Vehicles, Times.Once);
        }

        [TestMethod]
        public void AddVehicleCallsVehicleMapperOnce()
        {
            vehicleRepository.AddVehicle(DomainEntities.GetSedan());

            vehicleMapperMock.Verify(x => x.GetModelVehicleFromDomainVehicle(It.IsAny<Vehicle>()), Times.Once);
        }

        [TestMethod]
        public void AddVehicleCallsCarRentalContextSaveChangesOnce()
        {
            vehicleRepository.AddVehicle(DomainEntities.GetSedan());

            carRentalContextMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteVehicleThrowsArgumentNullExceptionForNullVehicle()
        {
            vehicleRepository.DeleteVehicle(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void DeleteVehicleThrowsValidationExceptionExceptionForInvalidVehicle()
        {
            vehicleRepository.DeleteVehicle(DomainEntities.GetInvalidVehicle());
        }

        [TestMethod]
        public void DeleteVehicleCallsCarRentalContextVehiclesOnce()
        {
            vehicleRepository.DeleteVehicle(DomainEntities.GetSedan());

            carRentalContextMock.Verify(x => x.Vehicles, Times.Once);
        }

        [TestMethod]
        public void DeleteVehicleCallsVehicleMapperOnce()
        {
            vehicleRepository.DeleteVehicle(DomainEntities.GetSedan());

            vehicleMapperMock.Verify(x => x.GetModelVehicleFromDomainVehicle(It.IsAny<Vehicle>()), Times.Once);
        }

        [TestMethod]
        public void DeleteVehicleCallsCarRentalContextSaveChangesOnce()
        {
            vehicleRepository.DeleteVehicle(DomainEntities.GetSedan());

            carRentalContextMock.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
