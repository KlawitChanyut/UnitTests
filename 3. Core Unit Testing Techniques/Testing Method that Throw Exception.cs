using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinjaUnit._3.Core_Unit_Testing_Techingues
{
    [TestFixture]
    class Testing_Method_That_throw_Exception
    {
        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            var logger = new ErrorLogger();

            logger.Log("a");

            Assert.That(logger.LastError, Is.EqualTo("a"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            var logger = new ErrorLogger();

            Assert.That(() => logger.Log(error), Throws.ArgumentNullException);

        }
    }
}
