using NUnit.Framework;
using TestNinja.Fundamentals;


namespace TestNinjaUnit._4.Exercise
{
    [TestFixture]
    public class Solution_FizzBuzz
    {
        private Exercise_Fizz_Buzz FizzBuzz;
        [SetUp]
        public void SetUp()
        {
            FizzBuzz = new Exercise_Fizz_Buzz();
        }
        [Test]
        public void GetOutput_InputIsDivisibleBy3And5_ReturnFizzBuzz()
        {
            var result = Exercise_Fizz_Buzz.GetOutput(15);

            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }
        [Test]
        public void GetOutput_InputIsDivisibleBy3Only_ReturnFizz()
        {
            var result = Exercise_Fizz_Buzz.GetOutput(3);

            Assert.That(result, Is.EqualTo("Fizz"));
        }
    }
}
