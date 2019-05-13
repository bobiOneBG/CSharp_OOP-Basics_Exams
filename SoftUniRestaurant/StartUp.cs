using SoftUniRestaurant.Core;

namespace SoftUniRestaurant
{
    public class StartUp
    {
        public static void Main()
        {
            RestaurantController rc = new RestaurantController();

            Engine engine = new Engine(rc);
            engine.Run();
        }
    }
}
