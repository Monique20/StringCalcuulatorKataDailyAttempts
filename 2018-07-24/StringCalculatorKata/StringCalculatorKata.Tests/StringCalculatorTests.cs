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
        public void Add_GivenANullOrWHitespace_ShouldReturn0(string input)
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

        [TestCase("1,8,9,6,3", 27)]
        [TestCase("5,7,8,5,2", 27)]
        [TestCase("10,20,50,40", 120)]
        public void Add_GivenMultipleNumbers_ShouldReturnTheSum(string input, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

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
            var sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("-1,-8,-9,-6,-3", "negatives not allowed: -1,-8,-9,-6,-3")]
        [TestCase("5,-7,8,5,-2", "negatives not allowed: -7,-2")]
        public void Add_GivenNegativeNumbers_ShouldThrowAnException(string input, string expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var actual = Assert.Throws<Exception>(() => sut.Add(input));

            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase("1,999", 1000)]
        [TestCase("5,1000", 1005)]
        [TestCase("10, 1001", 10)]
        public void Add_GivenNumbersover1000_ShouldNotAdd(string input, int expected)
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
