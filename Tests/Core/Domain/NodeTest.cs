using Microsoft.VisualStudio.TestTools.UnitTesting;
using Passenger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Core.Domain
{
    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructNode_EmptyAddress_ArgumentException()
        {
            string address = null;
            var longitude = 17.03;
            var latitude = 51.11;

            var node = new Node(address,latitude, longitude);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructNode_NegativeLongitude_ArgumentException()
        {
            var address = "Wrocław, Rynek 99/9";
            var longitude = -17.03;
            var latitude = 51.11;

            var node = new Node(address, latitude, longitude);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructNode_NegativeLatitude_ArgumentException()
        {
            var address = "Wrocław, Rynek 99/9";
            var longitude = 17.03;
            var latitude = -51.11;

            var node = new Node(address, latitude, longitude);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructNode_Over90Latitude_ArgumentException()
        {
            var address = "Wrocław, Rynek 99/9";
            var longitude = 17.03;
            var latitude = 151.11;

            var node = new Node(address, latitude, longitude);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructNode_Over180Longitude_ArgumentException()
        {
            var address = "Wrocław, Rynek 99/9";
            var longitude = 192.03;
            var latitude = 51.11;

            var node = new Node(address, latitude, longitude);
        }

        [TestMethod]
        public void ConstructNode_Valid_True()
        {
            var address = "Wrocław, Rynek 99/9";
            var longitude = 17.03;
            var latitude = 51.11;

            var node = new Node(address, latitude, longitude);

            Assert.AreEqual(node.Address, "Wrocław, Rynek 99/9");
            Assert.AreEqual(node.Latitude, latitude);
            Assert.AreEqual(node.Longitude, longitude);
        }
    }
}
