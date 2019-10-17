using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinjaUnit._3.Core_Unit_Testing_Techingues
{
    [TestFixture]
    class Testing_Strings
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {
            var formatter = new HtmlFormatter();

            var result = formatter.FormatAsBold("abc");

            
            Assert.That(result, Is.EqualTo("<strong>abc</strong>").IgnoreCase);

           
            Assert.That(result, Does.StartWith("<strong>").IgnoreCase);
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain("abc"));
        }
    }
}
