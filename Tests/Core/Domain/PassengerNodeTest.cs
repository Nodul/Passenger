using Microsoft.VisualStudio.TestTools.UnitTesting;
using Passenger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Core.Domain
{
    [TestClass]
    public class PassengerNodeTest
    {
        [TestMethod]
        public void ConstructPassengerNode_Valid_True()
        {
            var node = new Node("Wrocław",15.15,17.17);
            var passenger = new Passenger.Core.Domain.Passenger(Guid.NewGuid(),new Node("Rynek",15.20,17.20));

            var passengerNode = PassengerNode.Create(node,passenger);

            Assert.IsNotNull(passengerNode.Node);
            Assert.IsNotNull(passengerNode.Passenger);
            Assert.AreEqual(passengerNode.Node.Address,"Wrocław");
            Assert.AreEqual(passengerNode.Node.Latitude, 15.15);
            Assert.AreEqual(passengerNode.Node.Longitude, 17.17);
            Assert.AreEqual(passengerNode.Passenger.Address.Address,"Rynek");
            Assert.AreEqual(passengerNode.Passenger.Address.Latitude, 15.20);
            Assert.AreEqual(passengerNode.Passenger.Address.Longitude, 17.20);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructPassengerNode_NullNode_ArgumentNullException() 
        {
            Node node = null;
            var passenger = new Passenger.Core.Domain.Passenger(Guid.NewGuid(), new Node("Rynek", 15.20, 17.20));

            var passengerNode = PassengerNode.Create(node, passenger);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructPassengerNode_NullPassenger_ArgumentNullException()
        {
            var node = new Node("Wrocław", 15.15, 17.17);
            Passenger.Core.Domain.Passenger passenger = null;

            var passengerNode = PassengerNode.Create(node, passenger);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructPassengerNode_AllNull_ArgumentNullException()
        {
            Node node = null;
            Passenger.Core.Domain.Passenger passenger = null;

            var passengerNode = PassengerNode.Create(node, passenger);
        }
    }
}
