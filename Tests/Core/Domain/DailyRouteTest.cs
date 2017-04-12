using Microsoft.VisualStudio.TestTools.UnitTesting;
using Passenger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Core.Domain
{
    [TestClass]
    public class DailyRouteTest
    {
        [TestMethod]
        public void ConstructDailyRoute_Valid_True()
        {
            var node1 = new Node("Wrocław", 15.15, 18.17);
            var node2 = new Node("Legnica", 15.15, 13.07);

            var route = new Route(node1, node2);

            Assert.IsTrue(route.StartNode != null);
            Assert.IsTrue(route.EndNode != null);
            Assert.AreEqual(route.StartNode.Address, "Wrocław");
            Assert.AreEqual(route.StartNode.Latitude, 15.15);
            Assert.AreEqual(route.StartNode.Longitude, 18.17);
            Assert.AreEqual(route.EndNode.Address, "Legnica");
            Assert.AreEqual(route.EndNode.Latitude, 15.15);
            Assert.AreEqual(route.EndNode.Longitude, 13.07);

        }

        [TestMethod]
        public void ConstructDailyRoutes_AreGuidDifferent_True()
        {
            var node1 = new Node("Wrocław", 15.15, 18.17);
            var node2 = new Node("Legnica", 15.15, 13.07);
            var routes = new[]
            {
                new Route(node1,node2),
                new Route(node2,node1),
                new Route(new Node("TestAddress",90,80),new Node("TestAddress2",10,50))
            };

            for(int i = 1; i< routes.Length;i++)
            {
                Assert.AreNotEqual(routes[0].Id,routes[i].Id);
            }
        }
    }
}
