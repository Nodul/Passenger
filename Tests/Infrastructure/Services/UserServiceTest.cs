using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Infrastructure.Services
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public async Task RegisterAsyncShouldInvokeAddAsyncUserService_Once_True()
        {
            var userRepoMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepoMock.Object,mapperMock.Object);
            await userService.RegisterAsync("user0@gmail.com","user0","password");

            // we are veryfing that our userService.RegisterAsync called AddAsync once
            userRepoMock.Verify(x => x.AddAsync(It.IsAny<User>()),Times.Once);
        }
    }
}
