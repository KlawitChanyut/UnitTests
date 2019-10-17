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
    }
}
