﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Core.Domain
{
    public class Node
    {
        // public Guid Id { get; protected set; } // Not needed for now, as far as I can tell

        public string Address { get; protected set; }

        public double Longitude { get; protected set; }

        public double Latitude { get; protected set; }


    }
}
