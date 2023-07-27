﻿using MarketConsole.Data.Common.Enums;
using MarketConsole.Data.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public void AddProduct(string name, decimal price, int quantity, Category category)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name can't be empty!");

            if (price <= 0) throw new ArgumentOutOfRangeException("Price can't be negative or 0!");

            var product = new Product(name, price, quantity, category);

            products.Add(product);

        }

        public void UpdateProduct(int id, string name, decimal price, int quantity, Category category)
        {
            if (id < 0) throw new ArgumentOutOfRangeException("Id can't be negative!");

            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name can't be empty!");

            if (price < 0) throw new ArgumentOutOfRangeException("Price can't be negative!");

            if (quantity < 0) throw new ArgumentOutOfRangeException("Quantity can't be negative!");

            if (category == null) throw new Exception("Category can't be empty!");

            var existingProduct = products.FirstOrDefault(x => x.Id == id);

            if (existingProduct == null) throw new Exception("Product not found!");

            existingProduct.Id = id;
            existingProduct.Name = name;
            existingProduct.Price = price;
            existingProduct.Quantity = quantity;
            existingProduct.Category = category;
        }

        public void RemoveProduct(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException("Id can't be negative!");

            var existingProduct = products.FirstOrDefault(x => x.Id == id);

            if (existingProduct == null) throw new Exception("Not found!");

            products = products.Where(x => x.Id != id).ToList();
        }

        public List<Product> ShowProductsByCategory(Category category)
        {
            if (category == null) throw new Exception("Category can't be empty!");

            var foundProducts = products.Where(x => x.Category == category).ToList();

            return foundProducts;
        }

        public List<Product> ShowProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            if (minPrice > maxPrice) throw new Exception("Min price can't be more than Max date!");

            return products.Where(x => x.Price >= minPrice && x.Price <= maxPrice).ToList();
        }

        public List<Product> SearchProductsByName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name)) throw new Exception("Name can't be empty");

            var foundProducts = products.Where(x => x.Name.ToLower().Trim() == name.ToLower().Trim()).ToList();

            return foundProducts;
        }

        public void AddNewSale(int productid, int quantity, DateTime Now)
        {
            List<SaleItem> tempItems = new List<SaleItem>();

            int option;

            do
            {
                var product = products.Find(p => p.Id == productid);

                if (quantity <= 0)
                {
                    Console.WriteLine("Quantity must be greater than 0.");
                }
                else if (product == null)
                {
                    Console.WriteLine("Product not found.");
                }
                else if (product.Quantity < quantity)
                {
                    Console.WriteLine("Not enough quantity in stock.");
                }
                else
                {
                    var price = product.Price * quantity;
                    product.Quantity -= quantity;

                    var saleItem = new SaleItem(product, quantity);
                    tempItems.Add(saleItem);

                    Console.WriteLine("Product added to the sale.");
                }

                Console.WriteLine("Do you want to add one more product?");
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

            if (tempItems.Count > 0)
            {
                decimal sum = tempItems.Sum(item => item.Quantity * item.SalesProduct.Price);
                int totalQuantity = tempItems.Sum(item => item.Quantity);

                var sale = new Sales("Sale", sum, totalQuantity, Now, tempItems);
                sales.Add(sale);

                Console.WriteLine("_______________");
                Console.WriteLine("Sale completed.");
                Console.WriteLine("_______________");
            }
            else
            {
                Console.WriteLine("Sale canceled, no products added.");
            }
        }
       

        public void RemoveSale(int id)
        {
            if (id < 0) throw new Exception("Id is negative!");

            int saleIndex = sales.FindIndex(x => x.Id == id);

            if (saleIndex == -1) throw new Exception("Sale not found!");

            sales.RemoveAt(saleIndex);

        }

        public void ShowAllSales(int id, string name, int quantity, DateTime dateTime)
        {
            {
                if(sales.Count == 0)
                {
                    Console.WriteLine("No sales yet");
                }
            }

            foreach (var sale in sales)
            {
                Console.WriteLine(sale);
            }
        }

        
    }
}
