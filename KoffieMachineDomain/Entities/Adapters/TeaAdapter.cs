using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Common.Interfaces;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain.Entities.Adapters
{
    public class TeaAdapter : IDrink
    {
        private readonly Tea _tea;

        public TeaAdapter(Tea tea)
        {
            _tea = tea;
        }

        public string Name => _tea.Blend.Name;

        public double GetPrice()
        { 
            return (double) Tea.Price;
        }

        public void LogDrinkMaking(ICollection<string> log)
        {
            if (!string.IsNullOrWhiteSpace(_tea.Blend.Name))
                log.Add($"Added {_tea.Blend.Name} to tea");
        }
    }
}
