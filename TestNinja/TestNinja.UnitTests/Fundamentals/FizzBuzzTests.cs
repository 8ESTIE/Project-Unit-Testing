using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    internal class FizzBuzzTests
    {
        [Test]
        public void GetOutput_NotMultiplyOfThreeOrFive_ReturnSameNumberToString()
        {
            string result = FizzBuzz.GetOutput(7);

            Assert.That(result, Is.EqualTo("7"));
        }
        [Test]
        public void GetOutput_MultiplyOfThreeAndFive_ReturnFizzBuzz()
        {
            Assert.That(FizzBuzz.GetOutput(15), Is.EqualTo("FizzBuzz"));
        }
        [Test]
        public void GetOutput_OnlyMultiplyOfFve_ReturnBuzz()
        {
            Assert.That(FizzBuzz.GetOutput(5), Is.EqualTo("Buzz"));
        }
        [Test]
        public void GetOutput_OnlyMultiplyOfThree_ReturnFizz()
        {
            Assert.That(FizzBuzz.GetOutput(3), Is.EqualTo("Fizz"));
        }
    }
}
