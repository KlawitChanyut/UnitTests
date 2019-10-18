using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinjaUnit._7.Testing_Book_Helper
{
    [TestFixture]
    public class Writing_The_First_Test
    {
        [Test]
        public void OverlappingBookingsExist_BookingStartAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {
            var repository = new Mock<IBookingRepository>();
            repository.Setup(r => r.GetActiveBookings(1)).Returns(new List<Booking>
            {
                new Booking
                {
                    Id = 2,
                    ArrivalDate = new DateTime(2017, 1, 15, 14, 0, 0),
                    DepartureDate = new DateTime(2017, 1, 20, 10, 0, 0),
                    Reference = "a",
                    
                }

            }.AsQueryable()); ;

            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 2,
                ArrivalDate = new DateTime(2017, 1, 15, 14, 0, 0),
                DepartureDate = new DateTime(2017, 1, 20, 10, 0, 0),
                Reference = "a",
            }, repository.Object);

            Assert.That(result, Is.Empty);
        }
    }
}
