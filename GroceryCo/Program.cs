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
            // prices should be global for the lifetime of the program
            // cart should have a new instance, so basically keep the program running and when it finishes checkout
            // print the reciept and then clear things for the next user - like "thanks for shopping here"
            // before the start of a checkout, check the price of everythng is up to date.



            // tried to keep in mind things like membership cards, or more options for the customer
            // fun error like oops you've scanned an item not in our catalog, call for assistance?

            var prices = new Prices();

            while (keepLooping)
            {
                Console.WriteLine("\n" + "Press [C] to checkout or [Escape] to shutdown this checkout kiosk.");

                var keyPress = Console.ReadKey().Key;

                // when the transaction begins, check the price updates
                // need a way to make this fast, maybe like price updates as things are happening, or better yet when it's idling
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
