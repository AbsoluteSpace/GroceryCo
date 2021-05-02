using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;

namespace GroceryCo.src
{
    public class Checkout
    {
        private Dictionary<string, int> cart = new Dictionary<string, int>();
        private Prices prices;

        public Checkout(Prices p)
        {
            prices = p;
        }

        public void PerformCheckout(string filepath = "./groceries/groceries.txt")
        {
            if (!File.Exists(filepath))
            {
                Console.WriteLine("\n No groceries given.");
                return;
            }

            AddItemsToCart(System.IO.File.ReadAllText(filepath).Split(","));

            PrintReciept();
        }

        private void AddItemsToCart(string[] groceries)
        {
            foreach (var item in groceries.Select(i => i.Trim(' ')))
            {
                if (cart.ContainsKey(item))
                {
                    cart[item]++;
                }
                else
                {
                    cart.Add(item, 1);
                }
            }
        }

        private void PrintReciept()
        {
            double totalPrice = 0;
            HashSet<string> unknownItems = new HashSet<string>();

            foreach (var item in cart.Keys.ToList())
            {
                Item itemObject = null;
                try
                {
                    itemObject = prices.prices[item];
                }
                catch (KeyNotFoundException)
                {
                    unknownItems.Add(item);
                    continue;
                }

                totalPrice += cart[item] * itemObject.price;
                Console.WriteLine($"\n {item} | x{cart[item]} | ${prices.prices[item].price} per item");
                if (itemObject.price != itemObject.salePrice)
                {
                    Console.WriteLine($" | SALE: ${prices.prices[item].salePrice} per item");
                }
            }

            Console.WriteLine("\n Oops! The following item(s) were not found in our catalog, please see an associate for assistance.");
            foreach (var unkownItem in unknownItems)
            {
                Console.WriteLine($"\n - {unkownItem}");
            }

            Console.WriteLine($"\n TOTAL COST: {totalPrice}");
        }
    }
}