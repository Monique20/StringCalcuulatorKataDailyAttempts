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

        [TestCase("1",1)]
        [TestCase("5",5)]
        [TestCase("10",10)]
        public void Add_GivenASingleNumber_ShouldReturnThatNumber(string input, int expected)
        {
            //Arrange
            var sut = CreateStringCalculator();
            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2,6,8,9", 26)]
        [TestCase("5,4,30,9,7,10", 65)]
        [TestCase("10,4,8,2,3,6,500,400,8,0", 941)]
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
        [TestCase("//[****]***[%%%%%%%%%%]23\n1*2%3", 29)]
        [TestCase("//[%*][&!][(##)]\n3%*6&!11(##)22", 42)]
        public void Add_GivenDifferentDelimiters_ShouldReturnTheSum(string input, int expected)
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
            var input = "-1, -2, -2";
            var expected = "negatives not allowed: -1,-2,-2";
            var sut = CreateStringCalculator();

            //Act
            var actual = Assert.Throws<Exception>((() => sut.Add(input)));

            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        [Test]
        public void Add_GivenBothNegativeAndPositiveNumbers_ShouldThrowAnException()
        {
            //Arrange
            var input = "-1, -2, -2,1,9,6";
            var expected = "negatives not allowed: -1,-2,-2";
            var sut = CreateStringCalculator();

            //Act
            var actual = Assert.Throws<Exception>((() => sut.Add(input)));

            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase("1, 1000", 1001)]
        [TestCase("5, 1006", 5)]
        [TestCase("10, 5006", 10)]
        public void Add_GivenNumbersGreaterThan1000_ShouldNotAdd(string input, int expected)
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
