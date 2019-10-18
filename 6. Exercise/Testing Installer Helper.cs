using NUnit.Framework;
using TestNinja.Mocking;
using Moq;
using System.Net;

namespace TestNinjaUnit._6.Exercise
{
    [TestFixture]
    class Testing_Installer_Helper
    {
        private Mock<IFileDownloader> _fileDownloader;
        private Installer_Helper _installerHelper;

        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _installerHelper = new Installer_Helper(_fileDownloader.Object);
        }

        [Test]
        public void DownloadInstaller_DownloadFails_ReturnFalse()
        {
            _fileDownloader.Setup(fd =>
                fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.False);
        }
    }
}
