using System.Collections.Generic;
using System.Linq;

namespace AutoFixture
{
    public class Order
    {
        private readonly List<OrderRow> _orderRows;
        public Order(string orderId,string addressData)
        {
            OrderId = orderId;
            AddressData = addressData;
            _orderRows = new List<OrderRow>();
        }

        public Order(string orderId,string addressData,OrderRow orderRow):this(orderId,addressData)
        {
            _orderRows.Add(orderRow);
        }

        public string OrderId { get; private set; }

        public string AddressData { get; private set; }

        public IEnumerable<OrderRow> OrderRows { get { return _orderRows; } }

        public int OrderRowCount { get { return _orderRows.Count; } }

        public void AddOrderRow(OrderRow row)
        {
            _orderRows.Add(row);
        }

        public bool RemoveOrderRow(int orderRowId)
        {
            var orderRow = _orderRows.FirstOrDefault(or => or.Id == orderRowId);

            return orderRow != null && _orderRows.Remove(orderRow);
        }

        
        
    }
}
