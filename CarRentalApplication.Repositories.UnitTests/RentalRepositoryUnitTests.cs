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
    public class RentalRepositoryUnitTests
    {
        private RentalRepository rentalRepository;
        private Mock<CarRentalContext> carRentalContextMock;
        private Mock<RentalMapper> rentalMapperMock;

        private List<Database.Models.Rental> databaseRentals;

        [TestInitialize]
        public void Setup()
        {
            databaseRentals = DatabaseEntities.GetRentals();

            rentalMapperMock = new Mock<RentalMapper>(null);
            carRentalContextMock = new Mock<CarRentalContext>("connection string");

            SetupCarRentalContext();
            SetupMapperMock();

            rentalRepository = new RentalRepository(carRentalContextMock.Object, rentalMapperMock.Object);
        }

        private void SetupCarRentalContext()
        {
            var queryableDatabaseRentals = databaseRentals.AsQueryable();
            var rentalsDbSetMock = new Mock<IDbSet<Database.Models.Rental>>();
            rentalsDbSetMock.Setup(x => x.ElementType).Returns(queryableDatabaseRentals.ElementType);
            rentalsDbSetMock.Setup(x => x.Expression).Returns(queryableDatabaseRentals.Expression);
            rentalsDbSetMock.Setup(x => x.Provider).Returns(queryableDatabaseRentals.Provider);
            rentalsDbSetMock.Setup(x => x.GetEnumerator()).Returns(queryableDatabaseRentals.GetEnumerator());

            carRentalContextMock.Setup(x => x.Rentals).Returns(rentalsDbSetMock.Object);
        }

        private void SetupMapperMock()
        {
            rentalMapperMock
                .Setup(x => x.GetDomainRentalFromModelRental(databaseRentals[0]))
                .Returns(DomainEntities.GetRentals()[0]);

            rentalMapperMock
                .Setup(x => x.GetDomainRentalFromModelRental(databaseRentals[1]))
                .Returns(DomainEntities.GetRentals()[1]);
        }

        [TestMethod]
        public void GetRentalsReturnsExpectedList()
        {
            var rentals = rentalRepository.GetRentals();

            var compareLogic = new CompareLogic();
            Assert.IsTrue(compareLogic.Compare(DomainEntities.GetRentals(), rentals).AreEqual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddRentalThrowsArgumentNullExceptionForNullRental()
        {
            rentalRepository.AddRental(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void AddRentalThrowsValidationExceptionExceptionForInvalidRental()
        {
            rentalRepository.AddRental(DomainEntities.GetInvalidRental());
        }

        [TestMethod]
        public void AddRentalCallsCarRentalContextRentalsOnce()
        {
            rentalRepository.AddRental(DomainEntities.GetRental1());

            carRentalContextMock.Verify(x => x.Rentals, Times.Once);
        }

        [TestMethod]
        public void AddRentalCallsRentalMapperOnce()
        {
            rentalRepository.AddRental(DomainEntities.GetRental1());

            rentalMapperMock.Verify(x => x.GetModelRentalFromDomainRental(It.IsAny<Rental>()), Times.Once);
        }

        [TestMethod]
        public void AddRentalCallsCarRentalContextSaveChangesOnce()
        {
            rentalRepository.AddRental(DomainEntities.GetRental1());

            carRentalContextMock.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteRentalThrowsArgumentNullExceptionForNullRental()
        {
            rentalRepository.DeleteRental(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void DeleteRentalThrowsValidationExceptionExceptionForInvalidRental()
        {
            rentalRepository.DeleteRental(DomainEntities.GetInvalidRental());
        }

        [TestMethod]
        public void DeleteRentalCallsCarRentalContextRentalsOnce()
        {
            rentalRepository.DeleteRental(DomainEntities.GetRental1());

            carRentalContextMock.Verify(x => x.Rentals, Times.Once);
        }

        [TestMethod]
        public void DeleteRentalCallsRentalMapperOnce()
        {
            rentalRepository.DeleteRental(DomainEntities.GetRental1());

            rentalMapperMock.Verify(x => x.GetModelRentalFromDomainRental(It.IsAny<Rental>()), Times.Once);
        }

        [TestMethod]
        public void DeleteRentalCallsCarRentalContextSaveChangesOnce()
        {
            rentalRepository.DeleteRental(DomainEntities.GetRental1());

            carRentalContextMock.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
