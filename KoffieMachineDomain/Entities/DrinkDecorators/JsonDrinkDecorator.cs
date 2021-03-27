using System.Collections.Generic;
using KoffieMachineDomain.Common.Abstractions;
using KoffieMachineDomain.Common.Interfaces;
using KoffieMachineDomain.Config;

internal class JsonDrinkDecorator : DrinkBaseDecorator
{
    public JsonIngredient JsonIngredient { get; set; }

    public JsonDrinkDecorator(IDrink drink, JsonIngredient jsonIngredient) : base(drink)
    {
        JsonIngredient = jsonIngredient;
    }

    public override double GetPrice()
    {
        return base.GetPrice() + JsonIngredient.Price;
    }

    public override void LogDrinkMaking(ICollection<string> log)
    {
        base.LogDrinkMaking(log);
        log.Add($"Adding {JsonIngredient.Name}...");
    }
}