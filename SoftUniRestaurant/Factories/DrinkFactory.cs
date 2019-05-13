namespace SoftUniRestaurant.Factories
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using System;

    public class DrinkFactory
    {
        public IDrink CreateDrink(string type, string name, int servingSize, string brand)
        {
            Type drinkType = Type.GetType("SoftUniRestaurant.Models.Drinks." + type);

            var drink = (IDrink)Activator.CreateInstance(drinkType, name, servingSize, brand);

            return drink;
        }
    }
}
