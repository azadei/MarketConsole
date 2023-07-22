using MarketConsole.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketConsole.Data.Models
{
    public class Product : BaseEntity
    {
        private static int count = 0;

        public Product(string name, decimal price, int quantity, string category)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;

            Id = count;
            count++;

        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }




    }
}
