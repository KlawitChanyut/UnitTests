using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinjaUnit._4.Exercise
{
    [TestFixture]
    class Solution_Demerit_Point_Calculator
    {
        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowArgumentOutOfRangeException(int speed)
        {
            var calculator = new DemeritPointsCalculator();

            Assert.That(() => calculator.CalculateDemeritPoints(speed),
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
