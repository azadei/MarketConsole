using MarketConsole.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketConsole.Service.Concrete
{
    public class MarketService
    {
        private List<Product> products;

        public MarketService()
        {
            products = new();
            
        }
        
        public List<Product> GetProducts()
        {
            return products;
        }

        public void AddProduct(string name, decimal price, int quantity, string category)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name can't be empty!");

            if (price <= 0) throw new ArgumentOutOfRangeException("Price can't be negative or 0!");

            var product = new Product(name, price, quantity, category);

            products.Add(product);

        }



















    }
}
