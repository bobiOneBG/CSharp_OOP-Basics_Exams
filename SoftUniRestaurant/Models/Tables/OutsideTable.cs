using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public class OutsideTable : Table
    {
        private const decimal InitialPricePerPerson = 3.50m;

        public OutsideTable(int tableNumber, int capacity)
            : base(tableNumber, capacity, InitialPricePerPerson)
        {
        }

        public void Reserve(int numberOfPeople){        }
        public void OrderFood(IFood food){ }
        public void OrderDrink(IDrink drink) { }
        public decimal GetBill() { return 0; }
        public void Clear() { }

    }


}
