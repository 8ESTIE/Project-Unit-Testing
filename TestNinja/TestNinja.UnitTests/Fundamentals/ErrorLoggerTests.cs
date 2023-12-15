using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    internal class ErrorLoggerTests
    {
        private ErrorLogger _logger;
        [SetUp]
        public void SetUp()
        {
            _logger = new ErrorLogger();
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error) 
        {
            Assert.That(() => _logger.Log(error), Throws.ArgumentNullException);
        }
        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            Guid id = Guid.Empty;
            _logger.ErrorLogged += (sender, args) => { id = args; };

            _logger.Log("a");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
