using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace TestNinjaUnit._1.Getting_Started
{
    [TestClass]
    class Testing_All_Execution_Test
    {
        [TestMethod]
        public void CanCalledBy_UserIsAdmin_ReturnTrue()
        {
            var reservation = new Reservation();

            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanCalledBy_SameUserCancellingTheReservation_ReturnTrue()
        {
            var user = new User();
            var reservation = new Reservation { MadeBy = user };

            var result = reservation.CanBeCancelledBy(user);

            Assert.IsTrue(result);
        }
    }
}
