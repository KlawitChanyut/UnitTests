using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinjaUnit._2.Fundamental_of_Unit_Testing
{
    [TestFixture]
    class Ignoring_Test
    {
        private Math _math;
        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }
    }
}
