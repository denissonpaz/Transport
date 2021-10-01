using System;
using System.Collections.Generic;
namespace Transport
{
    public class Menu : IMenu
    {
        private Manager manager = new Manager();
        public bool MainMenu()
        {
            //Console.Clear();
            Console.WriteLine("Transport Application");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("[1] - Load the flight schedule");
            Console.WriteLine("[2] - List out the loaded flight schedule");
            Console.WriteLine("[3] - List out the loaded flight schedule Showing the Cities");
            Console.WriteLine("[4] - Generate flight itineraries");
            Console.WriteLine("[5] - Exit Application");

            switch (Console.ReadLine())
            {
                case "1":
                    manager.LoadFlights();
                    return true;
                case "2":
                    manager.ListOut(false);
                    return true;
                case "3":
                    manager.ListOut(true);
                    return true;
                case "4":
                    manager.GenerateItinerary();
                    return true;
                case "5":
                    return false;
                default:
                    return true;
            }
        }
    }

    
}
