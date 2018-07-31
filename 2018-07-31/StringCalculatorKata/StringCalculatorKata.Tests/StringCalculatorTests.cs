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
        public void Add_GivenANullOrWhitespace_ShouldReturn0(string input)
        {
            //Arrange
            var expected = 0;
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1", 1)]
        [TestCase("5", 5)]
        [TestCase("10", 10)]
        public void Add_GivenSingleNumber_ShouldReturnThatNumber(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestCase("1,2,3,4", 10)]
        [TestCase("5,5,6,7,8", 31)]
        [TestCase("10,20,30,40", 100)]
        public void Add_GivenMultipleNumbers_ShouldReturnTheSum(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1\n2,3,4", 10)]
        [TestCase("5,5,6;7,8", 31)]
        [TestCase("10,20,30,40", 100)]
        public void Add_GivenDifferentDelimiters_ShouldReturnTheSum(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("-1,-2,-3,-4", "negative numbers not allowed: -1,-2,-3,-4")]
        [TestCase("5,-5,6,7,8", "negative numbers not allowed: -5")]
        public void Add_GivenNegativeNumbers_ShouldReturnTheSum(string input, string expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = Assert.Throws<Exception>(() => sut.Add(input));

            //Assert
            Assert.AreEqual(expected, actual.Message);
        }


        [TestCase("1, 999", 1000)]
        [TestCase("5, 1002", 5)]
        [TestCase("10, 1000", 1010)]
        public void Add_GivenANumberGreaterThan1000_ShouldNoAddThatNumber(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
