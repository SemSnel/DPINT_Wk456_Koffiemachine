using System;
using System.Collections.Generic;
using System.Text;

namespace TeaAndChocolateLibrary
{
    public class HotChocolate
    {
        private bool _isDeluxe;

        public HotChocolate()
        {
            _isDeluxe = false;
        }

        public string GetNameOfDrink()
        {
            return "HotChocolate";
        }

        public IEnumerable<string> GetBuildSteps()
        {
            var steps = new List<string>();

            return steps;
        }

        public double Cost()
        {
            return 1.0;
        }

        public void MakeDeluxe()
        {
            _isDeluxe = true;
        }
    }
}
