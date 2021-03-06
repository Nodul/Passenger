﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Passenger.Infrastructure.Commands;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands.Drivers;

namespace Passenger.Api.Controllers
{
    public class DriversController : ApiControllerBase
    {
        public DriversController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {

        }

        [HttpPost]
        public async Task<IActionResult> Put([FromBody] CreateDriver command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }
    }
}
