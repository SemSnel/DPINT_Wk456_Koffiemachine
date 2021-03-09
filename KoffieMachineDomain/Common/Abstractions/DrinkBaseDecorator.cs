using System;
using System.Collections.Generic;
using KoffieMachineDomain.Common.Interfaces;

namespace KoffieMachineDomain.Common.Abstractions
{
    public abstract class DrinkBaseDecorator : IDrink
    {
        private readonly IDrink _baseDecorator;

        public DrinkBaseDecorator(IDrink baseDecorator)
        {
            _baseDecorator = baseDecorator;
        }

        public string Name => _baseDecorator.Name;

        public virtual double GetPrice()
        {
            return _baseDecorator.GetPrice();
        }

        public virtual void LogDrinkMaking(ICollection<string> log)
        {
            _baseDecorator.LogDrinkMaking(log);
        }
    }
}
