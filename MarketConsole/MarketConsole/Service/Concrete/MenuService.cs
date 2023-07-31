using MarketConsole.Data.Common;
using MarketConsole.Data.Common.Enums;
using MarketConsole.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MarketConsole.Service.Concrete
{
    public class MenuService : BaseEntity
    {
        public static MarketService marketService = new MarketService();
        private List<Sales> sales;
        private List<SaleItem> saleItems;

        public MenuService(List<Sales> sales, List<SaleItem> saleItems)
        {
            this.sales = sales;
            this.saleItems = saleItems;
        }

        public static void MenuAddNewProduct()
        {
            try
            {   
                Console.WriteLine("Enter product name:");                     //ask user to enter the necessary information to create a new product
                string name = Console.ReadLine();

                Console.WriteLine("Enter product price:");
                decimal price = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter quantuty:");
                int quantity = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Category:");
                Console.WriteLine("__________________________________________");
                Console.WriteLine("Available categories:");
                Console.WriteLine("_____________________");
                Console.WriteLine("Drinks, Foods, Frozenfoods, Meat, Cleaners");
                Console.WriteLine("__________________________________________");
                Category category = (Category)Enum.Parse(typeof(Category), Console.ReadLine(),true);

                marketService.AddProduct(name, price, quantity, category);          //calling the marketService.AddProduct method to add the new product to the system
                Console.WriteLine("_________________________");
                Console.WriteLine("Product added succesfully");
                Console.WriteLine("_________________________");
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
                Console.WriteLine("Enter Id:");                             //ask user to enter the necessary information to update a product
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter product name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter product price:");
                decimal price = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter quantity:");
                int quantity = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Category:");
                Category category = (Category)Enum.Parse(typeof(Category), Console.ReadLine());

                marketService.UpdateProduct(id, name, price, quantity, category);          //calling the marketService.UpdateProduct method to update product to the system

                Console.WriteLine("____________________");
                Console.WriteLine("Updated successfully");                                 //show a success message after update is completed
                Console.WriteLine("____________________");
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
                Console.WriteLine("Enter product Id:");                                   //user must enter the necessary information to remove a product
                int id = int.Parse(Console.ReadLine());

                marketService.RemoveProduct(id);                                          //calling the marketService.RemoveProduct method to remove product to the system
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

                if (products.Count == 0)                                        //check if there are any products in the list
            {
                    Console.WriteLine("No products yet.");                      //if there are no products print a message that there are no products
                return;
                }

                foreach (var product in products)                               //loop through each product in products list and displaying its details
            {
                    Console.WriteLine($"Id: {product.Id} | Name: {product.Name} | Price: {product.Price} | Quantity: {product.Quantity} | Category: {product.Category}");
                }
        }

        public static void MenuShowProductsByCategory()
        {
            try
            {
                Console.WriteLine("Enter category:");                                                       //ask user to enter a category for filtering the products
                Category category = (Category)Enum.Parse(typeof(Category), Console.ReadLine(),true);

                var foundProducts = marketService.ShowProductsByCategory(category);                         //get products from the marketService with the specified category

                if (foundProducts.Count == 0)                                                               //check if there are any products found for the specified category
                {
                    Console.WriteLine("No products found");                                                 //if no products are found print a message indicating that no products found
                    return;
                }

                foreach (var product in foundProducts)                                                      //loop through each product in the foundProducts list and display its details
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
                Console.WriteLine("Enter min price:");                                          //ask user to enter min price for filtering the products
                decimal minPrice = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter min price:");                                          //ask user to enter max price for filtering the products
                decimal maxPrice = decimal.Parse(Console.ReadLine());

                var foundProducts = marketService.ShowProductsByPriceRange(minPrice, maxPrice);          //get products from marketService with the specified price range

                if (foundProducts.Count == 0)                                                   //check if there are any products found for the specified price range
                {
                    Console.WriteLine("No Products found");                                     //if no products are found display message no products yet
                    return;
                }

                foreach (var product in foundProducts)                                          //looping through each product in the foundProducts list and displaying its details
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

                var foundProducts = marketService.SearchProductsByName(name);            //get products from the marketService that match the specified product name

                if (foundProducts == null)                                               //check if any products were found for the specified name
                {
                    Console.WriteLine("No products found");                              //if no products are found print a message no products found and return from the method
                    return;
                }

                foreach(var product in foundProducts)                                    //looping through each product in the foundProducts list and displaying its details
                {
                    Console.WriteLine($"Id: {product.Id} | Name: {product.Name} | Price: {product.Price} | Quantity: {product.Quantity} | Category: {product.Category}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, error. {ex.Message}");
            }
        }

        public static void MenuAddNewSale()
        {
            try
            {
                Console.WriteLine("Enter product id");                              //ask user to enter product id for add to new sale
                Console.WriteLine("____________");

                int productid = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the quantity:");                           //ask user to enter a quantity of product for new sale
                int quantity = int.Parse(Console.ReadLine());

                marketService.AddNewSale(productid, quantity, DateTime.Now);        //calling the marketService.AddNewSale method to add a new sale
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, error. {ex.Message}");
            }
        }

        public static void MenuReturningAnyProductOnSale()
        {
            try
            {
                Console.WriteLine("Enter check Id:");                               //ask user to enter sale Id
                int saleId = int.Parse(Console.ReadLine());                         

                var foundSale = marketService.GetSaleById(saleId);                  //get the sale with the specified saleId from the marketService

                if (foundSale == null)                                              //check if the sale with the specified saleId exists
                {
                    Console.WriteLine("Sale not found");                            //if the sale is not found print sale not found
                    return;
                }

                Console.WriteLine($"Sale {saleId}");

                Console.WriteLine($"Sale ID: {foundSale.Id} | Total Amount: {foundSale.TotalSum} | Quantity: {foundSale.Quantity} | Date: {foundSale.Date}");
                Console.WriteLine("Items in the sale:");
                foreach (var item in foundSale.Items)
                {
                    Console.WriteLine($"Product ID: {item.SalesProduct.Id} | Product Name: {item.SalesProduct.Name} | Quantuty: {item.Quantity}");
                }
                Console.WriteLine("--------------------");

                Console.WriteLine("Enter product ID to return:");
                int productIdToReturn = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter quantity to return:");
                int quantityToReturn = int.Parse(Console.ReadLine());

                marketService.ReturnProductFromSale(saleId, productIdToReturn, quantityToReturn);   //calling the marketService.ReturnProductFromSale method to return product from sale
                Console.WriteLine("Product returned successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void MenuRemoveSale()
        {
            try
            {
                Console.WriteLine("Enter sale's Id:");                      //ask user to enter sale id
                int id = int.Parse(Console.ReadLine());

                marketService.RemoveSale(id);                               //calling the marketService.RemoveSale method to remove the sa

                Console.WriteLine("Sale removed succesfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuShowAllSales()
        {
            var sales = marketService.GetSales();

            if (sales.Count == 0)                                   //check if there are any sales in the list
            {
                Console.WriteLine("No sales yet.");                 //if there are no sales print a message no sales yet
                return;
            }

            foreach (var sale in sales)                             //show the details of each sale in the list
            {
                Console.WriteLine($"Id: {sale.Id} | Sum: {sale.TotalSum} | Quantity: {sale.Quantity} | Date: {sale.Date} ");
            }
        }

        public static void MenuShowSalesByDateRange()
        {
            try
            {
                Console.WriteLine("Enter start date:");                         //ask user to enter start date
                DateTime startDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter end date:");                           //ask user to enter end date
                DateTime endDate = DateTime.Parse(Console.ReadLine());

                var foundSales = marketService.ShowSaleByDateRange(startDate, endDate);     //get the list of sales with the specified date range from the marketService

                if (foundSales.Count == 0)                                      //check if there are any sales in the foundSales list
                {
                    Console.WriteLine("Sales no found in the given range.");
                    return;
                }

                foreach (var sale in foundSales)                //show the details of each sale in the foundSales list
                {
                    Console.WriteLine($"Check Id: {sale.Id} | Sum: {sale.TotalSum} | Quantity: {sale.Quantity} | Date: {sale.Date}");
                    
                    foreach (var item in sale.Items)            //show the details of each item in the sale
                    {
                        Console.WriteLine($"Id: {item.SalesProduct.Id} | Product Name: {item.SalesProduct.Name} | Quantity: {item.Quantity}");
                    }
                    Console.WriteLine("--------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void MenuShowSalesByAmountRange()
        {
            try
            {
                Console.WriteLine("Write min amount:");                         //ask user to enter min amoutn
                decimal minamount = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Write max amount:");                         //ask user to enter max amount
                decimal maxamount = decimal.Parse(Console.ReadLine());

                var foundSales = marketService.ShowSalesByAmountRange(minamount, maxamount);   //get the list of sales with the specified amount range from the marketService

                if (foundSales.Count == 0)                                      //check if there are any sales in the foundSales list
                {
                    Console.WriteLine("Sales no found in the given range.");    //if there are no sales in the specified amount range print a message sales no found in the given range
                    return;
                }

                foreach (var sale in foundSales)                                //show the details of each sale in the foundSales list
                {
                    Console.WriteLine($"Check Id: {sale.Id} | Sum: {sale.TotalSum} | Quantity: {sale.Quantity} | Date: {sale.Date}");

                    foreach (var item in sale.Items)                            //show the details of each item in the sale
                    {
                        Console.WriteLine($"Id: {item.SalesProduct.Id} | Product Name: {item.SalesProduct.Name} | Quantity: {item.Quantity}");
                    }
                    Console.WriteLine("--------------------");
                }
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
                Console.WriteLine("Enter date:");                       //ask user to enter sale date
                DateTime date = DateTime.Parse(Console.ReadLine());

                var foundSales = marketService.ShowSalesOnGivenDate(date);  //get the list of sales that occurred on the specified date

                if (foundSales.Count == 0)                  //check if there are any sales on the specified date
                {
                    Console.WriteLine($"Sales not found.");
                    return;
                }

                foreach (var sale in foundSales)            //show the details of each sale that occurred on the specified date
                {
                    Console.WriteLine($"Check id: {sale.Id} | Sum: {sale.TotalSum} | Quantity: {sale.Quantity} | Date: {sale.Date}");
                    Console.WriteLine("Products on sale:");
                    foreach (var item in sale.Items)        //ahow the details of each item in the sale that occurred on the specified date
                    {
                        Console.WriteLine($"Sale id: {item.SalesProduct.Id} | Product name: {item.SalesProduct.Name} | Quantity: {item.Quantity}");
                    }
                    Console.WriteLine("--------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void MenuShowSalesByGivenId()

        {
            try
            {
                Console.WriteLine("Enter Id:");                     //ask user to enter sale id
                int saleId = int.Parse(Console.ReadLine());

                var foundSale = marketService.ShowSalesByGivenId(saleId);           //get the sale with the specified id from the marketService

                if (foundSale == null)                              //check if a sale with the specified id was found
                {
                    Console.WriteLine("Sale not found");            //if no sale is found print a message sale not found
                    return;
                }

                Console.WriteLine($"Sale {saleId}");            //show the details of the sale with the specified Id
                Console.WriteLine("__________________________________________________________________________________________________________________");
                Console.WriteLine($"Sale ID: {foundSale.Id} | Total Amount: {foundSale.TotalSum} | Quantity: {foundSale.Quantity} | Date: {foundSale.Date}");

                Console.WriteLine("Items in the sale:");            //show the details of each item in the sale with the specified Id

                foreach (var item in foundSale.Items)       
                {
                    Console.WriteLine($"- Product ID: {item.SalesProduct.Id} | Product Name: {item.SalesProduct.Name} | Quantity: {item.Quantity}");
                }
                Console.WriteLine("--------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}



    



