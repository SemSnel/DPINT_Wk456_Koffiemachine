using System;
using System.Collections.Generic;
using KoffieMachineDomain.Common.Abstractions;
using KoffieMachineDomain.Common.Interfaces;
using KoffieMachineDomain.Config;
using KoffieMachineDomain.Entities;
using KoffieMachineDomain.Entities.Adapters;
using KoffieMachineDomain.Entities.DrinkDecorators;
using KoffieMachineDomain.Enums;
using TeaAndChocoLibrary;

namespace KoffieMachineDomain.Common.Factories
{
    public class DrinkFactory : IDrinkFactory
    {
        private TeaBlendRepository _teaBlendRepository;

        public DrinkFactory(TeaBlendRepository teaBlendRepository)
        {
            _teaBlendRepository = teaBlendRepository;
        }

        public IDrink GetDrink(DrinkOptions options)
        {

            if (IsSpecialCoffee(options.Name))
            {
                return MakeJSONCoffee(options);
            }

            IDrink drink = new DrinkBase() { Name = options.Name };

            if (IsTeaBlend(options.Name))
            {
                drink = MakeTea(options);
            }

            if (IsHotChocolate(options.Name))
            {
                drink = MakeHotChocolate(options);
                
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

        private IDrink MakeHotChocolate(DrinkOptions options)
        {
            var hotChocolate = new HotChocolate();

            var drink = new HotChocolateAdapter(hotChocolate);

            if (!options.Name.Equals("Chocolate Deluxe"))
            {
                return drink;
            }

            hotChocolate.MakeDeluxe();

            return drink;
        }

        private IDrink MakeRegularCoffee(DrinkOptions options)
        {
            var name = options.Name;
            var strength = options.Strength;

            IDrink drink = new DrinkBase() { Name = name };

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

        private IDrink MakeJSONCoffee(DrinkOptions options)
        {
            var jsonCoffee = options.JsonCoffee;
            IDrink drink = new DrinkBase() {Name = jsonCoffee.Name};

            drink = new CoffeeDecorator(drink, options.Strength);

            foreach (JsonIngredient ingredient in jsonCoffee.Ingredients)
            {
                switch (ingredient.Name)
                {
                    case "Sugar":
                        drink = new SugarDrinkDecorator(drink, options.SugarAmount);
                        break;
                    case "Milk":
                        drink = new MilkDrinkDecorator(drink, options.MilkAmount);
                        break;
                    default:
                        drink = new JsonDrinkDecorator(drink, ingredient);
                        break;
                }
            }
            return drink;
        }

        private IDrink MakeTea(DrinkOptions options)
        {
            var blendNames = _teaBlendRepository.BlendNames;
            Tea tea = new Tea();

            tea.Blend = _teaBlendRepository.GetTeaBlend(options.TeaBlend);

            var drink = new TeaAdapter(tea);

            return drink;
        }

        #region check methods
        public bool IsExistingDrink(string name)
        {
            return IsRegularCoffee(name) || IsSpecialCoffee(name) || IsTeaBlend(name) || IsHotChocolate(name);
        }

        private bool IsHotChocolate(string name)
        {
            return name.Contains("Chocolate") || name.Contains("Chocolate Deluxe");
        }

        private bool IsRegularCoffee(string name)
        {
            return name.Contains("Coffee") || name.Contains("Espresso") || name.Contains("WienerMelange") || name.Contains("Capuccino") || name.Contains("Café au Lait");
        }

        private bool IsSpecialCoffee(string name)
        {
            return name.Contains("JsonCoffee");
        }

        private bool IsTeaBlend(string name)
        {
            return name.Contains("Tea");
        }

        private bool IsDrinkWithSugar(string name)
        {
            return name.Contains("sugar");
        }
        private bool IsDrinkWithMilk(string name)
        {
            return name.Contains("milk");
        }

        #endregion check methods

    }
}
