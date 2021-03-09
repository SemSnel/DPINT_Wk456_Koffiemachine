using System;
using System.Collections.Generic;
using KoffieMachineDomain.Common.Abstractions;
using KoffieMachineDomain.Common.Interfaces;
using KoffieMachineDomain.Enums;

namespace KoffieMachineDomain.Entities.DrinkDecorators
{
    public class CoffeeStrengthDecorator : DrinkBaseDecorator
    {
        private readonly Strength _strength;

        public CoffeeStrengthDecorator(IDrink baseDecorator, Strength strength) : base(baseDecorator)
        {
            _strength = strength;
        }

        public Strength Strength => _strength;

        public override void LogDrinkMaking(ICollection<string> log)
        {
            base.LogDrinkMaking(log);

            log.Add($"Setting coffee strength to {Strength}.");
            log.Add("Filling with coffee...");
        }
    }
}
