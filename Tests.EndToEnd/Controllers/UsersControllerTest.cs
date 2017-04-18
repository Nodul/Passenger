using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Passenger.Api;
using Newtonsoft.Json;
using Passenger.Infrastructure.DTO;
using System.Threading.Tasks;
using Passenger.Infrastructure.Commands.Users;

namespace Tests.EndToEnd.Controllers
{
    [TestClass]
    public class UsersControllerTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UsersControllerTest()
        {
            _server = new TestServer(new WebHostBuilder()
                                        .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [TestMethod]
        public async Task CheckIfUserExists_ValidEmail_True()
        {
            var email = "user2@gmail.com";
            var user = await GetUserAsync(email);

            Assert.AreEqual("user2@gmail.com", user.Email);
            // Assert.AreEqual("Hello world",responseString);          
        }

        [TestMethod]
        public async Task CheckIfUserExists_InvalidEmail_404()
        {
            var email = "user-500@gmail.com";
            var response = await _client.GetAsync($"users/{email}");
            Assert.AreEqual(System.Net.HttpStatusCode.NotFound, response.StatusCode);

        }
        [TestMethod]
        public async Task CheckIfUserWasCreatedSuccesfully_ValidEmail_201()
        {
            var email = "test201@gmail.com";
            var request = new CreateUser() // might be anonymous as well, just make sure the fields match
            {
                Email = email,
                Username = "test201",
                Password = "secret_201"

            };
            var payload = GetPayload(request);
            var response = await _client.PostAsync("users",payload);
            Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);
            Assert.AreEqual($"users/{request.Email}",response.Headers.Location.ToString());

            var user = await GetUserAsync(request.Email);
            Assert.AreEqual("test201@gmail.com", request.Email);

        }

        private async Task<UserDTO> GetUserAsync(string email)
        {
            var response = await _client.GetAsync($"users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserDTO>(responseString);
        }

        private static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            // the 3rd arguments lets the server know we want json. If we wanted xml it would be application/xml
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
