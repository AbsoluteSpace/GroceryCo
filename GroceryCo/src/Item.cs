using System.Collections.Generic;

namespace GroceryCo.src
{
    public class Item
    {
        public double price { get; set; }
        public double salePrice { get; set; }
        public string name { get; set; }

        public Item(string n, double p, double sp = -1)
        {
            name = n;
            price = p;
            salePrice = sp == -1 ? p : sp;
        }
    }
}