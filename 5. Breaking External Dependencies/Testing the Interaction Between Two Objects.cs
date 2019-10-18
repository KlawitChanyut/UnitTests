using NUnit.Framework;
using Moq;
using TestNinja.Mocking;

namespace TestNinjaUnit._5.Breaking_External_Dependencies
{
    [TestFixture]
    class Testing_the_Interaction_Between_Two_Objects
    {
        [Test]
        public void PlaceOrder_WhenCalled_StoreTheOrder()
        {
            var storage = new Mock<IStorage>();
            var service = new OrderService(storage.Object);

            var order = new Order();
            service.PlaceOrder(order);

            storage.Verify(s => s.Store(order));
        }
    }
}
