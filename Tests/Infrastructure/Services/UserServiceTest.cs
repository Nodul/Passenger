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
        public async Task RegisterAsyncInvokesAddAsyncUserService_Once_True()
        {
            var userRepoMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepoMock.Object,mapperMock.Object);
            await userService.RegisterAsync("user0@gmail.com","user0","password",Roles.User);

            // we are veryfing that our userService.RegisterAsync called AddAsync once
            userRepoMock.Verify(x => x.AddAsync(It.IsAny<User>()),Times.Once);
        }

        [TestMethod]
        public async Task GetAsyncInvokesGetAsyncOnUserRepository_Once_True()
        {
            var userRepoMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepoMock.Object, mapperMock.Object);
            await userService.RegisterAsync("user0@gmail.com", "user0", "password",Roles.User);

            userRepoMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once);

        }

        [TestMethod]
        public async Task GetAsync_UserExists_True()
        {
            // Assign
            var userRepoMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepoMock.Object, mapperMock.Object);
            // Act
            await userService.GetAsync("user1@gmail.com");

            var user = new User("user1@gmail.com", "user1", "pass1", "salt1",Roles.User);
            // Assert
            userRepoMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(user);
            userRepoMock.Verify(x => x.GetAsync(It.IsAny<string>()),Times.Once);
        }

        [TestMethod]
        public async Task GetAsync_UserDoesNotExist_Null()
        {
            var userRepoMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepoMock.Object, mapperMock.Object);
            // Act
            await userService.GetAsync("user1@gmail.com");

            // Assert
            userRepoMock.Setup(x => x.GetAsync("user1@gmail.com")).ReturnsAsync(() => null);
            userRepoMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once);
        }


    }
}
