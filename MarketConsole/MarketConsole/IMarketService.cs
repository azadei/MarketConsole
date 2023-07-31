using MarketConsole.Data.Common.Enums;
using MarketConsole.Data.Models;
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

        public List<Product> ShowProductsByCategory(Category category);

        public List<Product> ShowProductsByPriceRange(decimal minPrice, decimal maxPrice);

        public List<Product> SearchProductsByName(string name);



        public void AddNewSale(int productid, int quantity, DateTime Now);

        public void ReturnProductFromSale(int saleId, int productIdToReturn, int quantityToReturn);

        public void RemoveSale(int id);

        public void ShowAllSales(int id, decimal price, int quantity, DateTime dateTime);

        public List<Sales> ShowSaleByDateRange(DateTime startDate, DateTime endDate);

        public List<Sales> ShowSalesOnGivenDate(DateTime date);

        public List<Sales> ShowSalesByAmountRange(decimal minamount, decimal maxamount);

        public Sales ShowSalesByGivenId(int saleId);
    }
}
