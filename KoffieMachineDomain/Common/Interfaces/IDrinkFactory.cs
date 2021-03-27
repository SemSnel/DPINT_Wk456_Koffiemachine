using System;
using System.Collections.Generic;
using KoffieMachineDomain.Entities;
using KoffieMachineDomain.Enums;

namespace KoffieMachineDomain.Common.Interfaces
{
    public interface IDrinkFactory
    {
        bool IsExistingDrink(string name);
        IDrink GetDrink(DrinkOptions options);
    }
}
