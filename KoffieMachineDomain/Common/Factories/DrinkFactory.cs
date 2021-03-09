using System;
using System.Collections.Generic;
using KoffieMachineDomain.Common.Interfaces;

namespace KoffieMachineDomain.Common.Factories
{
    public class DrinkFactory : IDrinkFactory
    {
        private readonly Dictionary<string, IDrink> _availableDrinks;

        public DrinkFactory()
        {
            _availableDrinks = new Dictionary<string, IDrink>();
        }

        public Dictionary<string, IDrink> AvailableDrinks => _availableDrinks;

        public IEnumerable<string> AvailableDrinksNames => _availableDrinks.Keys;
    }
}
