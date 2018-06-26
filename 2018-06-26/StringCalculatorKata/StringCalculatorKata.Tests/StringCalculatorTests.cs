using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void Add_GivenAnEmptyString_ShouldReturn0()
        {
            //Arrange
            var number = "";
            var expected = 0;
            var sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(number);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenWhiteSpace_ShouldReturn0()
        {
            //Arrange
            var number = " ";
            var expected = 0;
            var sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(number);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestCase("1", 1, 1)]
        [TestCase("5", 5, 5)]
        [TestCase("10", 10, 10)]
        public void Add_GivenASingleNumber_ShouldReturnThatNumber(string number, int expected, int actual)
        {
            //Arrange
            var sut = CreateStringCalculator();

            //Act
            actual = sut.Add(number);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenTwoNumbers_ShouldReturnSum()
        {
            //Arrange
            var number = "1,2";
            var expected = 3;
            var sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(number);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        private static StringCalculator CreateStringCalculator()
        {
            return new StringCalculator();
        }
    }
}
