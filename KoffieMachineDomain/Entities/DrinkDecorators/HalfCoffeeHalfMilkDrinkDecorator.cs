using System;
using System.Collections.Generic;
using KoffieMachineDomain.Common.Abstractions;
using KoffieMachineDomain.Common.Interfaces;

namespace KoffieMachineDomain.Entities.DrinkDecorators
{
    public class HalfCoffeeHalfMilkDrinkDecorator : DrinkBaseDecorator
    {
        public HalfCoffeeHalfMilkDrinkDecorator(IDrink baseDecorator) : base(baseDecorator)
        {

        }

        public override double GetPrice()
        {
            return base.GetPrice() + 0.5;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);

            log.Add("Filling half with coffee...");
            log.Add("Filling other half with milk...");
        }
    }
}
