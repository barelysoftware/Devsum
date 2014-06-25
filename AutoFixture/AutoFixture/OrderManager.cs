using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoFixture
{
    public class OrderManager
    {
        private readonly List<Order> _orderQueue;

        public OrderManager()
        {
            _orderQueue = new List<Order>();
        }

        public OrderManager(Order order) : this()
        {
            _orderQueue.Add(order);
        }

        public IEnumerable<Order> OrderQueue { get { return _orderQueue; } }

        public int OrderQueueLength { get { return _orderQueue.Count; } }

        public void AddOrder(Order order)
        {
            _orderQueue.Add(order);
        }

        public void AddOrders(IEnumerable<Order> orders)
        {
            _orderQueue.AddRange(orders);
        }

        public bool RemoveOrder(Order order)
        {
            return _orderQueue.Remove(order);
        }
   
        public bool RemoveOrder(string orderId)
        {
            var order = _orderQueue.FirstOrDefault(o => o.OrderId == orderId);

            return RemoveOrder(order);
        }


        public void Commit()
        {
            _orderQueue.Clear();
        }

    }
}
