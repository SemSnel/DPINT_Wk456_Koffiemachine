using System;
using System.Collections.Generic;

namespace KoffieMachineDomain.Common.Interfaces
{
    public interface IDrinkFactory
    {
        public Dictionary<string, Func<IDrink>> AvailableDrinks { get; }

        public ICollection<string> AvailableDrinksNames { get; }
    }
}
