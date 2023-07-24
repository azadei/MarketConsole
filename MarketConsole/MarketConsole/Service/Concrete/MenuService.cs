using MarketConsole.Data.Common.Enums;
using MarketConsole.Data.Models;
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
                Category category = (Category)Enum.Parse(typeof(Category), Console.ReadLine(),true);

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

                Console.WriteLine("Enter quantity:");
                int quantity = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Category:");
                Category category = (Category)Enum.Parse(typeof(Category), Console.ReadLine());

                marketService.UpdateProduct(id, name, price, quantity, category);

                Console.WriteLine("Updated successfully");
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
                Console.WriteLine("Enter product Id:");
                int id = int.Parse(Console.ReadLine());

                marketService.RemoveProduct(id);
                Console.WriteLine("Removed succesfully");
            }
            catch (Exception ex)    
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuShowAllProducts()
        {
             var products = marketService.GetProducts();

                if (products.Count == 0)
                {
                    Console.WriteLine("No products yet.");
                    return;
                }

                foreach (var product in products)
                {
                    Console.WriteLine($"Id: {product.Id} | Name: {product.Name} | Price: {product.Price} | Quantity: {product.Quantity} | Category: {product.Category}");

                }

        }

        public static void MenuShowProductsByCategory()
        {
            try
            {
                Console.WriteLine("Enter category:");
                Category category = (Category)Enum.Parse(typeof(Category), Console.ReadLine());

                var foundProducts = marketService.ShowProductsByCategory(category);  
                
                if (foundProducts.Count == 0)
                {
                    Console.WriteLine("No products found");
                    return;
                }

                foreach (var product in foundProducts)
                {
                    Console.WriteLine($"Id: {product.Id} | Name: {product.Name} | Price: {product.Price} | Quantity: {product.Quantity} | Category: {product.Category}");
                }

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
                Console.WriteLine("Enter min price:");
                decimal minPrice = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter min price:");
                decimal maxPrice = decimal.Parse(Console.ReadLine());

                var foundProducts = marketService.ShowProductsByPriceRange(minPrice, maxPrice);

                if (foundProducts.Count == 0)
                {
                    Console.WriteLine("No Products found");
                    return;
                }

                foreach (var product in foundProducts)
                {
                    Console.WriteLine($"Id: {product.Id} | Name: {product.Name} | Price: {product.Price} | Quantity: {product.Quantity} | Category: {product.Category}");
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine($"Oops, error. {ex.Message}");
            }
           
        }

        public static void MenuSearchProductsByName()
        {
            try
            {
                Console.WriteLine("Write product name:");
                string name = Console.ReadLine();

                var foundProducts = marketService.SearchProductsByName(name);

                if (foundProducts == null)
                {
                    Console.WriteLine("No products found");
                    return;
                }

                foreach(var product in foundProducts)
                {
                    Console.WriteLine($"Id: {product.Id} | Name: {product.Name} | Price: {product.Price} | Quantity: {product.Quantity} | Category: {product.Category}");
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        public static void MenuAddNewSale()
        {
            try
            {
                Console.WriteLine("Write an Id of product");
                int id = int.Parse(Console.ReadLine());
                
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
                Console.WriteLine("Enter sale's Id:");
                int id = int.Parse(Console.ReadLine());

                marketService.RemoveProduct(id);

                Console.WriteLine("Sale removed succesfully");
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



    



