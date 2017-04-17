using Passenger.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Core.Domain
{
    public class Vehicle // Value object -> immutable
    {
        public string Brand { get; protected set; }

        public string Name { get; protected set; }

        public int Seats { get; protected set; }

        public static Vehicle Create(string brand, string name, int seats)
        {
            return new Vehicle(brand, name, seats);
        }
        // Good if we want more specialized constructors later
        //public static Vehicle CreateFord(string name, int seats)
        //{
        //    return Create("Ford", name, seats);
        //}

        protected Vehicle()
        {
           
        }

        private Vehicle(string brand, string name, int seats)
        {
            Brand = Validation.ValidateString(brand,false);
            Name = Validation.ValidateString(name,false);
            
            if(seats <= 0)
            {
                throw new ArgumentException("Seats must be equal to or more than 1");
            }
            Seats = seats;
        }

    }
}
