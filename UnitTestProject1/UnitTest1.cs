using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Car_Rental_Application.User_Controls;
using Car_Rental_Application.Classes;
using System.Collections;
using System.Collections.Generic;
using Car_Rental_Application;
using System.Windows;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTest()
        {
            int a = 10;
            Assert.AreEqual(a, 10);
            Assert.AreEqual(10, a);
        }

        [TestMethod]
        public void SortByIDTest()
        {
            IDManagement.InitializeIndexes();

            List<VehicleUserControl> vehicles = new List<VehicleUserControl>();

            AvailableSedanUserControl availableSedan1 = new AvailableSedanUserControl("z", 50, 15);  //should have id=0
            AvailableMinivanUserControl availableMinivan1 = new AvailableMinivanUserControl("y", 50, 50); //id=1
            AvailableSedanUserControl availableSedan2 = new AvailableSedanUserControl("a", 25, 0); //=2

            vehicles.Add(availableSedan2); vehicles.Add(availableSedan1); vehicles.Add(availableMinivan1); //added id 2, 0 then 1

            AvailableCarsSorter sorter = new AvailableCarsSorter();
            vehicles = sorter.SortListByID(vehicles);

            short IDFromFirst = vehicles[0].GetVehicleID(); string nameFromFirst = vehicles[0].GetVehicleName();
            short IDFromSecond = vehicles[1].GetVehicleID(); string nameFromSecond = vehicles[1].GetVehicleName();
            short IDFromThird = vehicles[2].GetVehicleID(); string nameFromThird = vehicles[2].GetVehicleName();

            Assert.AreEqual(IDFromFirst, 0);    Assert.AreEqual(nameFromFirst, "z");
            Assert.AreEqual(IDFromSecond, 1);   Assert.AreEqual(nameFromSecond, "y");
            Assert.AreEqual(IDFromThird, 2);    Assert.AreEqual(nameFromThird, "a");

            IDManagement.InitializeIndexes();
        }

        [TestMethod]
        public void SortByNameTest()
        {
            IDManagement.InitializeIndexes();

            List<VehicleUserControl> vehicles = new List<VehicleUserControl>();

            AvailableSedanUserControl availableSedan1 = new AvailableSedanUserControl("z", 50, 15);  //should have id=0
            AvailableMinivanUserControl availableMinivan1 = new AvailableMinivanUserControl("y", 50, 50); //id=1
            AvailableSedanUserControl availableSedan2 = new AvailableSedanUserControl("a", 25, 0); //=2

            vehicles.Add(availableSedan2); vehicles.Add(availableSedan1); vehicles.Add(availableMinivan1); //added id 2, 0 then 1

            AvailableCarsSorter sorter = new AvailableCarsSorter();
            vehicles = sorter.SortListByName(vehicles);

            string nameFromFirst = vehicles[0].GetVehicleName();
            string nameFromSecond = vehicles[1].GetVehicleName();
            string nameFromThird = vehicles[2].GetVehicleName();

            Assert.AreEqual(nameFromFirst, "a"); Assert.AreEqual(nameFromSecond, "y"); Assert.AreEqual(nameFromThird, "z");

            IDManagement.InitializeIndexes();
        }

        [TestMethod]
        public void SortByFuelTest()
        {
            IDManagement.InitializeIndexes();

            List<VehicleUserControl> vehicles = new List<VehicleUserControl>();

            AvailableSedanUserControl availableSedan1 = new AvailableSedanUserControl("z", 50, 15);  //should have id=0
            AvailableMinivanUserControl availableMinivan1 = new AvailableMinivanUserControl("y", 50, 50); //id=1
            AvailableSedanUserControl availableSedan2 = new AvailableSedanUserControl("a", 25, 0); //=2

            vehicles.Add(availableSedan2); vehicles.Add(availableSedan1); vehicles.Add(availableMinivan1); //added id 2, 0 then 1

            AvailableCarsSorter sorter = new AvailableCarsSorter();
            vehicles = sorter.SortListByFuelPercent(vehicles);

            short fuelFromFirst = vehicles[0].GetFuelPercentage();
            short fuelFromSecond = vehicles[1].GetFuelPercentage();
            short fuelFromThird = vehicles[2].GetFuelPercentage();

            Assert.AreEqual(fuelFromFirst, 25); Assert.AreEqual(fuelFromSecond, 50); Assert.AreEqual(fuelFromThird, 50);

            IDManagement.InitializeIndexes();
        }

        [TestMethod]
        public void SortByDamageTest()
        {
            IDManagement.InitializeIndexes();

            List<VehicleUserControl> vehicles = new List<VehicleUserControl>();

            AvailableSedanUserControl availableSedan1 = new AvailableSedanUserControl("z", 50, 15);  //should have id=0
            AvailableMinivanUserControl availableMinivan1 = new AvailableMinivanUserControl("y", 50, 50); //id=1
            AvailableSedanUserControl availableSedan2 = new AvailableSedanUserControl("a", 25, 0); //=2

            vehicles.Add(availableSedan2); vehicles.Add(availableSedan1); vehicles.Add(availableMinivan1); //added id 2, 0 then 1

            AvailableCarsSorter sorter = new AvailableCarsSorter();
            vehicles = sorter.SortListByDamagePercent(vehicles);

            short damageFromFirst = vehicles[0].GetDamagePercentage();
            short damageFromSecond = vehicles[1].GetDamagePercentage();
            short damageFromThird = vehicles[2].GetDamagePercentage();

            Assert.AreEqual(damageFromFirst, 0); Assert.AreEqual(damageFromSecond, 15); Assert.AreEqual(damageFromThird, 50);

            IDManagement.InitializeIndexes();
        }
    }

}
