using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Common.Interfaces;

namespace KoffieMachineDomain.Entities.Adapters
{
    public class TeaAdapter : IDrink
    {
        private Tea _tea;

        public string Name { get; set; }

        public double GetPrice()
        {
            throw new NotImplementedException();
        }

        public void LogDrinkMaking(ICollection<string> log)
        {
            throw new NotImplementedException();
        }
    }
}
