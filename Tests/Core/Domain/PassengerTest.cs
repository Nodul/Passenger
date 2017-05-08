using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Passenger.Core.Domain;

namespace Tests.Core.Domain
{
    [TestClass]
    public class PassengerTest
    {
        [TestMethod]
        public void ConstructPassenger_Valid_True()
        {
            var user = new User("test@mail.com", "test1", "pass1", "salt1",Roles.User);
            var node = new Node("Wrocław, Rynek 10/12",51.17,17.17);

            var passenger = new Passenger.Core.Domain.Passenger(user.Id,node);

            Assert.IsTrue(passenger.Id != Guid.Empty);
            Assert.AreEqual(passenger.Address.Address, "Wrocław, Rynek 10/12");
            Assert.AreEqual(passenger.Address.Latitude, 51.17);
            Assert.AreEqual(passenger.Address.Longitude, 17.17);
            Assert.AreEqual(passenger.UserId, user.Id);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructPassenger_EmptyGuid_ArgumentException()
        {

            Guid guid = Guid.Empty;
            var node = new Node("Wrocław, Rynek 10/12", 51.17, 17.17);

            var passenger = new Passenger.Core.Domain.Passenger(guid, node);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructPassenger_NullNode_ArgumentException()
        {

            var user = new User("test@mail.com", "test1", "pass1", "salt1",Roles.User);
            Node node = null;

            var passenger = new Passenger.Core.Domain.Passenger(user.Id, node);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructPassenger_AllInvalid_ArgumentException()
        {

            Guid guid = Guid.Empty;
            Node node = null;

            var passenger = new Passenger.Core.Domain.Passenger(guid, node);

        }

        [TestMethod]
        public void ConstructPassengers_AreGuidsDifferent_True()
        {
            var passengers = new[]
            {
                new Passenger.Core.Domain.Passenger(Guid.NewGuid(),new Node("Test1",1.1,2.2)),
                new Passenger.Core.Domain.Passenger(Guid.NewGuid(),new Node("Test1",1.1,2.2)),
                new Passenger.Core.Domain.Passenger(Guid.NewGuid(),new Node("Test1",1.1,2.2)),
                new Passenger.Core.Domain.Passenger(Guid.NewGuid(),new Node("Test1",1.1,2.2))
            };

            for(int i = 1; i < passengers.Length; i++)
            {
                Assert.AreNotEqual(passengers[0].Id, passengers[i].Id);
            }
        }
    }
}
