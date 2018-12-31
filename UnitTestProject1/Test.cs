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
        /*
        #region Available vehicles sorting

        [TestMethod]
        public void SortByIDTest()
        {
            IDManagement.InitializeIndexes();

            List<VehicleUserControl> vehicles = new List<VehicleUserControl>();

            // Create some vehicles
            AvailableSedanUserControl availableSedan1     = new AvailableSedanUserControl("z", 50, 15);       //id = 0
            AvailableMinivanUserControl availableMinivan1 = new AvailableMinivanUserControl("y", 50, 50);     //id = 1
            AvailableSedanUserControl availableSedan2     = new AvailableSedanUserControl("a", 25, 0);        //id = 2


            // Add them to a list
            vehicles.Add(availableSedan2);
            vehicles.Add(availableSedan1);
            vehicles.Add(availableMinivan1);


            // Perform sorting by ID
            VehicleSorter sorter = new VehicleSorter();
            vehicles = sorter.SortListByID(vehicles);


            // Check if the sorting is correct
            short IDFromFirst = vehicles[0].ID;
            short IDFromSecond = vehicles[1].ID;
            short IDFromThird = vehicles[2].ID;

            Assert.AreEqual(IDFromFirst, 0);
            Assert.AreEqual(IDFromSecond, 1);
            Assert.AreEqual(IDFromThird, 2);


            // Restore indexes
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

            VehicleSorter sorter = new VehicleSorter();
            vehicles = sorter.SortListByName(vehicles);

            string nameFromFirst = vehicles[0].VehicleName;
            string nameFromSecond = vehicles[1].VehicleName;
            string nameFromThird = vehicles[2].VehicleName;

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

            VehicleSorter sorter = new VehicleSorter();
            vehicles = sorter.SortListByFuelPercent(vehicles);

            short fuelFromFirst = vehicles[0].FuelPercentage;
            short fuelFromSecond = vehicles[1].FuelPercentage;
            short fuelFromThird = vehicles[2].FuelPercentage;

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

            VehicleSorter sorter = new VehicleSorter();
            vehicles = sorter.SortListByDamagePercent(vehicles);

            short damageFromFirst = vehicles[0].DamagePercentage;
            short damageFromSecond = vehicles[1].DamagePercentage;
            short damageFromThird = vehicles[2].DamagePercentage;

            Assert.AreEqual(damageFromFirst, 0); Assert.AreEqual(damageFromSecond, 15); Assert.AreEqual(damageFromThird, 50);

            IDManagement.InitializeIndexes();
        }
        #endregion
        */

        /*
        #region Rented vehicles sorting

        [TestMethod]
        public void RentedSortByRentID()
        {
            IDManagement.InitializeIndexes();

            List<Vehicle> vehicles = new List<Vehicle>();

            AvailableSedanUserControl availableSedan1 = new AvailableSedanUserControl("z", 50, 15);  //should have id=0
            AvailableMinivanUserControl availableMinivan1 = new AvailableMinivanUserControl("y", 50, 50); //id=1
            AvailableSedanUserControl availableSedan2 = new AvailableSedanUserControl("a", 25, 0); //=2

            Person owner1 = new Person("John Doe", "012345");
            Person owner2 = new Person("John Smith", "987654");
            Person owner3 = new Person("Johnny John", "192837");

            DateTime returnDate1 = DateTime.Parse("1/1/2010");
            DateTime returnDate2 = DateTime.Parse("5/5/2015");
            DateTime returnDate3 = DateTime.Parse("7/7/2009");

            RentedSedanUserControl rentedSedan1 = new RentedSedanUserControl(availableSedan1, owner1, returnDate1);
            RentedMinivanUserControl rentedMinivan1 = new RentedMinivanUserControl(availableMinivan1, owner2, returnDate2);
            RentedSedanUserControl rentedSedan2 = new RentedSedanUserControl(availableSedan2, owner3, returnDate3);

            vehicles.Add(rentedSedan2); vehicles.Add(rentedSedan1); vehicles.Add(rentedMinivan1); //added id 2, 0 then 1

            RentalSorter sorter = new RentalSorter();
            vehicles = sorter.SortListByID(vehicles);

            short IDFromFirst = vehicles[0].RentID;
            string nameFromFirst = vehicles[0].VehicleName;

            short IDFromSecond = vehicles[1].RentID;
            string nameFromSecond = vehicles[1].VehicleName;

            short IDFromThird = vehicles[2].RentID;
            string nameFromThird = vehicles[2].VehicleName;

            Assert.AreEqual(IDFromFirst, 0);
            Assert.AreEqual(nameFromFirst, "z");

            Assert.AreEqual(IDFromSecond, 1);
            Assert.AreEqual(nameFromSecond, "y");

            Assert.AreEqual(IDFromThird, 2);
            Assert.AreEqual(nameFromThird, "a");

            IDManagement.InitializeIndexes();
        }

        [TestMethod]
        public void RentedSortByNameTest()
        {
            IDManagement.InitializeIndexes();

            List<Vehicle> vehicles = new List<Vehicle>();

            AvailableSedanUserControl availableSedan1 = new AvailableSedanUserControl("z", 50, 15);  //should have id=0
            AvailableMinivanUserControl availableMinivan1 = new AvailableMinivanUserControl("y", 50, 50); //id=1
            AvailableSedanUserControl availableSedan2 = new AvailableSedanUserControl("a", 25, 0); //=2

            Person owner1 = new Person("John Doe", "012345");
            Person owner2 = new Person("John Smith", "987654");
            Person owner3 = new Person("Johnny John", "192837");

            DateTime returnDate1 = DateTime.Parse("1/1/2010");
            DateTime returnDate2 = DateTime.Parse("5/5/2015");
            DateTime returnDate3 = DateTime.Parse("7/7/2009");

            RentedSedanUserControl rentedSedan1 = new RentedSedanUserControl(availableSedan1, owner1, returnDate1);
            RentedMinivanUserControl rentedMinivan1 = new RentedMinivanUserControl(availableMinivan1, owner2, returnDate2);
            RentedSedanUserControl rentedSedan2 = new RentedSedanUserControl(availableSedan2, owner3, returnDate3);

            vehicles.Add(rentedSedan2); vehicles.Add(rentedSedan1); vehicles.Add(rentedMinivan1); //added id 2, 0 then 1

            RentalSorter sorter = new RentalSorter();
            vehicles = sorter.SortListByName(vehicles);

            string nameFromFirst = vehicles[0].VehicleName;
            string nameFromSecond = vehicles[1].VehicleName;
            string nameFromThird = vehicles[2].VehicleName;

            Assert.AreEqual(nameFromFirst, "a"); Assert.AreEqual(nameFromSecond, "y"); Assert.AreEqual(nameFromThird, "z");

            IDManagement.InitializeIndexes();
        }

        [TestMethod]
        public void RentedSortByFuelTest()
        {
            IDManagement.InitializeIndexes();

            List<Vehicle> vehicles = new List<Vehicle>();

            AvailableSedanUserControl availableSedan1 = new AvailableSedanUserControl("z", 50, 15);  //should have id=0
            AvailableMinivanUserControl availableMinivan1 = new AvailableMinivanUserControl("y", 50, 50); //id=1
            AvailableSedanUserControl availableSedan2 = new AvailableSedanUserControl("a", 25, 0); //=2

            Person owner1 = new Person("John Doe", "012345");
            Person owner2 = new Person("John Smith", "987654");
            Person owner3 = new Person("Johnny John", "192837");

            DateTime returnDate1 = DateTime.Parse("1/1/2010");
            DateTime returnDate2 = DateTime.Parse("5/5/2015");
            DateTime returnDate3 = DateTime.Parse("7/7/2009");

            RentedSedanUserControl rentedSedan1 = new RentedSedanUserControl(availableSedan1, owner1, returnDate1);
            RentedMinivanUserControl rentedMinivan1 = new RentedMinivanUserControl(availableMinivan1, owner2, returnDate2);
            RentedSedanUserControl rentedSedan2 = new RentedSedanUserControl(availableSedan2, owner3, returnDate3);

            vehicles.Add(rentedSedan2); vehicles.Add(rentedSedan1); vehicles.Add(rentedMinivan1); //added id 2, 0 then 1

            RentalSorter sorter = new RentalSorter();
            vehicles = sorter.SortListByFuelPercent(vehicles);

            short fuelFromFirst = vehicles[0].FuelPercentage;
            short fuelFromSecond = vehicles[1].FuelPercentage;
            short fuelFromThird = vehicles[2].FuelPercentage;

            Assert.AreEqual(fuelFromFirst, 25); Assert.AreEqual(fuelFromSecond, 50); Assert.AreEqual(fuelFromThird, 50);

            IDManagement.InitializeIndexes();
        }

        [TestMethod]
        public void RentedSortByDamageTest()
        {
            IDManagement.InitializeIndexes();

            List<Vehicle> vehicles = new List<Vehicle>();

            AvailableSedanUserControl availableSedan1 = new AvailableSedanUserControl("z", 50, 15);  //should have id=0
            AvailableMinivanUserControl availableMinivan1 = new AvailableMinivanUserControl("y", 50, 50); //id=1
            AvailableSedanUserControl availableSedan2 = new AvailableSedanUserControl("a", 25, 0); //=2

            Person owner1 = new Person("John Doe", "012345");
            Person owner2 = new Person("John Smith", "987654");
            Person owner3 = new Person("Johnny John", "192837");

            DateTime returnDate1 = DateTime.Parse("1/1/2010");
            DateTime returnDate2 = DateTime.Parse("5/5/2015");
            DateTime returnDate3 = DateTime.Parse("7/7/2009");

            RentedSedanUserControl rentedSedan1 = new RentedSedanUserControl(availableSedan1, owner1, returnDate1);
            RentedMinivanUserControl rentedMinivan1 = new RentedMinivanUserControl(availableMinivan1, owner2, returnDate2);
            RentedSedanUserControl rentedSedan2 = new RentedSedanUserControl(availableSedan2, owner3, returnDate3);

            vehicles.Add(rentedSedan2);
            vehicles.Add(rentedSedan1);
            vehicles.Add(rentedMinivan1); //added id 2, 0 then 1

            RentalSorter sorter = new RentalSorter();
            vehicles = sorter.SortListByDamagePercent(vehicles);

            short damageFromFirst = vehicles[0].DamagePercentage;
            short damageFromSecond = vehicles[1].DamagePercentage;
            short damageFromThird = vehicles[2].DamagePercentage;

            Assert.AreEqual(damageFromFirst, 0);
            Assert.AreEqual(damageFromSecond, 15);
            Assert.AreEqual(damageFromThird, 50);

            IDManagement.InitializeIndexes();
        }

        [TestMethod]
        public void RentedSortByOwnerNameTest()
        {
            IDManagement.InitializeIndexes();

            List<Vehicle> vehicles = new List<Vehicle>();

            AvailableSedanUserControl availableSedan1 = new AvailableSedanUserControl("z", 50, 15);  //should have id=0
            AvailableMinivanUserControl availableMinivan1 = new AvailableMinivanUserControl("y", 50, 50); //id=1
            AvailableSedanUserControl availableSedan2 = new AvailableSedanUserControl("a", 25, 0); //=2

            Person owner1 = new Person("John Doe", "012345");
            Person owner2 = new Person("John Smith", "987654");
            Person owner3 = new Person("Johnny John", "192837");

            DateTime returnDate1 = DateTime.Parse("1/1/2010");
            DateTime returnDate2 = DateTime.Parse("5/5/2015");
            DateTime returnDate3 = DateTime.Parse("7/7/2009");

            RentedSedanUserControl rentedSedan1 = new RentedSedanUserControl(availableSedan1, owner1, returnDate1);
            RentedMinivanUserControl rentedMinivan1 = new RentedMinivanUserControl(availableMinivan1, owner2, returnDate2);
            RentedSedanUserControl rentedSedan2 = new RentedSedanUserControl(availableSedan2, owner3, returnDate3);

            vehicles.Add(rentedSedan2); vehicles.Add(rentedSedan1); vehicles.Add(rentedMinivan1); //added id 2, 0 then 1

            RentalSorter sorter = new RentalSorter();
            vehicles = sorter.SortListByOwnerName(vehicles);

            string ownerNameFromFirst = vehicles[0].Owner.Name;
            string ownerNameFromSecond = vehicles[1].Owner.Name;
            string ownerNameFromThird = vehicles[2].Owner.Name;

            Assert.AreEqual(ownerNameFromFirst, "John Doe"); Assert.AreEqual(ownerNameFromSecond, "John Smith"); Assert.AreEqual(ownerNameFromThird, "Johnny John");

            IDManagement.InitializeIndexes();
        }

        [TestMethod]
        public void RentedSortByOwnerPhoneTest()
        {
            IDManagement.InitializeIndexes();

            List<Vehicle> vehicles = new List<Vehicle>();

            AvailableSedanUserControl availableSedan1 = new AvailableSedanUserControl("z", 50, 15);  //should have id=0
            AvailableMinivanUserControl availableMinivan1 = new AvailableMinivanUserControl("y", 50, 50); //id=1
            AvailableSedanUserControl availableSedan2 = new AvailableSedanUserControl("a", 25, 0); //=2

            Person owner1 = new Person("John Doe", "012345");
            Person owner2 = new Person("John Smith", "987654");
            Person owner3 = new Person("Johnny John", "192837");

            DateTime returnDate1 = DateTime.Parse("1/1/2010");
            DateTime returnDate2 = DateTime.Parse("5/5/2015");
            DateTime returnDate3 = DateTime.Parse("7/7/2009");

            RentedSedanUserControl rentedSedan1 = new RentedSedanUserControl(availableSedan1, owner1, returnDate1);
            RentedMinivanUserControl rentedMinivan1 = new RentedMinivanUserControl(availableMinivan1, owner2, returnDate2);
            RentedSedanUserControl rentedSedan2 = new RentedSedanUserControl(availableSedan2, owner3, returnDate3);

            vehicles.Add(rentedSedan2); vehicles.Add(rentedSedan1); vehicles.Add(rentedMinivan1); //added id 2, 0 then 1

            RentalSorter sorter = new RentalSorter();
            vehicles = sorter.SortListByOwnerPhoneNumber(vehicles);

            string ownerPhoneFromFirst = vehicles[0].Owner.PhoneNumber;
            string ownerPhoneFromSecond = vehicles[1].Owner.PhoneNumber;
            string ownerPhoneFromThird = vehicles[2].Owner.PhoneNumber;

            Assert.AreEqual(ownerPhoneFromFirst, "012345"); Assert.AreEqual(ownerPhoneFromSecond, "192837"); Assert.AreEqual(ownerPhoneFromThird, "987654");

            IDManagement.InitializeIndexes();
        }

        [TestMethod]
        public void RentedSortByReturnDateTest()
        {
            IDManagement.InitializeIndexes();

            List<Vehicle> vehicles = new List<Vehicle>();

            AvailableSedanUserControl availableSedan1 = new AvailableSedanUserControl("z", 50, 15);  //should have id=0
            AvailableMinivanUserControl availableMinivan1 = new AvailableMinivanUserControl("y", 50, 50); //id=1
            AvailableSedanUserControl availableSedan2 = new AvailableSedanUserControl("a", 25, 0); //=2

            Person owner1 = new Person("John Doe", "012345");
            Person owner2 = new Person("John Smith", "987654");
            Person owner3 = new Person("Johnny John", "192837");

            DateTime returnDate1 = DateTime.Parse("1/1/2010");
            DateTime returnDate2 = DateTime.Parse("5/5/2015");
            DateTime returnDate3 = DateTime.Parse("7/7/2009");

            RentedSedanUserControl rentedSedan1 = new RentedSedanUserControl(availableSedan1, owner1, returnDate1);
            RentedMinivanUserControl rentedMinivan1 = new RentedMinivanUserControl(availableMinivan1, owner2, returnDate2);
            RentedSedanUserControl rentedSedan2 = new RentedSedanUserControl(availableSedan2, owner3, returnDate3);

            vehicles.Add(rentedSedan2);
            vehicles.Add(rentedSedan1);
            vehicles.Add(rentedMinivan1);

            RentalSorter sorter = new RentalSorter();
            vehicles = sorter.SortListByReturnDate(vehicles);

            string returnDateFromFirst = vehicles[0].ReturnDate.ToShortDateString();
            string returnDateFromSecond = vehicles[1].ReturnDate.ToShortDateString();
            string returnDateFromThird = vehicles[2].ReturnDate.ToShortDateString();

            Assert.AreEqual(returnDate3, DateTime.Parse(returnDateFromFirst));
            Assert.AreEqual(returnDate1, DateTime.Parse(returnDateFromSecond));
            Assert.AreEqual(returnDate2, DateTime.Parse(returnDateFromThird));

            IDManagement.InitializeIndexes();
        }

        #endregion 
        */
    }
}
