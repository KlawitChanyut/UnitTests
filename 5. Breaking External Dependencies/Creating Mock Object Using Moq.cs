using NUnit.Framework;
using Moq;
using TestNinja.Mocking;

namespace TestNinjaUnit._5.Breaking_External_Dependencies
{
    [TestFixture]
    class Creating_Mock_Object_Using_Moq
    {
        private VideoServiceC _videoService;
        private Mock<IFileReader> _fileReader;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _videoService = new VideoServiceC(_fileReader.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
