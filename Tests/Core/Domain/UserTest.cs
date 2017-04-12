using Microsoft.VisualStudio.TestTools.UnitTesting;
using Passenger.Core.Domain;
using System;
using System.Collections.Generic;

namespace Tests.Core.Domain
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void ConstructUser_Valid_True()
        {
            // Assign
            var email = "test1@mail.com";
            var username = "test1";
            var password = "secret1";
            var salt = "salt1";

            // Act

            var user = new User(email, username, password, salt);
            var UTC = DateTime.UtcNow;

            // Assert
            Assert.AreEqual(user.Email, "test1@mail.com");
            Assert.AreEqual(user.Username, "test1");
            Assert.AreEqual(user.Password, "secret1");
            Assert.AreEqual(user.Salt, "salt1");
            Assert.AreEqual(user.Email, "test1@mail.com");
            Assert.AreEqual(user.Fullname, null);
            Assert.AreEqual(user.CreatedAt, UTC);

        }
        [TestMethod]
        public void ConstructUser_NotLowerCaseEmail_True()
        {
            // Assign
            var email = "TeSt1@mail.Com";
            var username = "test1";
            var password = "secret1";
            var salt = "salt1";

            // Act
            var user = new User(email, username, password, salt);
            var UTC = DateTime.UtcNow;

            // Assert
            Assert.AreEqual(user.Email, "test1@mail.com");
            Assert.AreEqual(user.Username, "test1");
            Assert.AreEqual(user.Password, "secret1");
            Assert.AreEqual(user.Salt, "salt1");
            Assert.AreEqual(user.Email, "test1@mail.com");
            Assert.AreEqual(user.Fullname, null);
            Assert.AreEqual(user.CreatedAt, UTC);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructUser_AllStringsEmpty_ArgumentException()
        {
            // Assign
            var email = "";
            var username = "";
            var password = "";
            var salt = "";

            // Act
            var user = new User(email, username, password, salt);

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructUser_UsernameEmpty_ArgumentException()
        {
            // Assign
            var email = "user1@mail.com";
            var username = "";
            var password = "pass1";
            var salt = "salt1";

            // Act
            var user = new User(email, username, password, salt);

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructUser_InvalidEmail_ArgumentException()
        {
            // Assign
            var email = "error.address";
            var username = "user1";
            var password = "pass1";
            var salt = "sal1";

            // Act
            var user = new User(email, username, password, salt);
            var UTC = DateTime.UtcNow;

            // Assert

        }
        [TestMethod]
        public void ConstructUsers_AreGuidsDifferent_True()
        {
            // Assign
            var email = "good@email.com";
            var username = "user1";
            var password = "pass1";
            var salt = "sal1";

            // Act
            List<User> users = new List<User>()
            {
                new User(email, username, password, salt),
                new User(email, username, password, salt),
                new User(email, username, password, salt),
                new User(email, username, password, salt),
                new User(email, username, password, salt)
            };

            // Assert
            for(int i = 1; i < users.Count; i++)
            {
                Assert.AreNotEqual(users[0].Id,users[i].Id);
            }

        }

    }
}
