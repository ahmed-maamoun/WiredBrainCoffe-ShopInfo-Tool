using System.Collections.Generic;

namespace WiredBrainCoffee.DataAccess
{
    public class CoffeeShopDataProvider
    {
        public IEnumerable<CoffeeShop> LoadCoffeeShops() {
            yield return new CoffeeShop { Location = "Nasr City", BeansInStokInKg = 105 };
            yield return new CoffeeShop { Location = "Nasr City2", BeansInStokInKg = 106 };
            yield return new CoffeeShop { Location = "Nasr City3", BeansInStokInKg = 107 };

        }
    }
}
