using System;
using System.Collections.Generic;
using KoffieMachineDomain.Common.Abstractions;
using KoffieMachineDomain.Common.Interfaces;

namespace KoffieMachineDomain.Entities.DrinkDecorators
{
    public class CreamingMilkDecorator : DrinkBaseDecorator
    {
        public CreamingMilkDecorator(IDrink baseDecorator) : base(baseDecorator)
        {
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);

            log.Add("Creaming milk...");
            log.Add("Adding milk to coffee...");
        }
    }
}
