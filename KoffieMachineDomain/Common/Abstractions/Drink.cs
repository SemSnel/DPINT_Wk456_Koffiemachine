using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Common.Interfaces;

namespace KoffieMachineDomain.Common.Abstractions
{
    public abstract class Drink : IDrink
    {
        protected const double BaseDrinkPrice = 1.0;
        
        public abstract string Name { get; }
        public abstract double GetPrice();

        public virtual void LogDrinkMaking(ICollection<string> log)
        {
            log.Add($"Making {Name}...");
            log.Add($"Heating up...");
        }
    }
}
