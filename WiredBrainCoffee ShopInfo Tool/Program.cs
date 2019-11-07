using System;
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

                var commandHandler = string.Equals("help", line, StringComparison.OrdinalIgnoreCase)
                    ? new HelpCommandHandler(coffeShops) as ICommandHandler :
                    new CoffeShopCommandHandler(line, coffeShops) as ICommandHandler;

                commandHandler.HandleCommand();
            }
        }

       
    }
}
