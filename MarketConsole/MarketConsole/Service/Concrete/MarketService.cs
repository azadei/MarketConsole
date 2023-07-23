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

        public void UpdateProduct(int id, string name, decimal price, int quantity, string category)
        {
            if (id < 0) throw new ArgumentOutOfRangeException("Id can't be negative!");

            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name can't be empty!");

            if (price < 0) throw new ArgumentOutOfRangeException("Price can't be negative!");

            if (quantity < 0) throw new ArgumentOutOfRangeException("Quantity can't be negative!");

            if (string.IsNullOrWhiteSpace(category)) throw new Exception("Category can't be empty!");

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

        public List<Product> ShowProductsByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category)) throw new Exception("Category can't be empty!");

            var foundProducts = products.Where(x => x.Category.ToLower().Trim() == category.ToLower().Trim()).ToList();

            return foundProducts;
        }

        public List<Product> ShowProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            if (minPrice > maxPrice) throw new Exception("Min price can't be more than Max date!");

            return products.Where(x => x.Price >= minPrice && x.Price <= maxPrice).ToList();
        }

        internal IEnumerable<object> SearchProductsByName(string? name)
        {
            throw new NotImplementedException();
        }

        static List<Product> SearchProductByName(List<Product> products, string searchName)
        {
            List<Product> foundProducts = new List<Product>();

            foreach (var product in products)
            {
                if (product.Name.ToLower().Contains(searchName.ToLower()))
                {
                    foundProducts.Add(product);
                }
            }

            return foundProducts;
        }
    }
}
