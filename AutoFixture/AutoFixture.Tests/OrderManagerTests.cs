using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;

namespace AutoFixture.Tests
{
    public class OrderManagerTests
    {
        
        [Fact]
        public void AddOrderRowToOrderTest()
        {
            //Arrange
            var order = new Order("AB-1234", "adress");
            var orderRow = new OrderRow(4711, 1, 1337, "Vingmutter", 5, 14.95);
            var expectedCount = order.OrderRowCount + 1;

            //Act
            order.AddOrderRow(orderRow);


            //Assert

            Assert.Equal(expectedCount,order.OrderRowCount);
        }

        [Fact]
        public void RemoveOrderRowFromOrderTest()
        {
            var orderRow = new OrderRow(4711, 1, 1337, "Vingmutter", 5, 14.95);
            var order = new Order("AB-1234", "adress",orderRow);
            var expectedCount = order.OrderRowCount - 1;

            order.RemoveOrderRow(4711);

            Assert.Equal(expectedCount,order.OrderRowCount);
        }

        [Fact]
        public void AddOrderToOrderQueueTest()
        {
            var orderManager = new OrderManager();
            var order = new Order("AB-1234", "address");
            var expectedCount = orderManager.OrderQueueLength + 1;

            orderManager.AddOrder(order);

            Assert.Equal(expectedCount,orderManager.OrderQueueLength);
        }

        [Fact]
        public void RemoveOrderByIdFromQueueTest()
        {
            var order = new Order("AB-1234", "address");
            var orderManager = new OrderManager(order);
            var expectedCount = orderManager.OrderQueueLength - 1;

            orderManager.RemoveOrder("AB-1234");

            Assert.Equal(expectedCount, orderManager.OrderQueueLength);

        }

        [Fact]
        public void CommitOrdersTest()
        {
            var order = new Order("AB-1234", "address");
            var orderManager = new OrderManager(order);
            
            orderManager.Commit();

            Assert.Equal(0,orderManager.OrderQueueLength);
        }

        [Fact]
        public void AddOrderListToQueue()
        {
            var orderManager = new OrderManager(new Order("AB-1337",""));
            var orderList = new[] {new Order("AB-1234", ""), new Order("AB-1235", ""), new Order("AB-1236", "")};
            var expectedCount = orderManager.OrderQueueLength + orderList.Count();

            orderManager.AddOrders(orderList);

            Assert.Equal(expectedCount,orderManager.OrderQueueLength);

        }

    }
}
