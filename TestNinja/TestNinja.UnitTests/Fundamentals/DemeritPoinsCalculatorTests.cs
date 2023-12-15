using NUnit.Framework;
using TestNinja.Fundamentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.UnitTests
{
    [TestFixture]
    internal class DemeritPoinsCalculatorTests
    {
        private DemeritPointsCalculator _demeritPointsCalculator;
        [SetUp]
        public void SetUp()
        {
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }
        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowArgumentOutOfRangeException(int speed)
        {
            Assert.That(() => _demeritPointsCalculator.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }
        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 0)]
        [TestCase(65, 0)]
        [TestCase(66, 0)]
        [TestCase(70, 1)]
        public void CalculateDemeritPoints_WhenCalled_DemeritPoints(int speed, int expectedresult)
        {
            Assert.That(_demeritPointsCalculator.CalculateDemeritPoints(speed), Is.EqualTo(expectedresult));
        }
    }
}
