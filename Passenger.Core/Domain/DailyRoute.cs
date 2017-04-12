using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Core.Domain
{
    public class DailyRoute
    {
        public Guid Id { get; protected set; }

        public Route Route { get; protected set; }

        // Can't validate count of this, but this is how it was shown on the tutorial.
        public IEnumerable<PassengerNode> PassengerNodes { get; protected set; }

        protected DailyRoute()
        {

        }

        public DailyRoute(Route route, IEnumerable<PassengerNode> passengerNodes)
        {
            Route = route;
            PassengerNodes = passengerNodes;
        }
    }

   
}
