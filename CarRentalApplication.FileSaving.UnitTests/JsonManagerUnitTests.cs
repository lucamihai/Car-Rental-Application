using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using CarRentalApplication.UnitTests.Common;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarRentalApplication.FileSaving.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class JsonManagerUnitTests
    {
        private string jsonVehiclesFilePath;
        private string jsonRentalsFilePath;

        [TestInitialize]
        public void Setup()
        {
            jsonVehiclesFilePath = $"{Environment.CurrentDirectory}\\jsonVehiclesTest.json";
            jsonRentalsFilePath = $"{Environment.CurrentDirectory}\\jsonRentalsTest.json";
        }

        [TestMethod]
        public void WriteVehiclesToJsonFileCreatesFileIfItDoesNotExist()
        {
            Assert.IsFalse(File.Exists(jsonVehiclesFilePath));

            JsonManager.WriteVehiclesToJsonFile(DomainEntities.GetVehicles(), jsonVehiclesFilePath);

            Assert.IsTrue(File.Exists(jsonVehiclesFilePath));
        }

        [TestMethod]
        public void WriteVehiclesToJsonFileWillOverwriteExistingFile()
        {
            var fileInitialContents = "someContents";
            File.WriteAllText(jsonVehiclesFilePath, fileInitialContents);

            JsonManager.WriteVehiclesToJsonFile(DomainEntities.GetVehicles(), jsonVehiclesFilePath);

            var fileCurrentContents = File.ReadAllText(jsonVehiclesFilePath);
            Assert.AreNotEqual(fileCurrentContents, fileInitialContents);
        }

        [TestMethod]
        public void WriteVehiclesToJsonFileWritesExpectedStringToFile()
        {
            JsonManager.WriteVehiclesToJsonFile(DomainEntities.GetVehicles(), jsonVehiclesFilePath);

            var fileContents = File.ReadAllText(jsonVehiclesFilePath);
            Assert.AreEqual(Constants.VehiclesJsonString, fileContents);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ReadVehiclesFromJsonFileThrowsArgumentExceptionIfFileDoesNotExist()
        {
            JsonManager.ReadVehiclesFromJsonFile(jsonVehiclesFilePath);
        }

        [TestMethod]
        public void ReadVehiclesFromJsonFileReturnsExpectedList()
        {
            File.WriteAllText(jsonVehiclesFilePath, Constants.VehiclesJsonString);

            var vehiclesFromJson = JsonManager.ReadVehiclesFromJsonFile(jsonVehiclesFilePath);

            var compareLogic = new CompareLogic();
            Assert.IsTrue(compareLogic.Compare(vehiclesFromJson, DomainEntities.GetVehicles()).AreEqual);
        }

        [TestMethod]
        public void WriteRentalsToJsonFileCreatesFileIfItDoesNotExist()
        {
            Assert.IsFalse(File.Exists(jsonRentalsFilePath));

            JsonManager.WriteRentalsToJsonFile(DomainEntities.GetRentals(), jsonRentalsFilePath);

            Assert.IsTrue(File.Exists(jsonRentalsFilePath));
        }

        [TestMethod]
        public void WriteRentalsToJsonFileWillOverwriteExistingFile()
        {
            var fileInitialContents = "someContents";
            File.WriteAllText(jsonRentalsFilePath, fileInitialContents);

            JsonManager.WriteRentalsToJsonFile(DomainEntities.GetRentals(), jsonRentalsFilePath);

            var fileCurrentContents = File.ReadAllText(jsonRentalsFilePath);
            Assert.AreNotEqual(fileCurrentContents, fileInitialContents);
        }

        [TestMethod]
        public void WriteRentalsToJsonFileWritesExpectedStringToFile()
        {
            JsonManager.WriteRentalsToJsonFile(DomainEntities.GetRentals(), jsonRentalsFilePath);

            var fileContents = File.ReadAllText(jsonRentalsFilePath);
            Assert.AreEqual(Constants.RentalsJsonString, fileContents);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ReadRentalsFromJsonFileThrowsArgumentExceptionIfFileDoesNotExist()
        {
            JsonManager.ReadRentalsFromJsonFile(jsonRentalsFilePath);
        }

        [TestMethod]
        public void ReadRentalsFromJsonFileReturnsExpectedList()
        {
            File.WriteAllText(jsonRentalsFilePath, Constants.RentalsJsonString);

            var rentalsFromJson = JsonManager.ReadRentalsFromJsonFile(jsonRentalsFilePath);

            var compareLogic = new CompareLogic();
            Assert.IsTrue(compareLogic.Compare(rentalsFromJson, DomainEntities.GetRentals()).AreEqual);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(jsonVehiclesFilePath))
            {
                File.Delete(jsonVehiclesFilePath);
            }

            if (File.Exists(jsonRentalsFilePath))
            {
                File.Delete(jsonRentalsFilePath);
            }
        }

    }
}
