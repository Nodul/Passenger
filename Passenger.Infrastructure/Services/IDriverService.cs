using Passenger.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Services
{
    public interface IDriverService
    {
        Task<DriverDTO> GetAsync(Guid userId);
    }
}
