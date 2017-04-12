using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Core.Domain
{
    public class Passenger
    {
        public Guid Id { get; protected set; }

        public Guid UserId { get; protected set; }

        public Node Address { get; protected set; }

        protected Passenger()
        {

        }

        public Passenger(Guid userId, Node address)
        {
            Id = Guid.NewGuid();

            if (userId != Guid.Empty) UserId = userId;
            else throw new ArgumentException("Passenger cannot have empty UserId");

            if (address != null) Address = address;
            else { throw new ArgumentException("Passenger cannot have empty address node"); }
        }
    }
}
