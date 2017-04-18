using Passenger.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public interface IUserService
    {
        Task<UserDTO> GetAsync(string email);

        Task RegisterAsync(string email, string username, string password);


    }
}
