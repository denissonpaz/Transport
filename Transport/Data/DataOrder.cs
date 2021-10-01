using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;
namespace Transport
{
    public class DataOrder
    {
        List<Order> orders;
        public List<Order> Load(List<Airport> airports)
        {
            Dictionary<string, string> _orders = new Dictionary<string, string>();
            orders = new List<Order>();
            Order order;

            string jsonString = JsonHelper.ReadFile(@"Data\Orders.json");
            JObject o1 = JObject.Parse(jsonString);
            
            foreach (JProperty property in o1.Properties())
            {
                JObject o2 = JObject.Parse(property.Value.ToString());
                foreach (JProperty innerProperty in o2.Properties())
                {
                    //_orders.Add(property.Name, innerProperty.Value.ToString());

                    var airport = airports.Where(airport => airport.id == innerProperty.Value.ToString()).FirstOrDefault();
                    order = new Order(property.Name, airport);
                    orders.Add(order);

                }
            }

            return orders;
        }
    }
}
