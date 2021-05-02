using System;
using System.Collections.Generic;
using GroceryCo.src;

namespace GroceryCo
{
    class Program
    {
        static void Main(string[] args)
        {
            var keepLooping = true;
            var prices = new Prices();

            while (keepLooping)
            {
                Console.WriteLine("\n" + "Press [C] to checkout or [Escape] to shutdown this checkout kiosk.");

                var keyPress = Console.ReadKey().Key;
                prices.UpdatePrices();

                switch (keyPress)
                {
                    case ConsoleKey.C:
                        var checkout = new Checkout(prices);
                        checkout.PerformCheckout();
                        break;
                    case ConsoleKey.Escape:
                        keepLooping = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
