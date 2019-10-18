using NUnit.Framework;
using Moq;
using TestNinja.Mocking;
using System.Collections.Generic;

namespace TestNinjaUnit._6.Exercise
{
    [TestFixture]
    class Testing_Video_Service
    {
        private VideoServiceD _videoService;
        private Mock<IFileReader> _fileReader;
        private Mock<IRefacVideoRepository> _repository;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _repository = new Mock<IRefacVideoRepository>();
            _videoService = new VideoServiceD(_fileReader.Object,_repository.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnAnEmptyString()
        {
            _repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }
    }
}
