using TestNinja.Mocking;
using NUnit.Framework;


namespace TestNinjaUnit._5.Breaking_External_Dependencies
{
    [TestFixture]
    class Dependency_Injection_via_Method_Parameters
    {    
        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            var service = new Video_Service();
            var result = service.ReadVideoTitle(new FakeFileReader());

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
