using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinjaUnit._3.Core_Unit_Testing_Techingues
{
    [TestFixture]
    class Testing_Void_Methods
    {
        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            var logger = new ErrorLogger();

            logger.Log("a");

            Assert.That(logger.LastError, Is.EqualTo("a"));
        }
    }
}
