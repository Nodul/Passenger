using Microsoft.VisualStudio.TestTools.UnitTesting;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Infrastructure.Repositories
{
    [TestClass]
    public class InMemoryUserRepositoryTest
    {
        [TestMethod]
        public void ConstructInMemoryUserRepository_Valid_True()
        {
            IUserRepository userRepo = new InMemoryUserRepository();

            Assert.IsNotNull(userRepo);
        }

        [TestMethod]
        public void InMemoryUserRepository_GetUserByEmailValid_True()
        {
            IUserRepository userRepo = new InMemoryUserRepository();

            var user1 = userRepo.Get("user1@gmail.com");

            Assert.IsNotNull(user1);
            Assert.AreEqual(user1.Email, "user1@gmail.com");
            Assert.AreEqual(user1.Password, "secret1");
            Assert.AreEqual(user1.Salt, "salt");
            Assert.AreEqual(user1.Username, "user1");
        }

        [TestMethod]
        public void InMemoryUserRepository_GetUserByEmailNonExistant_True()
        {
            IUserRepository userRepo = new InMemoryUserRepository();

            var user1 = userRepo.Get("user1@gmail.com");

            Assert.IsNotNull(user1);
            Assert.AreEqual(user1.Email, "user1@gmail.com");
            Assert.AreEqual(user1.Password, "secret1");
            Assert.AreEqual(user1.Salt, "salt");
            Assert.AreEqual(user1.Username, "user1");
        }
    }
}
