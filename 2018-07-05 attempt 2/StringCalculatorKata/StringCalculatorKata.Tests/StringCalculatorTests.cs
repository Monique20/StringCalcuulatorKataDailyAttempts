using NUnit.Framework;
using System;

namespace StringCalculatorKata.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Add_GivenAnEmptyString_ShouldReturn0(string input)
        {
            //Arrange
            var expected = 0;
            var sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1", 1)]
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

        [TestCase("1,5,8,9,6,3,1", 33)]
        [TestCase("55,2,4,7,8,0,10,5", 91)]
        [TestCase("10,4,0,6,9,3,0,140,40,5", 217)]
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
        [TestCase("//;\n1;2", 3)]
        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[*][%]\n1*2%3", 6)]
        [TestCase("//[&&!][%]\n1*2%3", 6)]
        [TestCase("//[##][%]\n1*2%3", 6)]
        [TestCase("//[##][%]\n1)*2(%3", 6)]
        public void Add_GivenDifferentDelimiters_ShouldReturnTheSum(string input, int expected)
        {
            //Arrange
            var sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("-1, -2, -9, -2")]
        public void Add_GivenNegativeNumbers_ShouldThrowAnException(string input)
        {
            //Arrange
            var sut = CreateStringCalculator();
            var expected = "negatives not allowed: -1,-2,-9,-2";

            //Act
            var actual = Assert.Throws<Exception>((() => sut.Add(input)));

            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase("-1, 2, 9, -2")]
        public void Add_GivenBothNegativeAndPositiveNumbers_ShouldThrowAnException(string input)
        {
            //Arrange
            var sut = CreateStringCalculator();
            var expected = "negatives not allowed: -1,-2";

            //Act
            var actual = Assert.Throws<Exception>((() => sut.Add(input)));

            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase("1, 1000", 1001)]
        [TestCase("5, 5000", 5)]
        [TestCase("10, 1005", 10)]
        public void Add_GivenANumberOver1000_ShouldReturnTheLowerNumber(string input, int expected)
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
