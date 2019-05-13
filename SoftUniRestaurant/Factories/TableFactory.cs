namespace SoftUniRestaurant.Factories
{
    using SoftUniRestaurant.Models.Tables.Contracts;
    using System;

    public class TableFactory
    {
        public ITable CreateTable(string type, int tableNumber, int capacity)
        {
            Type tableType = Type.GetType("SoftUniRestaurant.Models.Tables." + type + "Table");

            var table = (ITable)Activator.CreateInstance(tableType, tableNumber, capacity);

            return table;
        }
    }
}
