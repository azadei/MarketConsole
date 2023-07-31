using MarketConsole.Data.Common.Enums;
using MarketConsole.Data.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ConsoleTables;

namespace MarketConsole.Service.Concrete
{
    public class MarketService : IMarketService
    {
        private List<Product> products;
        private List<Sales> sales;
        private List<SaleItem> saleItems;
        private Sales sale;

        public MarketService()
        {
            products = new();
            sales = new();
            saleItems = new();
        }
        
        public List<Product> GetProducts()
        {
            return products;
        }

        public List<Sales> GetSales()
        {
            return sales;
        }

        public List<SaleItem> GetSaleItem()
        {
            return saleItems;
        }

        public Sales GetSaleById(int saleId)
        {
            return sales.FirstOrDefault(s => s.Id == saleId);
        }

        public void AddProduct(string name, decimal price, int quantity, Category category)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name can't be empty!");                 //If the name is empty, an error will occur

            if (price <= 0) throw new ArgumentOutOfRangeException("Price can't be negative or 0!");           //If the price is 0 or negative, there will be an error       

            var product = new Product(name, price, quantity, category);

            products.Add(product);
        }

        public void UpdateProduct(int id, string name, decimal price, int quantity, Category category)
        {
            if (id < 0) throw new ArgumentOutOfRangeException("Id can't be negative!");                       //if id is 0 or negative, there will be an error

            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name can't be empty!");                 //check name. error if will be empty

            if (price < 0) throw new ArgumentOutOfRangeException("Price can't be negative!");                 //chech price. error if 0 or negative

            if (quantity < 0) throw new ArgumentOutOfRangeException("Quantity can't be negative!");           //check quantity. error if negative

            if (category == null) throw new Exception("Category can't be empty!");                            //check category. error if empty

            var existingProduct = products.FirstOrDefault(x => x.Id == id);                                   //finding products with the given ID in product list

            if (existingProduct == null) throw new Exception("Product not found!");                           //if the given Id not found, throwing an exception

            existingProduct.Id = id;
            existingProduct.Name = name;
            existingProduct.Price = price;                                                          //updating the details of product with the new values
            existingProduct.Quantity = quantity;
            existingProduct.Category = category;
        }

        public void RemoveProduct(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException("Id can't be negative!");             //check id, if not negative

            var existingProduct = products.FirstOrDefault(x => x.Id == id);                         //find products with the give Id in list

            if (existingProduct == null) throw new Exception("Not found!");                         //if product with give id not found, throwing an exception

            products = products.Where(x => x.Id != id).ToList();                                    //remove products with given id from product list
        }

        public List<Product> ShowProductsByCategory(Category category)                              
        {
            if (category == null) throw new Exception("Category can't be empty!");                  //check category, exception if null

            var foundProducts = products.Where(x => x.Category == category).ToList();               //finding product with given category 

            return foundProducts;                                                                   //return list of product with given category
        }

        public List<Product> ShowProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            if (minPrice > maxPrice) throw new Exception("Min price can't be more than Max date!"); //check for price that min price is not greater than max price

            return products.Where(x => x.Price >= minPrice && x.Price <= maxPrice).ToList();        //return list of products that fall within the provided price range
        }

        public List<Product> SearchProductsByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name can't be empty");        //check for name. if null or empty, whitespace throwing an exception

            var foundProducts = products.Where(x => x.Name.ToLower().Trim() == name.ToLower().Trim()).ToList();     //filtering product list with linq's where method

            return foundProducts;                                                                   //returning list of products that match the provided name
        }

        public void AddNewSale(int productid, int quantity, DateTime Now)
        {
            List<SaleItem> tempItems = new List<SaleItem>();

            int option;

            do
            {
                var product = products.Find(p => p.Id == productid);                                //finding products wiht the given product Id in the product list

                if (quantity <= 0)                                                                  //check if the entered quantity is valid
                {
                    Console.WriteLine("Quantity must be greater than 0.");
                }
                else if (product == null)                                                           //check if product with the given id is found in the list
                {
                    Console.WriteLine("Product not found.");
                }
                else if (product.Quantity < quantity)                                               //check if there is enought product in stock
                {
                    Console.WriteLine("Not enough quantity in stock.");
                }
                else
                {
                    var price = product.Price * quantity;                                           //calculating the total price for the quantity of the product
                    product.Quantity -= quantity;                                                   //reducing the quantity of the product in stock

                    var saleItem = new SaleItem(product, quantity);
                    tempItems.Add(saleItem);                                                        //creating a new sale item

                    Console.WriteLine("Product added to the sale.");
                }

                Console.WriteLine("Do you want to add one more product?");                          //asking from user if they want to add one more product to sale
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");

                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Please, enter a valid option:");
                    Console.WriteLine("Enter option again");
                }

                if (option == 1)
                {
                    Console.WriteLine("Enter product id");
                    productid = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the quantity:");
                    quantity = int.Parse(Console.ReadLine());
                }

            } while (option == 1);

            if (tempItems.Count > 0)                                                            //if at least one product is added to sale add it to the sales list
            {
                decimal sum = tempItems.Sum(item => item.Quantity * item.SalesProduct.Price);       //calculating total sum and quantity 
                int totalQuantity = tempItems.Sum(item => item.Quantity);

                var sale = new Sales("Sale", sum, totalQuantity, Now, tempItems);                   //creatin a new sale 
                sales.Add(sale);                                                                    //add new sale to list of sales

                Console.WriteLine("_______________");
                Console.WriteLine("Sale completed.");
                Console.WriteLine("_______________");
            }
            else
            {
                Console.WriteLine("Sale canceled, no products added.");                          //if no products inform the user that sale canceled
            }
        }

        public void ReturnProductFromSale(int saleId, int productIdToReturn, int quantityToReturn)
        {
            var sale = sales.FirstOrDefault(s => s.Id == saleId);                                   //findig sale with given id

            if (sale == null)                                                                       //if sale wuth given id not found throw an exception
                throw new Exception("Sale not found");

            var itemToReturn = sale.Items.FirstOrDefault(i => i.SalesProduct.Id == productIdToReturn);   //find saleItem to return from sale on the productIdtReturn

            if (itemToReturn == null)
                throw new Exception("Product not found in the sale");                                       //if the saleItem not found in sale throw an exception

            if (quantityToReturn > itemToReturn.Quantity)                                                   //check if quantity to return more than quantity in sale
                throw new Exception("Quantity to return is greater than the quantity in the sale");             

            var product = products.FirstOrDefault(p => p.Id == productIdToReturn);                          //finding product with the given productIdtoReturn in list

            if (product == null)                                                                            //if product with given Id is not found throw an exception
                throw new Exception("Product not found");

            product.Quantity += quantityToReturn;                                                   //return product to stock 
            itemToReturn.Quantity -= quantityToReturn;                                              //update quantity of returned product in the sale 

            sale.TotalSum -= product.Price * quantityToReturn;                                      //update total sum and total quantity after return
            sale.Quantity -= quantityToReturn;

            Console.WriteLine($"Returned {quantityToReturn} of {product.Name} from the sale.");     //inform user about succesfully return of product from the sale
        }

        public void RemoveSale(int id)
        {
            if (id < 0) throw new Exception("Id is negative!");                                     //check Id if not negative

            var saleIndex = sales.FirstOrDefault(x => x.Id == id);                                  //find sale with given Id
            if (saleIndex == null) throw new Exception("Sale not found!");                          //if sale with give id not found throw exception

            foreach (var item in saleIndex.Items)
            {
                var product = products.FirstOrDefault(p => p.Id == item.SalesProduct.Id);           //find product with saleItems product id in the product list
                if (product == null) throw new Exception("Product Is null");                        //if product not found throw an exception
                product.Quantity += item.Quantity;                                                  //add the quantity of saleItem back to the product's quantity in stock
            }
            sales.Remove(saleIndex);                                                                //remove sale from the sale list
        }

        public void ShowAllSales(int id, decimal price, int quantity, DateTime dateTime)
        {
            if (sales.Count == 0)                                                                    //check if there are any sales in sale list
            {
                Console.WriteLine("No sales yet");                                                   //if there are no sales show a message that there are no sales
            }

            foreach (var sale in sales)                                                              //loop through each sale and show its details
            {
                Console.WriteLine(sale);
            }
        }

        public List<Sales> ShowSaleByDateRange(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)                                                                    //check for teh date range ensuring start date is not later than end date
                   throw new Exception("The start date cannot be later than the end date.");           

            return sales.Where(s => s.Date >= startDate && s.Date <= endDate).ToList();                 //check sales list using linq where method based on the provided date range
        }

        public List<Sales> ShowSalesOnGivenDate(DateTime date)
        {
            return sales.Where(s => s.Date.Date == date.Date).ToList();                                 //check sales list using linq where method based on the provided date
        }

        public List<Sales> ShowSalesByAmountRange(decimal minamount, decimal maxamount)
        {
            if (minamount > maxamount) throw new Exception("The min amount can't be more than max amount");         //check for amount range ensuring the min amount is not greater than max amount

            return sales.Where(s => s.TotalSum >= minamount && s.TotalSum <= maxamount).ToList();         //return the list of sales within provided amount range
        }

        public Sales ShowSalesByGivenId(int saleId)
        {
            return sales.FirstOrDefault(s => s.Id == saleId);                                             //return the list of sales with given Id
        }
    }
}
