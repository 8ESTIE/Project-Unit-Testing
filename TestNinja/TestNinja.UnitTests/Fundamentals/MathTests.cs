using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    internal class MathTests
    {
        private Math _math;

        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }
        [Test]
        public void Add_WhenCalled_ReturnSumOfItems()
        {

            int result = _math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }
        [Test]
        [TestCase(1, 1, 1)]
        [TestCase(1, 2, 2)]
        [TestCase(2, 1, 2)] 
        public void Max_WhenCalled_ReturnGreaterArgument(int a, int b, int expectedResult)
        {

            int result = _math.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}