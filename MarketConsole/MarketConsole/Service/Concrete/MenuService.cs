using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketConsole.Service.Concrete
{
    public class MenuService
    {
        public static void MenuProductHandling()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }

        }


        public static void MenuSalesHandling()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void Exit()
        {
            try
            {
                Console.WriteLine("Good Bye");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
    }
}

