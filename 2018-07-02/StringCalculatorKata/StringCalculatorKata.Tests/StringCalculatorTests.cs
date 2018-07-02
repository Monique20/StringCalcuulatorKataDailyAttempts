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
        [TestCase("", 0)]
        [TestCase(" ", 0)]
        [TestCase(null, 0)]
        public void Add_GivenAnEmptyStringOrWhitespace_ShouldReturn0(string input, int expected)
        {
            //Arrange
            var sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("2", 2)]
        [TestCase("5", 5)]
        [TestCase("10", 10)]
        public void Add_GivenASingleNumber_ShouldReturnThatNumber(string input, int expected)
        {
            //Arrange
            var sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2", 3)]
        [TestCase("4,5", 9)]
        [TestCase("10, 500", 510)]
        public void Add_GivenTwoNumbers_ShouldReturnTheSum(string input, int expected)
        {
            //Arrange
            var sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2,5,6,9,3,4", 30)]
        [TestCase("4,5,11,15,10,1,6,8,9,3", 72)]
        [TestCase("10, 500,100,8,9,3,5,0,22,11,52,54", 774)]
        public void Add_GivenMultipleNumbers_ShouldReturnTheSum(string input, int expected)
        {
            //Arrange
            var sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1\n2,3", 6)]
        [TestCase("//***\n5,58*7", 70)]
        [TestCase("//;\n1;2", 3)]
        public void Add_GivenCustomDelimiters_ShouldReturnTheSum(string input, int expected)
        {
            //Arrange
            var sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenNegativeNumbers_ShouldThrowAnException()
        {
            //Arrange
            var input = "-1";
            var expected = "negatives not allowed: -1";
            var sut = CreateStringCalculator();

            //Act
            var actual = Assert.Throws<Exception>((() => sut.Add(input)));

            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        [Test]
        public void Add_GivenMultipleNegativeNumbers_ShouldThrowAnException()
        {
            //Arrange
            var input = "-1, -2, -3";
            var expected = "negatives not allowed: -1, -2, -3";
            var sut = CreateStringCalculator();

            //Act
            var actual = Assert.Throws<Exception>((() => sut.Add(input)));

            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase("2, 1000", 1002)]
        [TestCase("5, 1005", 5)]
        [TestCase("3, 5000", 3)]
        public void Add_GivenNumberGreaterThan1000_ShouldNotCalculate(string input, int expected)
        {
            //Arrange
          
            var sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        private static StringCalculator CreateStringCalculator()
        {
            return new StringCalculator();
        }
    }
}
