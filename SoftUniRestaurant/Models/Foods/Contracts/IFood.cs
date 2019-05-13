namespace SoftUniRestaurant.Models.Foods.Contracts
{
    public interface IFood
    {
        string Name { get; }
        decimal Price { get; }
        int ServingSize { get; }

        string ToString();
    }
}
