using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketConsole.Service.Concrete
{
    public class MenuService
    {
        public static MarketService marketService = new MarketService();

        public static void MenuAddNewProduct()
        {
            try
            {
                Console.WriteLine("Enter product name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter product price:");
                decimal price = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter quantuty:");
                int quantity = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Category:");
                string category = Console.ReadLine();

                marketService.AddProduct(name, price, quantity, category);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, error. {ex.Message}");

            }
       
        }
 

        public static void MenuUpdateProduct()
        {
            try
            {
                Console.WriteLine("Enter Id:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter product name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter product price:");
                decimal price = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter quantuty:");
                int quantity = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Category:");
                string category = Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuRemoveProduct()
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuShowAllProducts()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuShowProductsByCategory()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuShowProductsByPriceRange()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuSearchProductsByName()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuAddNewSale()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuReturningAnyProductOnSale()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuRemoveSale()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuShowAllSales()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuDisplayOfSalesAccordingToTheGivenDateRange()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuDisplayOfSalesAccordingToTheGivenAmountRange()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuShowingSalesOnaGivenDate()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuShowingTheInformationOfTheGivenIdMainlyTheSalesWithThatId()

        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
      
     
        }     

    }


}



    



