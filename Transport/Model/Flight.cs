using System;
using System.Collections.Generic;

namespace Transport
{
    public class Flight
    {
        
        public int id { get; set; }
        public int day { get; set; }
        public Airport origin { get; set; }
        public Airport destination { get; set; }
        public Plane plane { get; set; }
        private List<Order> orderList { get; set; }


        public Flight(int id, int day, Airport origin, Airport destination, Plane plane)
        {
            this.id = id;
            this.day = day;
            this.origin = origin;
            this.destination = destination;
            this.plane = plane;
            orderList = new List<Order>();
        }

        public bool AddOrder(Order order)
        {
            bool added = false;
            
            if (!IsAtMaxCapacity())
            {
                if (order.destination.id == this.destination.id) {
                    orderList.Add(order);
                    added = true;
                }
            }

            return added;
        }

        public bool IsAtMaxCapacity()
        {
            
            if (this.orderList == null)
            {
                return false;
            } 

            return (this.plane.boxCapacity == this.orderList.Count);
        }

        public override string ToString()
        {
            return PrintFlight(false);
        }

        public string PrintFlight(bool city)
        {
            string propName;
            if (city)
            {
                propName = "city";
            }
            else
            {
                propName = "id";
            }
            
            return "Flight: " + this.id + ", departure: " + Helper.GetPropValue(this.origin, propName) + ", arrival: " + Helper.GetPropValue(this.destination, propName) + ", day: " + this.day;
        }

    }
}
