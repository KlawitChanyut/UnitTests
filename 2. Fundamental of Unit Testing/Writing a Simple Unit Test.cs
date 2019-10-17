using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinjaUnit._2.Fundamental_of_Unit_Testing
{
    [TestFixture]
    class Writing_a_Simple_Unit_Test
    {
        [Test]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            var math = new Math();

            var result = math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }
    }
}
