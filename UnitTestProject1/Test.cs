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
    public class Test
    {

        #region Available vehicles sorting

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
        #endregion

        #region Rented vehicles sorting

        [TestMethod]
        public void RentedSortByRentID()
        {
            IDManagement.InitializeIndexes();

            List<VehicleUserControl> vehicles = new List<VehicleUserControl>();

            AvailableSedanUserControl availableSedan1 = new AvailableSedanUserControl("z", 50, 15);  //should have id=0
            AvailableMinivanUserControl availableMinivan1 = new AvailableMinivanUserControl("y", 50, 50); //id=1
            AvailableSedanUserControl availableSedan2 = new AvailableSedanUserControl("a", 25, 0); //=2

            Customer owner1 = new Customer("John Doe", "012345");
            Customer owner2 = new Customer("John Smith", "987654");
            Customer owner3 = new Customer("Johnny John", "192837");

            DateTime returnDate1 = DateTime.Parse("1/1/2010");
            DateTime returnDate2 = DateTime.Parse("5/5/2015");
            DateTime returnDate3 = DateTime.Parse("7/7/2009");

            RentedSedanUserControl rentedSedan1 = new RentedSedanUserControl(availableSedan1, owner1, returnDate1);
            RentedMinivanUserControl rentedMinivan1 = new RentedMinivanUserControl(availableMinivan1, owner2, returnDate2);
            RentedSedanUserControl rentedSedan2 = new RentedSedanUserControl(availableSedan2, owner3, returnDate3);

            vehicles.Add(rentedSedan2); vehicles.Add(rentedSedan1); vehicles.Add(rentedMinivan1); //added id 2, 0 then 1

            RentedCarsSorter sorter = new RentedCarsSorter();
            vehicles = sorter.SortListByID(vehicles);

            short IDFromFirst = vehicles[0].GetRentID(); string nameFromFirst = vehicles[0].GetVehicleName();
            short IDFromSecond = vehicles[1].GetRentID(); string nameFromSecond = vehicles[1].GetVehicleName();
            short IDFromThird = vehicles[2].GetRentID(); string nameFromThird = vehicles[2].GetVehicleName();

            Assert.AreEqual(IDFromFirst, 0); Assert.AreEqual(nameFromFirst, "z");
            Assert.AreEqual(IDFromSecond, 1); Assert.AreEqual(nameFromSecond, "y");
            Assert.AreEqual(IDFromThird, 2); Assert.AreEqual(nameFromThird, "a");

            IDManagement.InitializeIndexes();
        }

        [TestMethod]
        public void RentedSortByNameTest()
        {
            IDManagement.InitializeIndexes();

            List<VehicleUserControl> vehicles = new List<VehicleUserControl>();

            AvailableSedanUserControl availableSedan1 = new AvailableSedanUserControl("z", 50, 15);  //should have id=0
            AvailableMinivanUserControl availableMinivan1 = new AvailableMinivanUserControl("y", 50, 50); //id=1
            AvailableSedanUserControl availableSedan2 = new AvailableSedanUserControl("a", 25, 0); //=2

            Customer owner1 = new Customer("John Doe", "012345");
            Customer owner2 = new Customer("John Smith", "987654");
            Customer owner3 = new Customer("Johnny John", "192837");

            DateTime returnDate1 = DateTime.Parse("1/1/2010");
            DateTime returnDate2 = DateTime.Parse("5/5/2015");
            DateTime returnDate3 = DateTime.Parse("7/7/2009");

            RentedSedanUserControl rentedSedan1 = new RentedSedanUserControl(availableSedan1, owner1, returnDate1);
            RentedMinivanUserControl rentedMinivan1 = new RentedMinivanUserControl(availableMinivan1, owner2, returnDate2);
            RentedSedanUserControl rentedSedan2 = new RentedSedanUserControl(availableSedan2, owner3, returnDate3);

            vehicles.Add(rentedSedan2); vehicles.Add(rentedSedan1); vehicles.Add(rentedMinivan1); //added id 2, 0 then 1

            RentedCarsSorter sorter = new RentedCarsSorter();
            vehicles = sorter.SortListByName(vehicles);

            string nameFromFirst = vehicles[0].GetVehicleName();
            string nameFromSecond = vehicles[1].GetVehicleName();
            string nameFromThird = vehicles[2].GetVehicleName();

            Assert.AreEqual(nameFromFirst, "a"); Assert.AreEqual(nameFromSecond, "y"); Assert.AreEqual(nameFromThird, "z");

            IDManagement.InitializeIndexes();
        }

        [TestMethod]
        public void RentedSortByFuelTest()
        {
            IDManagement.InitializeIndexes();

            List<VehicleUserControl> vehicles = new List<VehicleUserControl>();

            AvailableSedanUserControl availableSedan1 = new AvailableSedanUserControl("z", 50, 15);  //should have id=0
            AvailableMinivanUserControl availableMinivan1 = new AvailableMinivanUserControl("y", 50, 50); //id=1
            AvailableSedanUserControl availableSedan2 = new AvailableSedanUserControl("a", 25, 0); //=2

            Customer owner1 = new Customer("John Doe", "012345");
            Customer owner2 = new Customer("John Smith", "987654");
            Customer owner3 = new Customer("Johnny John", "192837");

            DateTime returnDate1 = DateTime.Parse("1/1/2010");
            DateTime returnDate2 = DateTime.Parse("5/5/2015");
            DateTime returnDate3 = DateTime.Parse("7/7/2009");

            RentedSedanUserControl rentedSedan1 = new RentedSedanUserControl(availableSedan1, owner1, returnDate1);
            RentedMinivanUserControl rentedMinivan1 = new RentedMinivanUserControl(availableMinivan1, owner2, returnDate2);
            RentedSedanUserControl rentedSedan2 = new RentedSedanUserControl(availableSedan2, owner3, returnDate3);

            vehicles.Add(rentedSedan2); vehicles.Add(rentedSedan1); vehicles.Add(rentedMinivan1); //added id 2, 0 then 1

            RentedCarsSorter sorter = new RentedCarsSorter();
            vehicles = sorter.SortListByFuelPercent(vehicles);

            short fuelFromFirst = vehicles[0].GetFuelPercentage();
            short fuelFromSecond = vehicles[1].GetFuelPercentage();
            short fuelFromThird = vehicles[2].GetFuelPercentage();

            Assert.AreEqual(fuelFromFirst, 25); Assert.AreEqual(fuelFromSecond, 50); Assert.AreEqual(fuelFromThird, 50);

            IDManagement.InitializeIndexes();
        }

        [TestMethod]
        public void RentedSortByDamageTest()
        {
            IDManagement.InitializeIndexes();

            List<VehicleUserControl> vehicles = new List<VehicleUserControl>();

            AvailableSedanUserControl availableSedan1 = new AvailableSedanUserControl("z", 50, 15);  //should have id=0
            AvailableMinivanUserControl availableMinivan1 = new AvailableMinivanUserControl("y", 50, 50); //id=1
            AvailableSedanUserControl availableSedan2 = new AvailableSedanUserControl("a", 25, 0); //=2

            Customer owner1 = new Customer("John Doe", "012345");
            Customer owner2 = new Customer("John Smith", "987654");
            Customer owner3 = new Customer("Johnny John", "192837");

            DateTime returnDate1 = DateTime.Parse("1/1/2010");
            DateTime returnDate2 = DateTime.Parse("5/5/2015");
            DateTime returnDate3 = DateTime.Parse("7/7/2009");

            RentedSedanUserControl rentedSedan1 = new RentedSedanUserControl(availableSedan1, owner1, returnDate1);
            RentedMinivanUserControl rentedMinivan1 = new RentedMinivanUserControl(availableMinivan1, owner2, returnDate2);
            RentedSedanUserControl rentedSedan2 = new RentedSedanUserControl(availableSedan2, owner3, returnDate3);

            vehicles.Add(rentedSedan2); vehicles.Add(rentedSedan1); vehicles.Add(rentedMinivan1); //added id 2, 0 then 1

            RentedCarsSorter sorter = new RentedCarsSorter();
            vehicles = sorter.SortListByDamagePercent(vehicles);

            short damageFromFirst = vehicles[0].GetDamagePercentage();
            short damageFromSecond = vehicles[1].GetDamagePercentage();
            short damageFromThird = vehicles[2].GetDamagePercentage();

            Assert.AreEqual(damageFromFirst, 0); Assert.AreEqual(damageFromSecond, 15); Assert.AreEqual(damageFromThird, 50);

            IDManagement.InitializeIndexes();
        }

        [TestMethod]
        public void RentedSortByOwnerNameTest()
        {
            IDManagement.InitializeIndexes();

            List<VehicleUserControl> vehicles = new List<VehicleUserControl>();

            AvailableSedanUserControl availableSedan1 = new AvailableSedanUserControl("z", 50, 15);  //should have id=0
            AvailableMinivanUserControl availableMinivan1 = new AvailableMinivanUserControl("y", 50, 50); //id=1
            AvailableSedanUserControl availableSedan2 = new AvailableSedanUserControl("a", 25, 0); //=2

            Customer owner1 = new Customer("John Doe", "012345");
            Customer owner2 = new Customer("John Smith", "987654");
            Customer owner3 = new Customer("Johnny John", "192837");

            DateTime returnDate1 = DateTime.Parse("1/1/2010");
            DateTime returnDate2 = DateTime.Parse("5/5/2015");
            DateTime returnDate3 = DateTime.Parse("7/7/2009");

            RentedSedanUserControl rentedSedan1 = new RentedSedanUserControl(availableSedan1, owner1, returnDate1);
            RentedMinivanUserControl rentedMinivan1 = new RentedMinivanUserControl(availableMinivan1, owner2, returnDate2);
            RentedSedanUserControl rentedSedan2 = new RentedSedanUserControl(availableSedan2, owner3, returnDate3);

            vehicles.Add(rentedSedan2); vehicles.Add(rentedSedan1); vehicles.Add(rentedMinivan1); //added id 2, 0 then 1

            RentedCarsSorter sorter = new RentedCarsSorter();
            vehicles = sorter.SortListByOwnerName(vehicles);

            string ownerNameFromFirst = vehicles[0].GetOwner().GetName();
            string ownerNameFromSecond = vehicles[1].GetOwner().GetName();
            string ownerNameFromThird = vehicles[2].GetOwner().GetName();

            Assert.AreEqual(ownerNameFromFirst, "John Doe"); Assert.AreEqual(ownerNameFromSecond, "John Smith"); Assert.AreEqual(ownerNameFromThird, "Johnny John");

            IDManagement.InitializeIndexes();
        }

        [TestMethod]
        public void RentedSortByOwnerPhoneTest()
        {
            IDManagement.InitializeIndexes();

            List<VehicleUserControl> vehicles = new List<VehicleUserControl>();

            AvailableSedanUserControl availableSedan1 = new AvailableSedanUserControl("z", 50, 15);  //should have id=0
            AvailableMinivanUserControl availableMinivan1 = new AvailableMinivanUserControl("y", 50, 50); //id=1
            AvailableSedanUserControl availableSedan2 = new AvailableSedanUserControl("a", 25, 0); //=2

            Customer owner1 = new Customer("John Doe", "012345");
            Customer owner2 = new Customer("John Smith", "987654");
            Customer owner3 = new Customer("Johnny John", "192837");

            DateTime returnDate1 = DateTime.Parse("1/1/2010");
            DateTime returnDate2 = DateTime.Parse("5/5/2015");
            DateTime returnDate3 = DateTime.Parse("7/7/2009");

            RentedSedanUserControl rentedSedan1 = new RentedSedanUserControl(availableSedan1, owner1, returnDate1);
            RentedMinivanUserControl rentedMinivan1 = new RentedMinivanUserControl(availableMinivan1, owner2, returnDate2);
            RentedSedanUserControl rentedSedan2 = new RentedSedanUserControl(availableSedan2, owner3, returnDate3);

            vehicles.Add(rentedSedan2); vehicles.Add(rentedSedan1); vehicles.Add(rentedMinivan1); //added id 2, 0 then 1

            RentedCarsSorter sorter = new RentedCarsSorter();
            vehicles = sorter.SortListByOwnerPhoneNumber(vehicles);

            string ownerPhoneFromFirst = vehicles[0].GetOwner().GetPhoneNumber();
            string ownerPhoneFromSecond = vehicles[1].GetOwner().GetPhoneNumber();
            string ownerPhoneFromThird = vehicles[2].GetOwner().GetPhoneNumber();

            Assert.AreEqual(ownerPhoneFromFirst, "012345"); Assert.AreEqual(ownerPhoneFromSecond, "192837"); Assert.AreEqual(ownerPhoneFromThird, "987654");

            IDManagement.InitializeIndexes();
        }

        [TestMethod]
        public void RentedSortByReturnDateTest()
        {
            IDManagement.InitializeIndexes();

            List<VehicleUserControl> vehicles = new List<VehicleUserControl>();

            AvailableSedanUserControl availableSedan1 = new AvailableSedanUserControl("z", 50, 15);  //should have id=0
            AvailableMinivanUserControl availableMinivan1 = new AvailableMinivanUserControl("y", 50, 50); //id=1
            AvailableSedanUserControl availableSedan2 = new AvailableSedanUserControl("a", 25, 0); //=2

            Customer owner1 = new Customer("John Doe", "012345");
            Customer owner2 = new Customer("John Smith", "987654");
            Customer owner3 = new Customer("Johnny John", "192837");

            DateTime returnDate1 = DateTime.Parse("1/1/2010");
            DateTime returnDate2 = DateTime.Parse("5/5/2015");
            DateTime returnDate3 = DateTime.Parse("7/7/2009");

            RentedSedanUserControl rentedSedan1 = new RentedSedanUserControl(availableSedan1, owner1, returnDate1);
            RentedMinivanUserControl rentedMinivan1 = new RentedMinivanUserControl(availableMinivan1, owner2, returnDate2);
            RentedSedanUserControl rentedSedan2 = new RentedSedanUserControl(availableSedan2, owner3, returnDate3);

            vehicles.Add(rentedSedan2); vehicles.Add(rentedSedan1); vehicles.Add(rentedMinivan1); //added id 2, 0 then 1

            RentedCarsSorter sorter = new RentedCarsSorter();
            vehicles = sorter.SortListByReturnDate(vehicles);

            string returnDateFromFirst = vehicles[0].GetReturnDate().ToShortDateString();
            string returnDateFromSecond = vehicles[1].GetReturnDate().ToShortDateString();
            string returnDateFromThird = vehicles[2].GetReturnDate().ToShortDateString();

            Assert.AreEqual(returnDateFromFirst, "7/7/2009"); Assert.AreEqual(returnDateFromSecond, "1/1/2010"); Assert.AreEqual(returnDateFromThird, "5/5/2015");

            IDManagement.InitializeIndexes();
        }

        #endregion 

    }

}
