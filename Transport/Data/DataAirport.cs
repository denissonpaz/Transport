using System;
using System.Collections.Generic;
namespace Transport
{
    public class DataAirport
    {
        public List<Airport> Load()
        {
            List<Airport> airports;
            string jsonString = JsonHelper.ReadFile(@"Data\Airports.json");
            airports = JsonHelper.DeserializeToList<Airport>(jsonString);
            return airports;
        }
    }
}
