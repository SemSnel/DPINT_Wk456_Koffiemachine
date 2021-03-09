using System;
using System.Collections.Generic;

namespace KoffieMachineDomain.Common.Interfaces
{
    public interface IDrinkFactory
    {
        public Dictionary<string, IDrink> AvailableDrinks { get; }

        public IEnumerable<string> AvailableDrinksNames { get; }
    }
}
