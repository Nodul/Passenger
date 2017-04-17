using System;
using System.Collections.Generic;
using System.Text;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using System.Linq;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryDriverRepository : IDriverRepository
    {
        private static HashSet<Driver> _drivers = new HashSet<Driver>();

        public void Add(Driver driver)
        {
            _drivers.Add(driver);
        }

        public Driver Get(Guid userId)
        {
            return _drivers.Single(x => x.UserId == userId);
        }

        public IEnumerable<Driver> GetAll()
        {
            return _drivers;
        }

        public void Remove(Guid userId)
        {
            _drivers.Remove(this.Get(userId));
        }

        public void Update(Driver driver)
        {
            // hmmm
        }
    }
}
