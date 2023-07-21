﻿using MarketConsole.Helper;
using MarketConsole.Service.Concrete;
using System.ComponentModel.Design;

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



                while (!int.TryParse(Console.ReadLine(), out option)) ;
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
                        MenuService.Exit();
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;

                }
            } while (option != 0);






        }
    }
}