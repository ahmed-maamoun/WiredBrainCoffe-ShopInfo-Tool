using System;
using System.Collections.Generic;
using System.Linq;
using WiredBrainCoffee.DataAccess;

namespace WiredBrainCoffee_ShopInfo_Tool
{
    internal class CoffeShopCommandHandler: ICommandHandler
    {
        private string line;
        private IEnumerable<CoffeeShop> coffeShops;

        public CoffeShopCommandHandler(string line, IEnumerable<CoffeeShop> coffeShops)
        {
            this.line = line;
            this.coffeShops = coffeShops;
        }

        public void HandleCommand()
        {
            var foundCoffeShops = coffeShops.Where(x => x.Location.StartsWith(line, StringComparison.OrdinalIgnoreCase)).ToList();
            if (foundCoffeShops.Count == 0)
                Console.WriteLine($"> Command {line} not found");
            else if (foundCoffeShops.Count == 1)
            {
                var coffeeShop = foundCoffeShops.Single();
                Console.WriteLine($"> Location: { coffeeShop.Location}");
                Console.WriteLine($"> Beans in stock: { coffeeShop.BeansInStokInKg} KG");

            }
            else
            {
                Console.WriteLine("> Multiple matcching coffee shop commands found:");
                foreach (var coffeeShop in foundCoffeShops)
                {
                    Console.WriteLine($"> " + coffeeShop.Location);
                }
            }
        }
    }
}