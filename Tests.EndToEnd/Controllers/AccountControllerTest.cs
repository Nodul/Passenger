using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Passenger.Api;
using Passenger.Infrastructure.Commands.Users;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tests.EndToEnd.Controllers
{
    [TestClass]
    public class AccountControllerTest : ControllerTestBase
    {
        [TestMethod]
        public async Task ChangeUserPassword_ValidCurrentPassword_Changed()
        {
            var command = new ChangeUserPassword()
            {
                CurrentPassword = "secret",
                NewPassword = "newSecret"
            };
            var payload = GetPayload(command);
            var response = await Client.PutAsync("account/password", payload);
            Assert.AreEqual(System.Net.HttpStatusCode.NoContent, response.StatusCode);
        }

    }
}
