using MarketConsole.Data.Common.Enums;
using MarketConsole.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketConsole.Service.Concrete
{
    public class MarketService : IMarketService
    {
        private List<Product> products;
        private List<Sales> sales;

        public MarketService()
        {
            products = new();
            sales = new();
        }
        
        public List<Product> GetProducts()
        {
            return products;
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

        public void RemoveSale(int id)
        {
            if (id < 0) throw new Exception("Id is negative!");

            int saleIndex = sales.FindIndex(x => x.Id == id);

            if (saleIndex == -1) throw new Exception("Meeting not found!");

            sales.RemoveAt(saleIndex);

        }


    }
}
