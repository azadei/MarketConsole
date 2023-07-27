using MarketConsole.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketConsole.Data.Models
{
    public class Sales : BaseEntity
    {
        public static int count = 0;
        private int quantity;

       

        public Sales(string name, decimal sum, int quantity, DateTime date, List<SaleItem> items)
        {
            Name = name;
            Sum = sum;
            Quantity = quantity;
            Date = date;
            Items = items;

            Id = count;
            count++;

        }

        public string Name { get; set; }
        public decimal Sum { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int ProductCount{ get; set; }
        public DateTime Date { get; set; }
        public List<SaleItem> Items { get; set; }

    }

       
    
        
    


}
