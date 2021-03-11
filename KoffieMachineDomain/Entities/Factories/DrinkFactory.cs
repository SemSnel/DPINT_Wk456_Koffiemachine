using System;
using System.Collections.Generic;
using KoffieMachineDomain.Common.Abstractions;
using KoffieMachineDomain.Common.Interfaces;
using KoffieMachineDomain.Entities.DrinkDecorators;
using KoffieMachineDomain.Enums;

namespace KoffieMachineDomain.Common.Factories
{
    public class DrinkFactory : IDrinkFactory
    {
        private readonly Dictionary<string, Func<IDrink>> _availableDrinks;

        public DrinkFactory()
        {
            _availableDrinks = new Dictionary<string, Func<IDrink>>();
        }

        public Dictionary<string, Func<IDrink>> AvailableDrinks => _availableDrinks;

        public ICollection<string> AvailableDrinksNames => _availableDrinks.Keys;


        public IDrink GetDrink(string name, Strength strength, Amount sugarAmount, Amount milkAmount)
        {
            IDrink drink = null;

            switch (name)
            {
                case "Coffee":
                    return GetCoffee(strength, sugarAmount, milkAmount);
                case "Espresso":
                    return GetEspresso();
                case "Capuccino":
                    return GetCapuccino();
                case "Wiener Melange":
                    return GetWienerMelange();
                case "Caf? au Lait":
                    return CafeAuLait();
            }

            return drink;
        }

        #region Make Drink Methods
        public IDrink GetCoffee(Strength strength, Amount sugarAmount, Amount milkAmount)
        {
            IDrink drink = new DrinkBase();

            drink = AddCoffee(drink, strength);
            drink = AddMilk(drink, milkAmount);
            drink = AddSugar(drink, sugarAmount);

            return drink;
        }

        public IDrink GetEspresso()
        {
            IDrink drink = new DrinkBase();

            drink = new Espresso();

            return drink;
        }

        public IDrink GetCapuccino()
        {
            IDrink drink = new DrinkBase();

            drink = new Capuccino();
            return drink;
        }

        public IDrink GetWienerMelange()
        {
            IDrink drink = new DrinkBase();

            drink = new WienerMelange();

            return drink;
        }

        public IDrink CafeAuLait()
        {
            IDrink drink = new DrinkBase();

            drink = new CafeAuLait();

            return drink;
        }

        public IDrink AddCoffee(IDrink drink, Strength strength)
        {
            return new CoffeeStrengthDecorator(drink, strength);
        }

        public IDrink AddMilk(IDrink drink, Amount amount)
        {
            return new MilkDrinkDecorator(drink, amount);
        }

        public IDrink AddSugar(IDrink drink, Amount amount)
        {
            return new SugarDrinkDecorator(drink, amount);
        }

        #endregion Make Drink Methods
    }
}
