﻿using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinjaUnit._7.Testing_Book_Helper
{
    [TestFixture]
    public class Fixing_a_Bug
    {
        private Booking _existingBooking;
        private Mock<IBookingRepository> _repository;

        [SetUp]
        public void SetUp()
        {
            _existingBooking = new Booking
            {
                Id = 2,
                ArrivalDate = ArriveOn(2017, 1, 15),
                DepartureDate = DepartOn(2017, 1, 20),
                Reference = "a"

            };

            _repository = new Mock<IBookingRepository>();

            _repository.Setup(r => r.GetActiveBookings(1)).Returns(new List<Booking>
            {
               _existingBooking

            }.AsQueryable()); ;
        }

        [Test]
        public void OverlappingBookingsExist_BookingStartAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {


            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 2,
                ArrivalDate = Before(_existingBooking.ArrivalDate, days: 2),
                DepartureDate = Before(_existingBooking.ArrivalDate),
                Reference = "a",
            }, _repository.Object);

            Assert.That(result, Is.Empty);
        }
    }
}
