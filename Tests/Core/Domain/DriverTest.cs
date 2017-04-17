using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Passenger.Core.Domain;

namespace Tests.Core.Domain
{
    [TestClass]
    public class DriverTest
    {
        [TestMethod]
        public void ConstructDriver_Valid_True()
        {
            var user = new User("test@mail.com","test","pass1","salt1");
            var vehicle = Vehicle.Create("Opel","Corsa",3);
            var routes = new[]
            {
                new Route(new Node("Wrocław",15.15,17.17),new Node("Legnica",15.15,18.18)),
                new Route(new Node("Legnica",15.15,18.18),new Node("Wrocław",15.15,17.17)),
            };
            var dailyRoutes = new[]
            {
                new DailyRoute(routes[0],new[]{new PassengerNode(new Node("Rynek",15.16,17.18),new Passenger.Core.Domain.Passenger(Guid.NewGuid(), new Node("Rynek", 15.16, 17.18))) })
            };

            var driver = new Driver(user.Id,vehicle,routes,dailyRoutes);

            Assert.AreEqual(driver.UserId, user.Id);
            Assert.AreEqual(vehicle.Brand, "Opel");
            Assert.AreEqual(routes[1].StartNode.Address, "Legnica");
            Assert.AreEqual(dailyRoutes[0].Route.StartNode.Address, "Wrocław");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructDriver_EmptyUserID_ArgumentException()
        {
            Guid user = Guid.Empty;
            var vehicle = Vehicle.Create("Opel", "Corsa", 3);
            var routes = new[]
            {
                new Route(new Node("Wrocław",15.15,17.17),new Node("Legnica",15.15,18.18)),
                new Route(new Node("Legnica",15.15,18.18),new Node("Wrocław",15.15,17.17)),
            };
            var dailyRoutes = new[]
            {
                new DailyRoute(routes[0],new[]{new PassengerNode(new Node("Rynek",15.16,17.18),new Passenger.Core.Domain.Passenger(Guid.NewGuid(), new Node("Rynek", 15.16, 17.18))) })
            };

            var driver = new Driver(user, vehicle, routes, dailyRoutes);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructDriver_NullVehicle_ArgumentNullException()
        {
            var user = new User("test@mail.com", "test", "pass1", "salt1");
            Vehicle vehicle = null;
            var routes = new[]
            {
                new Route(new Node("Wrocław",15.15,17.17),new Node("Legnica",15.15,18.18)),
                new Route(new Node("Legnica",15.15,18.18),new Node("Wrocław",15.15,17.17)),
            };
            var dailyRoutes = new[]
            {
                new DailyRoute(routes[0],new[]{new PassengerNode(new Node("Rynek",15.16,17.18),new Passenger.Core.Domain.Passenger(Guid.NewGuid(), new Node("Rynek", 15.16, 17.18))) })
            };

            var driver = new Driver(user.Id, vehicle, routes, dailyRoutes);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructDriver_NullRoutes_ArgumentNullException()
        {
            var user = new User("test@mail.com", "test", "pass1", "salt1");
            var vehicle =Vehicle.Create("Opel", "Corsa", 3);
            IEnumerable<Route> routes = null;
            var dailyRoutes = new[]
            {
                new DailyRoute(new Route(new Node("T1",1,1),new Node("T2",2,2)),new[]{new PassengerNode(new Node("Rynek",15.16,17.18),new Passenger.Core.Domain.Passenger(Guid.NewGuid(), new Node("Rynek", 15.16, 17.18))) })
            };

            var driver = new Driver(user.Id, vehicle, routes, dailyRoutes);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructDriver_NullDailyRoutes_ArgumentNullException()
        {
            var user = new User("test@mail.com", "test", "pass1", "salt1");
            var vehicle = Vehicle.Create("Opel", "Corsa", 3);
            var routes = new[]
{
                new Route(new Node("Wrocław",15.15,17.17),new Node("Legnica",15.15,18.18)),
                new Route(new Node("Legnica",15.15,18.18),new Node("Wrocław",15.15,17.17)),
            };
            IEnumerable<DailyRoute> dailyRoutes = null;

            var driver = new Driver(user.Id, vehicle, routes, dailyRoutes);

        }
    }
}
