using System;
using System.Collections.Generic;
using KoffieMachineDomain.Common.Abstractions;
using KoffieMachineDomain.Common.Interfaces;
using KoffieMachineDomain.Config;
using KoffieMachineDomain.Entities;
using KoffieMachineDomain.Entities.DrinkDecorators;
using KoffieMachineDomain.Enums;

namespace KoffieMachineDomain.Common.Factories
{
    public class DrinkFactory : IDrinkFactory
    {
        //private TeaBlendRepository _teaBlendRepository;

        public DrinkFactory()
        {

        }

        public IDrink GetDrink(DrinkOptions options)
        {
            if (!IsExistingDrink(options.Name))
            {
                return null;
            }

            if (IsSpecialCoffee(options.Name))
            {
                return MakeJSONCoffee(new JsonCoffee(), options.Strength);
            }

            IDrink drink = new DrinkBase() { Name = options.Name };

            if (IsTeaBlend(options.Name))
            {

            }

            if (IsRegularCoffee(options.Name))
            {
                drink = MakeRegularCoffee(options);
            }

            if (IsDrinkWithMilk(options.Name))
            {
                drink = new MilkDrinkDecorator(drink, options.MilkAmount);
            }

            if (IsDrinkWithSugar(options.Name))
            {
                drink = new SugarDrinkDecorator(drink, options.SugarAmount);
            }

            return drink;
        }

        private IDrink MakeRegularCoffee(DrinkOptions options)
        {
            var name = options.Name;
            var strength = options.Strength;
            IDrink drink = new DrinkBase() { Name = name};

            if (name.Contains("Espresso"))
            {
                strength = Strength.Strong;
            }

            if (name.Contains("Capuccino"))
            {
                strength = Strength.Normal;
            }

            if(name.Contains("WienerMelange"))
            {
                strength = Strength.Weak;
            }

            if (name.Contains("Café au Lait"))
            {
                return new HalfCoffeeHalfMilkDrinkDecorator(drink);
            }

            return new CoffeeDecorator(drink, strength);
        }

        private IDrink MakeJSONCoffee(JsonCoffee jsonCoffee, Strength coffeeStrength)
        {
            IDrink drink = new DrinkBase() {Name = jsonCoffee.Name};
            drink = new CoffeeDecorator(drink, coffeeStrength);

            foreach (JsonIngredient ingredient in jsonCoffee.Ingredients)
            {
                switch (ingredient.Name)
                {
                    case "Sugar":
                        drink = new SugarDrinkDecorator(drink, Amount.Normal);
                        break;
                    case "Milk":
                        drink = new MilkDrinkDecorator(drink, Amount.Normal);
                        break;
                    default:
                        drink = new JsonDrinkDecorator(drink, ingredient);
                        break;
                }
            }
            return drink;
        }

        public bool IsExistingDrink(string name)
        {
            return IsRegularCoffee(name) || IsSpecialCoffee(name) || IsTeaBlend(name);
        }

        private bool IsRegularCoffee(string name)
        {
            return true;
        }

        private bool IsSpecialCoffee(string name)
        {
            return name.Contains("JsonCoffee");
        }

        private bool IsTeaBlend(string name)
        {
            return false;
        }  

        private bool IsDrinkWithSugar(string name)
        {
            return name.Contains("sugar");
        }
        private bool IsDrinkWithMilk(string name)
        {
            return name.Contains("milk");
        }
    }
}
