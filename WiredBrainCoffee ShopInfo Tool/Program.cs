using System;
using System.Linq;
using WiredBrainCoffee.DataAccess;

namespace WiredBrainCoffee_ShopInfo_Tool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WiredBrainCoffee ShopInfo Tool!");
            Console.WriteLine("Write 'help' to list available coffeshop commands," + "write 'quit' to exit applicationa");
            var coffeShopDataProvider = new CoffeeShopDataProvider();
            while (true)
            {
                var line = Console.ReadLine();
                var coffeShops = coffeShopDataProvider.LoadCoffeeShops();

                if (string.Equals("quit", line, StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                if (string.Equals("help", line, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("> Available coffee shop commands:");
                    foreach (var coffeeShop in coffeShops)
                    {
                        Console.WriteLine($"> " + coffeeShop.Location);
                    }
                }
                else {
                    var foundCoffeShops = coffeShops.Where(x => x.Location.StartsWith(line, StringComparison.OrdinalIgnoreCase)).ToList();
                    if (foundCoffeShops.Count == 0)
                        Console.WriteLine($"> Command {line} not found");
                    else if (foundCoffeShops.Count == 1)
                    {
                        var coffeeShop = foundCoffeShops.Single();
                        Console.WriteLine($"> Location: { coffeeShop.Location}");
                        Console.WriteLine($"> Beans in stock: { coffeeShop.BeansInStokInKg} KG");

                    }
                    else Console.WriteLine("> Multiple matcching coffee shop commands found:");
                    foreach (var coffeeShop in foundCoffeShops)
                    {
                        Console.WriteLine($"> " + coffeeShop.Location);
                    }
                }
            }
        }
    }
}
