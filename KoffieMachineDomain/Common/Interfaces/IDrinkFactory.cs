using System;
using System.Collections.Generic;
using KoffieMachineDomain.Enums;

namespace KoffieMachineDomain.Common.Interfaces
{
    public interface IDrinkFactory
    {
        Dictionary<string, Func<IDrink>> AvailableDrinks { get; }

        ICollection<string> AvailableDrinksNames { get; }
        IDrink GetDrink(string drinkName, Strength coffeeStrength, Amount? sugarAmount, Amount? milkAmount);
    }
}
