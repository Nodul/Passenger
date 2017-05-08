using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Core.Domain
{
    public class PassengerNode
    {
        public Node Node { get; protected set; }
        
        public Passenger Passenger { get; protected set; }

        protected PassengerNode()
        {

        }

        protected PassengerNode(Node node, Passenger passenger)
        {
            if (node != null) this.Node = node;
            else throw new ArgumentNullException("PassengerNode cannot accept null Node");

            if (passenger != null) this.Passenger = passenger;
            else throw new ArgumentNullException("PassengerNode cannot accept null Passenger");

        }

        public static PassengerNode Create(Node node, Passenger passenger)
        {
            return new PassengerNode(node, passenger);
        }
    }
}
