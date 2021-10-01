using System;

namespace Transport
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            var menu = new Menu();
            while (showMenu)
            {
                showMenu = menu.MainMenu();
            }
        }
    }
}
