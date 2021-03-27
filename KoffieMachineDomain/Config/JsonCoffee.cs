using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffieMachineDomain.Config
{
    public class JsonCoffee
    {
        public ICollection<JsonIngredient> Ingredients { get; set; } = new List<JsonIngredient>();
        public string Name { get; set; }
    }
}
