using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    internal class OrderServiceTests
    {
        [Test]
        public void PlaceOrder_WhenCalled_StoreOrder()
        {
            Mock<IStorage> storage = new Mock<IStorage>();
            OrderService service = new OrderService(storage.Object);

            Order order = new Order();
            service.PlaceOrder(order);
            storage.Verify(s => s.Store(order));
        }
    }
}
