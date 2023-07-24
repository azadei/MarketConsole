using MarketConsole.Data.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketConsole
{
    internal interface IMarketService
    {
        public void AddProduct(string name, decimal price, int quantity, Category category);

        public void UpdateProduct(int id, string name, decimal price, int quantity, Category category);

        public void RemoveProduct(int id);


    }
}
