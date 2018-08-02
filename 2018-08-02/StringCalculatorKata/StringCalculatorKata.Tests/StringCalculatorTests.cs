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
        public void Add_GivendANullOrWhitespace_ShouldReturn0(string input)
        {
            //Arrange
            var expected = 0;
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1",1)]
        [TestCase("3",3)]
        [TestCase("120",120)]
        public void Add_GivendASingleNumber_ShouldReturnThatNumber(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,4,3", 8)]
        [TestCase("3,5,6,7", 21)]
        [TestCase("120,50,40,60", 270)]
        public void Add_GivenMultipleNumbers_ShouldReturnTheSum(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,4,3", 8)]
        [TestCase("3,5\n6,7", 21)]
        [TestCase("120,50;40,60", 270)]
        public void Add_GivenDifferentDelimiters_ShouldReturnTheSum(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("-1,-4,-3", "negatives not allowed: -1,-4,-3")]
        [TestCase("-1,4,-3", "negatives not allowed: -1,-3")]
        public void Add_GivenNegativeNumbers_ShouldThrowAnException(string input, string expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = Assert.Throws<Exception>(() => sut.Add(input));

            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase("1, 999", 1000)]
        [TestCase("1, 1000", 1001)]
        [TestCase("1, 1020", 1)]
        public void Add_GivenNumberMoreThan1000_ShouldNotAddThatNumber(string input, int expected)
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
