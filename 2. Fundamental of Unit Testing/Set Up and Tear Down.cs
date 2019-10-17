using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinjaUnit._2.Fundamental_of_Unit_Testing
{
    [TestFixture]
    class Set_Up_and_Tear_Down
    {
        private Math _math;

        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {         
            var result = _math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }
    }
}
