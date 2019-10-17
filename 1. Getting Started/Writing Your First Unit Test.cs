using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace TestNinjaUnit._1.Getting_Started
{
    [TestClass]
    class Writing_Your_First_Unit_Test
    {
        [TestMethod]
        public void CanCalledBy_UserIsAdmin_ReturnTrue()
        {
            var reservation = new Reservation();

            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            Assert.IsTrue(result);
        }
    }
}
