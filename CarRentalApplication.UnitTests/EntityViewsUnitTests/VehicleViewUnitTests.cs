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
    public class VehicleViewUnitTests
    {
        private VehicleView vehicleView;

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsArgumentNullExceptionForNullVehicle()
        {
            vehicleView = new VehicleView(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void ConstructorThrowsValidationExceptionForInvalidVehicle()
        {
            vehicleView = new VehicleView(DomainEntities.GetInvalidVehicle());
        }

        [TestMethod]
        public void ConstructorSetsVehiclePropertyAsExpectedForValidVehicle()
        {
            vehicleView = new VehicleView(DomainEntities.GetSedan());

            var compareLogic = new CompareLogic();
            Assert.IsTrue(compareLogic.Compare(vehicleView.Vehicle, DomainEntities.GetSedan()).AreEqual);
        }
    }
}
