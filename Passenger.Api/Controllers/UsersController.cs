using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Services;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Settings;

namespace Passenger.Api.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _userService;
        private readonly GeneralSettings _settings;

        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher, GeneralSettings settings) : base(commandDispatcher)
        {
            _settings = settings;
            _userService = userService;         
        }
        // GET api/values/5
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.GetAsync(email);
            if(user == null)
            {
                return NotFound();
            }
            return Json(user);
        }
              

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await CommandDispatcher.DispatchAsync(command);

            // Location: users/user10@email.com
            return Created($"users/{command.Email}", new object());
        }

      

    }
}
