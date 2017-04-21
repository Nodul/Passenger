using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Passenger.Api;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Tests.EndToEnd.Controllers
{
    public abstract class ControllerTestBase
    {
        protected readonly TestServer Server;
        protected readonly HttpClient Client;

        protected ControllerTestBase()
        {
            Server = new TestServer(new WebHostBuilder()
                                        .UseStartup<Startup>());
            Client = Server.CreateClient();
        }

        protected static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            // the 3rd arguments lets the server know we want json. If we wanted xml it would be application/xml
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
