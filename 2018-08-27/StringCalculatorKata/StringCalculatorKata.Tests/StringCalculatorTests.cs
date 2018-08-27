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
        public void Add_GivenAnEmptyOrWhitespace_ShouldReturn0(string input)
        {
            //Arrange
            var expected = 0;
            var stringCalculator = CreateStringCalculator();

            //Act
            var actual = stringCalculator.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1", 1)]
        [TestCase("5", 5)]
        [TestCase("10", 10)]
        public void Add_GivenSingleNumber_ShouldReturnThatNumber(string input, int expected)
        {
            //Arrange
            var stringCalculator = CreateStringCalculator();

            //Act
            var actual = stringCalculator.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2,3", 6)]
        [TestCase("5,5,5", 15)]
        [TestCase("10,10,10", 30)]
        [TestCase("55,2,4,7,8,0,10,5", 91)]
        [TestCase("10,4,0,6,9,3,0,140,40,5", 217)]
        public void Add_GivenMultipleNumbers_ShouldReturnTheSum(string input, int expected)
        {
            //Arrange
            var stringCalculator = CreateStringCalculator();

            //Act
            var actual = stringCalculator.Add(input);

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
            var stringCalculator = CreateStringCalculator();

            //Act
            var actual = stringCalculator.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("-1,-2", "negatives not allowed: -1,-2")]
        [TestCase("5,-5", "negatives not allowed: -5")]
        public void Add_GivenNegativeNumbers_ShouldThroeAnException(string input, string expected)
        {
            //Arrange
            var stringCalculator = CreateStringCalculator();

            //Act
            var actual = Assert.Throws<Exception>(() => stringCalculator.Add(input));

            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase("1, 999", 1000)]
        [TestCase("5, 1000", 1005)]
        [TestCase("10, 1002", 10)]
        public void Add_GivenNumbersGreaterThan1000_ShouldNotAddTheNumber(string input, int expected)
        {
            //Arrange
            var stringCalculator = CreateStringCalculator();

            //Act
            var actual = stringCalculator.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        private static StringCalculator CreateStringCalculator()
        {
            return new StringCalculator();
        }

    }
}
