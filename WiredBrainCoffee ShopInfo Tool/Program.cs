﻿using System;
using WiredBrainCoffee.DataAccess;

namespace WiredBrainCoffee_ShopInfo_Tool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WiredBrainCoffee ShopInfo Tool!");
            Console.WriteLine("Write 'help' to list available coffeshop commands");
            var coffeShopDataProvider = new CoffeeShopDataProvider();
            while (true)
            {
                var line = Console.ReadLine();
                var coffeShops = coffeShopDataProvider.LoadCoffeeShops();
                if (string.Equals("help", line, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("> Available coffee shop commands:");
                    foreach (var coffeeShop in coffeShops)
                    {
                        Console.WriteLine($"> " + coffeeShop.Location);
                    }
                }
            }
        }
    }
}
