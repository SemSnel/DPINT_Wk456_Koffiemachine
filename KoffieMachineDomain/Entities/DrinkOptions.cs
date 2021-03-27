using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoffieMachineDomain.Enums;

namespace KoffieMachineDomain.Entities
{
    public class DrinkOptions
    {
        public DrinkOptions()
        {
            Strength = Strength.Normal;
            SugarAmount = Amount.Normal;
            MilkAmount = Amount.Normal;
        }

        public string Name { get; set; }

        public  Strength Strength { get; set; }

        public Amount MilkAmount { get; set; }

        public Amount SugarAmount { get; set; }
    }
}
