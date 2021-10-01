namespace Transport
{
    public class Order
    {
        public string id { get; }
        public Airport destination { get; set; }

        public Order(string id, Airport destination)
        {
            this.id = id;
            this.destination = destination;
        }

    }
}
