using System;
using System.Diagnostics.CodeAnalysis;
using CarRentalApplication.Forms;
using CarRentalApplication.UnitTests.Common;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarRentalApplication.UnitTests.FormsUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class FormReturnVehicleUnitTests
    {
        private FormReturnVehicle formReturnVehicle;

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsArgumentNullExceptionForNullRental()
        {
            formReturnVehicle = new FormReturnVehicle(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void ConstructorThrowsValidationExceptionForInvalidRental()
        {
            formReturnVehicle = new FormReturnVehicle(DomainEntities.GetInvalidRental());
        }

        [TestMethod]
        public void ConstructorDoesNotThrowAnyExceptionForValidRental()
        {
            formReturnVehicle = new FormReturnVehicle(DomainEntities.GetRental1());
            formReturnVehicle.Close();
            formReturnVehicle.Dispose();
        }
    }
}
