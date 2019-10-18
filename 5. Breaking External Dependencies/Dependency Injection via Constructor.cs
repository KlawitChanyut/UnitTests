using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinjaUnit._5.Breaking_External_Dependencies
{
    [TestFixture]
    class Dependency_Injection_via_Constructor
    {
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            var service = new VideoServiceB(new FakeFileReader());
            
            var result = service.ReadVideoTitle();
                
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
