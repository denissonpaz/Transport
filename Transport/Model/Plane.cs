namespace Transport
{
    public class Plane
    {
        public string id { get; }
        public int boxCapacity { get; set; }

        public Plane(string id, int boxCapacity)
        {
            this.id = id;
            this.boxCapacity = boxCapacity;
        }

    }
}
