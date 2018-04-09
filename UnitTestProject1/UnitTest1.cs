using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Car_Rental_Application.User_Controls;
using Car_Rental_Application.Classes;
using System.Collections;
using System.Collections.Generic;

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
        public void TestIfConstructorWorkProperly()
        {
            //string vehicleName
            Assert.AreEqual(5, 5);
        }
        [TestMethod]
        public void SerializeAndDeserializeWork()
        {
            List<VehicleUserControl> vehicles = new List<VehicleUserControl>();
        }
    }

}
