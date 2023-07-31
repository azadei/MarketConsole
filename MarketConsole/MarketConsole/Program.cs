using MarketConsole.Helper;
using MarketConsole.Service.Concrete;
using System.ComponentModel.Design;
using ConsoleTables;

namespace MarketConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            int option;

            do
            {
                Console.WriteLine("1. Product Handling");
                Console.WriteLine("2. Sales Handling");
                Console.WriteLine("0. Exit");
                Console.WriteLine("------------------------");
                Console.WriteLine("Please, select an option:");
                Console.WriteLine("------------------------");


                while (!int.TryParse(Console.ReadLine(), out option));
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Please, enter a valid option:");
                    Console.WriteLine("------------------------");
                }
            
                switch (option)
                {
                    case 1:
                        Submenu.ProductHandlingSubMenu();
                        break;
                    case 2:
                        Submenu.ProductSalesSubmenu();
                        break;
                    case 3:
                        Console.WriteLine("Bye");
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;

                }

            } while (option != 0);

        }
    }
}