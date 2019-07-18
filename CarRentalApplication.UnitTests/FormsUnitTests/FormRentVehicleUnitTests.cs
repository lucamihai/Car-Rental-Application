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
    public class FormRentVehicleUnitTests
    {
        private FormRentVehicle formRentVehicle;

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsArgumentNullExceptionForNullVehicle()
        {
            formRentVehicle = new FormRentVehicle(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void ConstructorThrowsValidationExceptionForInvalidVehicle()
        {
            formRentVehicle = new FormRentVehicle(DomainEntities.GetInvalidVehicle());
        }

        [TestMethod]
        public void ConstructorDoesNotThrowAnyExceptionForValidVehicle()
        {
            formRentVehicle = new FormRentVehicle(DomainEntities.GetSedan());
            formRentVehicle.Close();
            formRentVehicle.Dispose();
        }
    }
}
