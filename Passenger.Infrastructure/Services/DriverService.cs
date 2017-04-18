using Passenger.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Passenger.Infrastructure.DTO;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Domain;

namespace Passenger.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepo;
        private readonly IMapper _mapper;

        public DriverService(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepo = driverRepository;
            _mapper = mapper;
        }

        public async Task<DriverDTO> GetAsync(Guid userId)
        {
            var driver = await _driverRepo.GetAsync(userId);

            return _mapper.Map<Driver, DriverDTO>(driver);
        }
    }
}
