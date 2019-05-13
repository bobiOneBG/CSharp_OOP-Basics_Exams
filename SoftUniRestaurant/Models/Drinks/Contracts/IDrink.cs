namespace SoftUniRestaurant.Models.Drinks.Contracts
{
    public interface IDrink
    {
        string Brand { get; }
        string Name { get; }
        decimal Price { get; }
        int ServingSize { get; }

        string ToString();
    }
}
