using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinjaUnit._1.Getting_Started
{
    [TestFixture]
    class Using_NUnit_in_Visual_Studio
    {
        [Test]
        public void CanCalledBy_UserIsAdmin_ReturnTrue()
        {
            var reservation = new Reservation();

            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            Assert.That(result, Is.True);
        }
        [Test]
        public void CanCalledBy_SameUserCancellingTheReservation_ReturnTrue()
        {
            var user = new User();
            var reservation = new Reservation { MadeBy = user };

            var result = reservation.CanBeCancelledBy(user);


            Assert.That(result, Is.True);
        }
        [Test]
        public void CanCalledBy_AnotherUserCancellingReservation_ReturnFalse()
        {
            var reservation = new Reservation { MadeBy = new User() };

            var result = reservation.CanBeCancelledBy(new User());

            Assert.That(result, Is.False);
        }
    }
}
