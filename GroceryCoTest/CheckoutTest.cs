using GroceryCo.src;
using System.Collections.Generic;
using Xunit;
using System.IO;
using System;

namespace GroceryCoTest
{
    public class CheckoutTest
    {
        // [Fact]
        // public void AllFoundCheckoutTest()
        // {
        //     File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "./prices.txt", "apple:1:0.5,pineapple:3:1,catfood:4");
        //     var prices = new Prices();
        //     prices.UpdatePrices(AppDomain.CurrentDomain.BaseDirectory + "./prices.txt");

        //     File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "./groceries.txt", "apple,pineapple,apple,apple,catfood");
        //     var checkout = new Checkout(prices);
        //     checkout.PerformCheckout(AppDomain.CurrentDomain.BaseDirectory + "./groceries.txt");
        // }

        // [Fact]
        // public void MissingItemCheckoutTest()
        // {
        //     File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "./prices.txt", "catfood:2:1.5");
        //     var prices = new Prices();
        //     prices.UpdatePrices(AppDomain.CurrentDomain.BaseDirectory + "./prices.txt");
        //     Assert.Equal(2, prices.prices["catfood"].price);
        //     Assert.Equal(1.5, prices.prices["catfood"].salePrice);
        // }
    }
}