using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Common.Interfaces;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain.Entities.Adapters
{
    public class HotChocolateAdapter : IDrink
    {
        public string Name => _hotChocolate.GetNameOfDrink();

        private readonly HotChocolate _hotChocolate;

        public HotChocolateAdapter(HotChocolate hotChocolate)
        {
            _hotChocolate = hotChocolate;
        }


        public double GetPrice()
        {
            return _hotChocolate.Cost();
        }

        public void LogDrinkMaking(ICollection<string> log)
        {
            var steps = _hotChocolate.GetBuildSteps();

            foreach (var step in steps)
            {
                log.Add(step);
            }
        }
    }
}
