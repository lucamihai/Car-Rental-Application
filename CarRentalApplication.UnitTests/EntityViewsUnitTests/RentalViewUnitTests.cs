using System;
using System.Diagnostics.CodeAnalysis;
using CarRentalApplication.EntityViews;
using CarRentalApplication.UnitTests.Common;
using FluentValidation;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarRentalApplication.UnitTests.EntityViewsUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class RentalViewUnitTests
    {
        private RentalView rentalView;

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsArgumentNullExceptionForNullRental()
        {
            rentalView = new RentalView(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void ConstructorThrowsValidationExceptionForInvalidRental()
        {
            rentalView = new RentalView(DomainEntities.GetInvalidRental());
        }

        [TestMethod]
        public void ConstructorSetsRentalPropertyAsExpectedForValidRental()
        {
            rentalView = new RentalView(DomainEntities.GetRental1());

            var compareLogic = new CompareLogic();
            Assert.IsTrue(compareLogic.Compare(rentalView.Rental, DomainEntities.GetRental1()).AreEqual);
        }
    }
}
