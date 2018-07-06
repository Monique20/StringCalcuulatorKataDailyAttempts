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
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void Add_GivenAnEmptyStringOrNull_ShouldReturn0(string input)
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
        public void Add_GivenASingleNumber_ShouldReturnThatNumber( string input, int expected)
        {
            //Arrange
            var sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2", 3)]
        [TestCase("5,80,10,15,8",118)]
        [TestCase("10,36,87,0,4,2", 139)]
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
        [TestCase("20\n9,2;5", 36)]
        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[*][%]\n1*2%3", 6)]
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
        public void Add_GivenNegativeNumber_ShouldThrowAnException()
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
        public void Add_GivenNegativeNumbersAndPositiveNumbers_ShouldThrowAnException()
        {
            //Arrange
            var input = "-1,3,4,-4,4,-9";
            var expected = "negatives not allowed: -1,-4,-9";
            var sut = CreateStringCalculator();

            //Act
            var actual = Assert.Throws<Exception>((() => sut.Add(input)));

            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase("1, 999", 1000)]
        [TestCase("5,1000", 1005)]
        [TestCase("10, 1001", 10)]
        [TestCase("1000, 1000", 2000)]
        public void Add_GivenANumberOver1000_ShouldNotAdd(string input, int expected)
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
