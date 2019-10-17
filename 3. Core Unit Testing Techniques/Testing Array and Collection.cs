using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinjaUnit._3.Core_Unit_Testing_Techingues
{
    [TestFixture]
    class Testing_Array_and_Collection
    {
        private Math _math;

        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        //        [Ignore("Because I wanted to!")]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            var result = _math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }
    }
}
