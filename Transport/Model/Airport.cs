using System;
namespace Transport
{
    public class Airport
    {
        public string id { get; set; }
        public string city { get; set; }

        public Airport(string id, string city)
        {
            this.id = id;
            this.city = city;
        }

    }
}
