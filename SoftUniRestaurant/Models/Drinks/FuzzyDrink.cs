﻿namespace SoftUniRestaurant.Models.Drinks
{
    public class FuzzyDrink : Drink
    {
        private const decimal FuzzyDrinkPrice = 2.50m;

        public FuzzyDrink(string name, int servingSize, string brand)
            : base(name, servingSize, FuzzyDrinkPrice, brand)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
