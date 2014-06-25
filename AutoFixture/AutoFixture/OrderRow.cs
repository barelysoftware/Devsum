using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoFixture
{
    public class OrderRow
    {
        public OrderRow(int id, int order, int productId, string productName, int amount, double price)
        {
            Id = id;
            Order = order;
            ProductId = productId;
            ProductName = productName;
            Amount = amount;
            Price = price;
        }
        public int Id { get; private set; }

        public int Order { get; private set; }
        public int ProductId { get; private set; }

        public string ProductName { get; private set; }

        public int Amount { get; private set; }

        public double Price { get; private set; }

        public double TotalPrice { get { return Amount*Price; } }
    }
}
