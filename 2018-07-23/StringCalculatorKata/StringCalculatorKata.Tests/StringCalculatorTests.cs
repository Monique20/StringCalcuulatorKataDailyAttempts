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
            var sut = new StringCalculator();

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
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,5,14,7", 27)]
        [TestCase("5,10,6,7,9", 37)]
        [TestCase("10,10,50,90", 160)]
        public void Add_GivenMultipleNumbers_ShouldReturnTheSum(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1\n5,14,7", 27)]
        [TestCase("5,10,6\n7,9", 37)]
        [TestCase("10\n10;50,90", 160)]
        public void Add_GivenDifferentDelimiters_ShouldReturnTheSum(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("-1,-2", "negatives not allowed: -1,-2")]
        [TestCase("-1,1,-2,6", "negatives not allowed: -1,-2")]
        public void Add_GivenNegativeNumbers_ShouldThrowAnException(string input, string expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = Assert.Throws<Exception>(()=> sut.Add(input));

            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

    }
}
