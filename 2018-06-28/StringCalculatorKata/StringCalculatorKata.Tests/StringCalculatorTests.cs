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

        [TestCase("10,1", 11)]
        [TestCase("5,1", 6)]
        [TestCase("15,1", 16)]
        public void Add_GivenTwoNumbers_ShouldReturnTheSum(string input, int expected)
        {
            //Arrange
            var sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("10,1,5,6,3,2,2", 29)]
        [TestCase("5,1,5,2,6", 19)]
        [TestCase("15,1,2,9", 27)]
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
        //[TestCase("//[***]\n1***2***3", 6, 6)]
        //[TestCase("//[*][%]\n1*2%3", 6, 6)]
        //[TestCase("//[****]***[%%%%%%%%%%]23\n1*2%3", 29, 29)]
        //[TestCase("//[%*][&!][(##)]\n3%*6&!11(##)22", 42, 42)]
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
            var expected = "negatives not allowed:-1";

            var sut = CreateStringCalculator();

            //Act
            var actual = Assert.Throws<Exception>((() => sut.Add(input)));

            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        private static StringCalculator CreateStringCalculator()
        {
            return new StringCalculator();
        }
    }
}
