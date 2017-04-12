using Microsoft.VisualStudio.TestTools.UnitTesting;
using Passenger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Core.Domain
{
    [TestClass]
    public class VehicleTest
    {
        [TestMethod]
        public void ConstructVehicle_Valid_True()
        {
            var brand = "Opel";
            var name = "Astra";
            int seats = 3;

            var vehicle = new Vehicle(brand,name,seats);

            Assert.AreEqual(vehicle.Brand, "Opel");
            Assert.AreEqual(vehicle.Name, "Astra");
            Assert.AreEqual(vehicle.Seats, 3);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructVehicle_NegativeSeats_ArgumentException()
        {
            var brand = "Opel";
            var name = "Astra";
            int seats = -3;

            var vehicle = new Vehicle(brand, name, seats);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructVehicle_NullName_ArgumentException()
        {
            var brand = "Opel";
            string name = null;
            int seats = 3;

            var vehicle = new Vehicle(brand, name, seats);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructVehicle_EmptyBrand_ArgumentException()
        {
            var brand = "";
            var name = "Astra";
            int seats = 3;

            var vehicle = new Vehicle(brand, name, seats);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructVehicle_InvalidAll_ArgumentException()
        {
            string brand = null;
            var name = "";
            int seats = -3;

            var vehicle = new Vehicle(brand, name, seats);
        }
    }
}
