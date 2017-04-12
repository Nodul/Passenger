using Microsoft.VisualStudio.TestTools.UnitTesting;
using Passenger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Core.Domain
{
    [TestClass]
    public class RouteTest
    {
        [TestMethod]
        public void ConstructRoute_Valid_True()
        {
            var startNode = new Node("Wrocław, Rynek 20/20", 51.11, 17.21);
            var endNode = new Node("Wrocław, Ołbin 100/2", 51.15, 17.25);

            var route = new Route(startNode, endNode);

            Assert.AreEqual(route.StartNode.Address, "Wrocław, Rynek 20/20");
            Assert.AreEqual(route.StartNode.Latitude, 51.11);
            Assert.AreEqual(route.StartNode.Longitude, 17.21);
            Assert.AreEqual(route.EndNode.Address, "Wrocław, Ołbin 100/2");
            Assert.AreEqual(route.EndNode.Latitude, 51.15);
            Assert.AreEqual(route.EndNode.Longitude, 17.25);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructRoute_EmptyStartAddress_ArgumentException()
        {
            var startNode = new Node("", 51.11, 17.21);
            var endNode = new Node("Wrocław, Ołbin 100/2", 51.15, 17.25);

            var route = new Route(startNode, endNode);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructRoute_EmptyEndAddress_ArgumentException()
        {
            var startNode = new Node("Wrocław, Rynek 20/20", 51.11, 17.21);
            var endNode = new Node("", 51.15, 17.25);

            var route = new Route(startNode, endNode);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructRoute_NullStartAddress_ArgumentException()
        {
            var startNode = new Node(null, 51.11, 17.21);
            var endNode = new Node("Wrocław, Ołbin 100/2", 51.15, 17.25);

            var route = new Route(startNode, endNode);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructRoute_NullEndAddress_ArgumentException()
        {
            var startNode = new Node("Wrocław, Rynek 20/20", 51.11, 17.21);
            var endNode = new Node(null, 51.15, 17.25);

            var route = new Route(startNode, endNode);
        }

        [TestMethod]
        public void ConstructRoutes_AreGuidsDifferent_True()
        {
            var startNode = new Node("Wrocław, Rynek 20/20", 51.11, 17.21);
            var endNode = new Node("Wrocław, Ołbin 100/2", 51.15, 17.25);

            var routes = new[]
                {
                new Route(startNode, endNode),
                new Route(startNode, endNode),
                new Route(startNode, endNode),
                new Route(startNode, endNode),
                new Route(startNode, endNode),
                new Route(startNode, endNode)
            };


            for (int i = 1; i < routes.Length; i++)
            {
                Assert.AreNotEqual(routes[0].Id, routes[i].Id);
            }
        }
    }
}
