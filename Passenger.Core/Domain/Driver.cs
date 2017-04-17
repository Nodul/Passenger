using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Core.Domain
{
    public class Driver // aggregate root
    {
        public Guid UserId { get; protected set; }

        public Vehicle Vehicle { get; protected set; }

        public IEnumerable<Route> Routes { get; protected set; }

        public IEnumerable<DailyRoute> DailyRoutes { get; protected set; }


        protected Driver()
        {

        }

        public Driver(Guid userID, Vehicle vehicle, IEnumerable<Route> routes, IEnumerable<DailyRoute> dailyRoutes)
        {
            if (userID == Guid.Empty) throw new ArgumentException("Driver cannot accept empty userID");
            else UserId = userID;

            if (vehicle == null) throw new ArgumentNullException("Driver cannot accept null Vehicle");
            else Vehicle = vehicle; //Vehicle.Create();

            if (routes == null) throw new ArgumentNullException("Driver cannot accept null routes IEnumerable");
            else Routes = routes;

            if (dailyRoutes == null) throw new ArgumentNullException("Driver cannot accept null dailyRoutes IEnumerable");
            else DailyRoutes = dailyRoutes;

        }
    }
}
