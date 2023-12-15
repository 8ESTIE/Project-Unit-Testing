using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    internal class VideoServicesTests
    {
        Mock<IFileReader> _fileReader;
        VideoService _service;
        Mock<IVideoDirectory> _directory;
        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _directory = new Mock<IVideoDirectory>();
            _service = new VideoService(_fileReader.Object, _directory.Object);
        }
        [Test]
        public void ReadVideoTitle_EmptyFie_ReturnError()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            string result = _service.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AlllVideosAreProcessed_ReturnEmptyString()
        {
            _directory.Setup(dt => dt.GetUnprocessedVideos()).Returns(new List<Video>());

            string result = _service.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_WhenCalled_Return()
        {
            _directory.Setup(dt => dt.GetUnprocessedVideos()).Returns(new List<Video>()
            {
                new Video{Id=1},
                new Video{Id=2},
                new Video{Id=3}
            });

            string result = _service.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}