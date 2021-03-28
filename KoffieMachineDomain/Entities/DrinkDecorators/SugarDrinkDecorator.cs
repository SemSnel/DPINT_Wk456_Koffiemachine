using System;
using System.Collections.Generic;
using KoffieMachineDomain.Common.Abstractions;
using KoffieMachineDomain.Common.Interfaces;
using KoffieMachineDomain.Enums;

namespace KoffieMachineDomain.Entities.DrinkDecorators
{
    public class SugarDrinkDecorator : DrinkBaseDecorator
    {
        public static readonly double SugarPrice = 0.1;

        private readonly Amount _amount;

        public SugarDrinkDecorator(IDrink baseDecorator, Amount amount) : base(baseDecorator)
        {
            _amount = amount;
        }

        public object Amount { get => _amount; }

        public override double GetPrice()
        {
            return base.GetPrice() + SugarPrice;
        }

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);

            log.Add($"Setting sugar amount to {Amount}.");
            log.Add("Adding sugar...");
        }
    }
}
