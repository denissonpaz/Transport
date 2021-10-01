using System;
using System.Collections.Generic;
namespace Transport
{
    public class DataFlight
    {
        public List<Flight> Load()
        {
            List<Flight> flights;
            string jsonString = JsonHelper.ReadFile(@"Data\Flights.json");
            flights = JsonHelper.DeserializeToList<Flight>(jsonString);
            return flights;
        }
    }
}
