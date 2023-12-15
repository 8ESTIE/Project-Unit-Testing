using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Fundamentals
{
    [TestFixture]
    internal class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _demeritPointsCalculator;
        [SetUp]
        public void SetUp()
        {
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }
        [Test]
        public void CalculateDemeritPoints_ArgumentOutOfRange_ThrowArgumentOutOfRangeException()
        {
            Assert.That(_demeritPointsCalculator.CalculateDemeritPoints(-1), Throws.Exception);
        }
        [Test]
        public void CalculateDemeritPoints_SpeedIsEqualToLimitSpeed_ReturnZero()
        {
            Assert.That(_demeritPointsCalculator.CalculateDemeritPoints(65), Is.EqualTo(0);
        }
        [Test]
        public void CalculateDemeritPoints_DemeritableSpeed_ReturnDemeritPoints()
        {
            Assert.That(_demeritPointsCalculator.CalculateDemeritPoints(70), Is.EqualTo(1);
        }
    }
}
