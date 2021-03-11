using System;
using System.Collections.Generic;
using KoffieMachineDomain.Common.Interfaces;

namespace KoffieMachineDomain.Common.Abstractions
{
    public class DrinkBase : IDrink
    {
        private readonly double BaseDrinkPrice = 1.0;

        public string Name { get; set; }

        public double GetPrice() => BaseDrinkPrice;

        public void LogDrinkMaking(ICollection<string> log)
        {
            log.Add($"Making {Name}...");
            log.Add($"Heating up...");
        }
    }
}
