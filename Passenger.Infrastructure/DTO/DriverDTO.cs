using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Infrastructure.DTO
{
    public class DriverDTO
    {
        public Guid UserId { get; protected set; }

        // Separate DTOs for the above thingies

        //public Vehicle Vehicle { get; protected set; }

        //public IEnumerable<Route> Routes { get; protected set; }

        //public IEnumerable<DailyRoute> DailyRoutes { get; protected set; }
    }
}
