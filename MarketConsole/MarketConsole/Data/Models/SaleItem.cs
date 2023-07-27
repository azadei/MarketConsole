using MarketConsole.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketConsole.Data.Models
{
    public class SaleItem : BaseEntity
    {
        public static int count = 0;

        public SaleItem(Product product, int quantity)
        {
            SalesProduct = product;
            Quantity = quantity;


            Id = count;
            count++;
        }

        public Product SalesProduct  { get; set; }
        public int Quantity { get; set; }

        internal void Add(SaleItem saleItem)
        {
            throw new NotImplementedException();
        }
    }
}
