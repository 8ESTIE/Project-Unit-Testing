using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TestNinja.Mocking.InstallerHelper;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    internal class InstallerHelperTests
    {
        Mock<IInstallerGetter> _installerGetter;
        InstallerHelper _installerHelper;
        [SetUp]
        public void SetUp()
        {
            _installerGetter = new Mock<IInstallerGetter>();
            _installerHelper = new InstallerHelper();
        }
        [Test]
        public void DownloadInstaller_WhenCalled_ReturnTrue()
        {
            _installerGetter.Setup(id => id.DownloadInstaller("a", "a")).Returns(true);

            Assert.That(_installerHelper.DownloadInstallerHelper("a", "a", _installerGetter.Object), Is.True);
        }
        [Test]
        public void DownloadInstaller_InvalidArguments_ReturnFalse()
        {
            _installerGetter.Setup(id => id.DownloadInstaller("", "")).Returns(false);

            Assert.That(_installerHelper.DownloadInstallerHelper("", "", _installerGetter.Object), Is.False);
        }
    }
}
