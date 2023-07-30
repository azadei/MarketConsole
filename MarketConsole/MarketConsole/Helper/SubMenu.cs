using MarketConsole.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MarketConsole.Helper
{
    public class Submenu
    {
        public static void ProductHandlingSubMenu()
        {

            int option;

            do

            {
                Console.WriteLine("1. Add new product");
                Console.WriteLine("2. Update product");
                Console.WriteLine("3. Remove product");
                Console.WriteLine("4. Show all products");
                Console.WriteLine("5. Show products by category");
                Console.WriteLine("6. Show products by price range");
                Console.WriteLine("7. Search products by name");
                Console.WriteLine("0. Go back");
                Console.WriteLine("------------------------");
                Console.WriteLine("Please, select an option:");
                Console.WriteLine("------------------------");

                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Please, enter a valid option:");
                    Console.WriteLine("------------------------");
                }

                switch (option)
                {
                    case 1:
                        MenuService.MenuAddNewProduct();
                        break;
                    case 2:
                        MenuService.MenuUpdateProduct();
                        break;
                    case 3:
                        MenuService.MenuRemoveProduct();
                        break;
                    case 4:
                        MenuService.MenuShowAllProducts();
                        break;
                    case 5:
                        MenuService.MenuShowProductsByCategory();
                        break;
                    case 6:
                        MenuService.MenuShowProductsByPriceRange();
                        break;
                    case 7:
                        MenuService.MenuSearchProductsByName();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;
                }

            }   while (option != 0);
        }

        public static void ProductSalesSubmenu()
        {
            int option;

            do
            {
                Console.WriteLine("1. Add new sale");
                Console.WriteLine("2. Returning any product on sale");
                Console.WriteLine("3. Remove sale");
                Console.WriteLine("4. Show all sales");
                Console.WriteLine("5. Show sales by date range");
                Console.WriteLine("6. Show sales by amount range");
                Console.WriteLine("7. Showing sales on a given date");
                Console.WriteLine("8. Show sales by give Id");
                Console.WriteLine("0. Go Back");
                Console.WriteLine("------------------------");
                Console.WriteLine("Please, select an option:");
                Console.WriteLine("------------------------");

                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Please, enter a valid option:");
                    Console.WriteLine("------------------------");
                }

                switch (option)
                {
                    case 1:
                        MenuService.MenuAddNewSale();
                        break;
                    case 2:
                        MenuService.MenuReturningAnyProductOnSale();
                        break;
                    case 3:
                        MenuService.MenuRemoveSale();
                        break;
                    case 4:
                        MenuService.MenuShowAllSales();
                        break;
                    case 5:
                        MenuService.MenuShowSalesByDateRange();
                        break;
                    case 6:
                        MenuService.MenuShowSalesByAmountRange();
                        break;
                    case 7:
                        MenuService.MenuShowingSalesOnaGivenDate();
                        break;
                    case 8:
                        MenuService.MenuShowSalesByGivenId();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("No such option!");
                        break;
                }

            } while (option != 0);
        }
        
    }
}
