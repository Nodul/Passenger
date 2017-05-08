using Microsoft.VisualStudio.TestTools.UnitTesting;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Infrastructure.DTO
{
    [TestClass]
    public class UserDTOTest
    {
        [TestMethod]
        public void ConstructUserDTO_Valid_True()
        {
            User user = new User("test@mail.com","test","pass1","salt1",Roles.User);
            UserDTO uDTO = new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                Fullname = user.Fullname,
                Username = user.Username
            };

            Assert.AreEqual(user.Username,uDTO.Username);
            Assert.AreEqual(user.Email, uDTO.Email);
            Assert.AreEqual(user.Fullname, uDTO.Fullname);
            Assert.AreEqual(user.Id, uDTO.Id);
        }
    }
}
