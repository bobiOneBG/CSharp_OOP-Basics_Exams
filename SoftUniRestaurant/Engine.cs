namespace SoftUniRestaurant
{
    using System;
    using System.Linq;
    using SoftUniRestaurant.Core;

    public class Engine
    {
        private RestaurantController rc;

        public Engine(RestaurantController restaurantController)
        {
            this.rc = restaurantController;
        }

        public void Run()
        {
            string input;
            string result = null;
            string type;
            string name;
            decimal price;
            int tableNumber;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] args = input.Split().ToArray();
                string command = args[0];
                args = args.Skip(1).ToArray();
                try
                {
                    switch (command)
                    {
                        case "AddFood":
                            type = args[0];
                            name = args[1];
                            price = decimal.Parse(args[2]);
                            result = rc.AddFood(type, name, price);
                            break;

                        case "AddDrink":
                            type = args[0];
                            name = args[1];
                            int servingSize = int.Parse(args[2]);
                            string brand = args[3];
                            result = rc.AddDrink(type, name, servingSize, brand);
                            break;

                        case "AddTable":
                            type = args[0];
                            tableNumber = int.Parse(args[1]);
                            int capacity = int.Parse(args[2]);

                            result = rc.AddTable(type, tableNumber, capacity);
                            break;

                        case "ReserveTable":
                            int numberOfPeople = int.Parse(args[0]);

                            result = rc.ReserveTable(numberOfPeople);
                            break;

                        case "OrderFood":
                            tableNumber = int.Parse(args[0]);
                            string foodName = args[1];

                            result = rc.OrderFood(tableNumber, foodName);
                            break;

                        case "OrderDrink":
                            tableNumber = int.Parse(args[0]);
                            string drinkName = args[1];
                            string drinkBrand = args[2];

                            result = rc.OrderDrink(tableNumber, drinkName, drinkBrand);
                            break;

                        case "LeaveTable":
                            tableNumber = int.Parse(args[0]);

                            result = rc.LeaveTable(tableNumber);
                            break;

                        case "GetFreeTablesInfo":

                            result = rc.GetFreeTablesInfo();
                            break;

                        case "GetOccupiedTablesInfo":

                            result = rc.GetOccupiedTablesInfo();
                            break;
                    }
                }
                catch (Exception e)
                {
                    result = e.InnerException.Message;
                }

                Console.WriteLine(result);
            }

            result = rc.GetSummary();

            Console.WriteLine(result);
        }
    }
}