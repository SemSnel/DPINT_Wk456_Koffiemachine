using System;
using System.Collections.Generic;
using KoffieMachineDomain.Common.Abstractions;
using KoffieMachineDomain.Common.Interfaces;
using KoffieMachineDomain.Enums;

namespace KoffieMachineDomain.Entities.DrinkDecorators
{
    public class MilkDrinkDecorator : DrinkBaseDecorator
    {
        public static readonly double MilkPrice = 0.15;
        private readonly Amount _amount;

        public MilkDrinkDecorator(IDrink baseDecorator, Amount amount) : base(baseDecorator)
        {
            _amount = amount;
        }

        public Amount Amount => _amount;

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);

            log.Add($"Setting milk amount to {Amount}.");
            log.Add("Adding milk...");
        }
    }
}
