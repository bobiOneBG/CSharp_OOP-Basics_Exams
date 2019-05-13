namespace SoftUniRestaurant.Models.Tables.Contracts
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using System.Collections.Generic;

    public interface ITable
    {
        int Capacity { get; }
        IReadOnlyCollection<IDrink> DrinkOrders { get; }
        IReadOnlyCollection<IFood> FoodOrders { get; }
        bool IsReserved { get; }
        int NumberOfPeople { get; }
        decimal Price { get; }
        decimal PricePerPerson { get; }
        int TableNumber { get; }

        void Clear();
        decimal GetBill();
        string GetFreeTableInfo();
        string GetOccupiedTableInfo();
        void OrderDrink(IDrink drink);
        void OrderFood(IFood food);
        void Reserve(int numberOfPeople);
    }
}
