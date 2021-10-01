using System;
using System.Collections.Generic;

namespace Transport
{
    public class Manager
    {

        public List<Flight> flights { get; set; }
        public List<Airport> airports { get; set; }
        public List<Order> orders { get; set; }
        public void LoadFlights()
        {
            DataFlight dataFlight = new DataFlight();
            flights = dataFlight.Load();
            Console.WriteLine("Flights loaded successfully!");
        }

        private void LoadAirports()
        {
            DataAirport dataAirport = new DataAirport();
            airports = dataAirport.Load();
        }

        private void LoadOrders()
        {
            DataOrder dataOrder = new DataOrder();
            orders = dataOrder.Load(airports);
        }

        private void AddOrdersToFlight()
        {
            string schedule;
            if (Helper.IsListNotEmpty<Flight>(flights) && Helper.IsListNotEmpty<Order>(orders))
            {
                foreach (var order in orders)
                {
                    schedule = "Flight: not scheduled";
                    foreach (var flight in flights)
                    {
                        if (flight.AddOrder(order)) {
                            schedule = flight.PrintFlight(true);
                            break;
                        }

                    }
                    Console.WriteLine("order: " + order.id + ", " + schedule);
                }
            } else
            {
                Console.WriteLine("No Flight loaded Nor Order available.");
            }
        }

        public void ListOut(bool city)
        {

            
            if (Helper.IsListNotEmpty<Flight>(flights))
            {
                foreach (var flight in flights)
                {
                    Console.WriteLine(flight.PrintFlight(city));
                }
            }else
            {
                Console.WriteLine("No Flight loaded.");
            }
        }

        public void GenerateItinerary()
        {
            this.LoadAirports();
            this.LoadOrders();
            this.AddOrdersToFlight();
        }

       
    }
}
