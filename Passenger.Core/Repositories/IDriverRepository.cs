﻿using Passenger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passenger.Core.Repositories
{
    public interface IDriverRepository : IRepository
    {
        Task<Driver> GetAsync(Guid userId);

        Task<IEnumerable<Driver>> GetAllAsync();

        Task AddAsync(Driver driver);

        Task RemoveAsync(Guid userId);

        Task UpdateAsync(Driver driver);


    }
}
