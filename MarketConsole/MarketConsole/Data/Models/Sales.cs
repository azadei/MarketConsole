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

        public Sales(string name, decimal sum, string item, DateTime date)
        {
            Name = name;
            Sum = sum;
            Item = item;
            Date = date;

            Id = count;
            count++;

        }

        public string Name { get; set; }
        public decimal Sum { get; set; }
        public string Item { get; set; }
        public DateTime Date { get; set; }

    }

       
    
        
    


}
