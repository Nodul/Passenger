using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Infrastructure.Commands.Drivers
{
    public class CreateDriver : ICommand
    {
        public Guid UserID { get; set; }
        public DriverVehicle Vehicle { get; set; }


        public class DriverVehicle
        {
            public string Brand { get; protected set; }

            public string Name { get; protected set; }

            public int Seats { get; protected set; }
        }
    }
}
