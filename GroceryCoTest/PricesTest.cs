using GroceryCo.src;
using System.Collections.Generic;
using Xunit;
using System.IO;
using System;

namespace GroceryCoTest
{
    public class PricesTest
    {
        [Fact]
        public void NoPricesTest()
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "./prices.txt", "");
            var prices = new Prices();
            prices.UpdatePrices(AppDomain.CurrentDomain.BaseDirectory + "./prices.txt");
            Assert.Empty(prices.prices);
        }

        [Fact]
        public void OnePriceTest()
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "./prices.txt", "catfood:2:1.5");
            var prices = new Prices();
            prices.UpdatePrices(AppDomain.CurrentDomain.BaseDirectory + "./prices.txt");
            Assert.Equal(2, prices.prices["catfood"].price);
            Assert.Equal(1.5, prices.prices["catfood"].salePrice);
        }

        [Fact]
        public void DuplicatePriceTest()
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "./prices.txt", "catfood:2:1.5,catfood:4:3");
            var prices = new Prices();
            prices.UpdatePrices(AppDomain.CurrentDomain.BaseDirectory + "./prices.txt");
            Assert.Equal(4, prices.prices["catfood"].price);
            Assert.Equal(3, prices.prices["catfood"].salePrice);
        }

        [Fact]
        public void BadFormatCostPriceTest()
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "./prices.txt", "apple:badvalue:3");
            var prices = new Prices();
            prices.UpdatePrices(AppDomain.CurrentDomain.BaseDirectory + "./prices.txt");
            Assert.Empty(prices.prices);
        }

        [Fact]
        public void BadFormatSalePriceTest()
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "./prices.txt", "apple:2:badvalue");
            var prices = new Prices();
            prices.UpdatePrices(AppDomain.CurrentDomain.BaseDirectory + "./prices.txt");
            Assert.NotEmpty(prices.prices);
            Assert.Equal(2, prices.prices["apple"].price);
            Assert.Equal(2, prices.prices["apple"].salePrice);
        }
    }
}