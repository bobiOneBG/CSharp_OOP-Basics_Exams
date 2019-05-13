namespace SoftUniRestaurant.Factories
{
    using SoftUniRestaurant.Models.Foods.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class FoodFactory
    {
        public IFood CreateFood(string type, string name, decimal price)
        {
            Type foodType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            var food = (IFood)Activator.CreateInstance(foodType, name, price);

            return food;
        }
    }
}
