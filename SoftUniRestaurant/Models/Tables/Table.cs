namespace SoftUniRestaurant.Models.Tables
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Table : ITable
    {
        private readonly List<IFood> foodOrders;
        private readonly List<IDrink> drinkOrders;

        public int TableNumber { get; }
        private int capacity;
        private int numberOfPeople;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.IsReserved = false;
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new AggregateException("Capacity has to be greater than 0");
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get { return this.numberOfPeople; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                this.numberOfPeople = value;
            }
        }

        public IReadOnlyCollection<IFood> FoodOrders => this.foodOrders.AsReadOnly();
        public IReadOnlyCollection<IDrink> DrinkOrders => this.drinkOrders.AsReadOnly();

        public decimal PricePerPerson { get; }
        public bool IsReserved { get; private set; }

        public decimal Price => this.PricePerPerson * this.NumberOfPeople;


        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }

        public void OrderFood(IFood food)
        {
            this.foodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            return this.FoodOrders.Sum(f => f.Price) +
                this.DrinkOrders.Sum(d => d.Price) +
                this.Price;
        }

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();

            this.IsReserved = false;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().Trim();
        }

        public string GetOccupiedTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Number of people: {this.NumberOfPeople}");
            if (this.foodOrders.Count == 0)
            {
                sb.AppendLine($"Food orders: None");
            }
            else
            {
                sb.AppendLine($"Food orders: {this.foodOrders.Count}");

                foreach (var item in this.foodOrders)
                {
                    sb.AppendLine(item.ToString());
                }
            }


            if (this.drinkOrders.Count == 0)
            {
                sb.AppendLine($"Drink orders: None");
            }
            else
            {
                sb.AppendLine($"Drink orders: {this.drinkOrders.Count}");

                foreach (var item in this.drinkOrders)
                {
                    sb.AppendLine(item.ToString());
                }
            }
            return sb.ToString().Trim();
        }
    }
}
