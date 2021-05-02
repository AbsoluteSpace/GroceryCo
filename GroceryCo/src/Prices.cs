using System;
using System.Collections.Generic;
using System.IO;

namespace GroceryCo.src
{
    // Something like this to easily extend things into like best before dates or whatever
    public class Prices
    {
        public Dictionary<string, Item> prices { get; set; }

        public Prices()
        {
            prices = new Dictionary<string, Item>();
        }

        public void UpdatePrices(string filepath = "./prices/prices.txt")
        {
            if (new FileInfo(filepath).Length == 0)
            {
                return;
            }

            var itemsAndPrices = System.IO.File.ReadAllText(filepath);
            // File.WriteAllText(filepath, String.Empty);

            // duplicate prices or conflicting ones - use the last
            foreach (var itemAndPrice in itemsAndPrices.Split(","))
            {
                var name = itemAndPrice.Split(":")[0].Trim(' ');
                var cost = itemAndPrice.Split(":")[1];
                // what if it's not an int? or what if it's not a string?
                double costInDollars = 0;
                double saleInDollars = 0;

                if (!Double.TryParse(cost, out costInDollars))
                {
                    continue;
                }

                if (itemAndPrice.Split(":").Length == 3)
                {
                    if (!Double.TryParse(itemAndPrice.Split(":")[2], out saleInDollars))
                    {
                        AddPrice(name, costInDollars);
                    }
                    else
                    {
                        AddPrice(name, costInDollars, saleInDollars);
                    }
                }
                else
                {
                    AddPrice(name, costInDollars);
                }
            }
        }

        private void AddPrice(string name, double cost, double sale = -1)
        {
            if (prices.ContainsKey(name))
            {
                prices[name].price = cost;
                prices[name].salePrice = sale == -1 ? cost : sale;
                // // does that alone update the cost? or do I need the next line too
                // prices[item] = prices[item];
            }
            else
            {
                if (sale == -1)
                {
                    prices.Add(name, new Item(name, cost, cost));
                }
                else
                {
                    prices.Add(name, new Item(name, cost, sale));
                }
            }
        }
    }
}