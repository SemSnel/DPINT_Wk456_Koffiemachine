using System;
using System.Collections.Generic;

namespace KoffieMachineDomain.Common.Interfaces
{
    public interface IDrink
    {
        string Name { get; }

        double GetPrice();

        public void LogDrinkMaking(ICollection<string> log);
    }
}
