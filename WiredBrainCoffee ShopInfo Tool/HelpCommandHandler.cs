using System;
using System.Collections.Generic;
using WiredBrainCoffee.DataAccess;

namespace WiredBrainCoffee_ShopInfo_Tool
{
    internal class HelpCommandHandler : ICommandHandler
    {
        private IEnumerable<CoffeeShop> coffeShops;

        public HelpCommandHandler(IEnumerable<CoffeeShop> coffeShops)
        {
            this.coffeShops = coffeShops;
        }

        public void HandleCommand()
        {
            Console.WriteLine("> Available coffee shop commands:");
            foreach (var coffeeShop in coffeShops)
            {
                Console.WriteLine($"> {coffeeShop.Location}");
            }
        }
    }
}