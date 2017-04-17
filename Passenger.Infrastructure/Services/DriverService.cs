using Passenger.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepo;

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepo = driverRepository;
        }

        public DriverDTO Get(Guid userId)
        {
            var driver = _driverRepo.Get(userId);

            return new DriverDTO()
            {

            };
        }
    }
}
