using System;
using System.Collections.Generic;
using System.Text;

namespace TeaAndChocolateLibrary
{
    public class Tea
    {
        public  float Price { get; set; }

        public int AmountOfSugar { get; set; }

        public TeaBlend Blend { get; set; }

        public void AddSugar()
        {
            AmountOfSugar++;
        }

        public void RemoveSugar()
        {
            AmountOfSugar--;
        }
    }
}
