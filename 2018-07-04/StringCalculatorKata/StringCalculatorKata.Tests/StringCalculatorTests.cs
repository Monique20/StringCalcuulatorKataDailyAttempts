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
            StringCalculator sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1",1)]
        [TestCase("4",4)]
        [TestCase("10",10)]
        public void Add_GivenASingleNumber_ShouldReturnThatNumber(string input, int expected)
        {
            //Arrange
            StringCalculator sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2,8,9,6,3,4,5", 38)]
        [TestCase("4,5,7,1,0,20,50,36", 123)]
        [TestCase("10, 20,100,500,63,5,8,7,9,0,1,4", 727)]
        public void Add_GivenMultipleNumbers_ShouldReturnTheSum(string input, int expected)
        {
            //Arrange
            StringCalculator sut = CreateStringCalculator();

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
            StringCalculator sut = CreateStringCalculator();

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
            StringCalculator sut = CreateStringCalculator();

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
            var expected = "negatives not allowed: -1 -2 -3";
            StringCalculator sut = CreateStringCalculator();

            //Act
            var actual = Assert.Throws<Exception>((() => sut.Add(input)));

            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        [Test]
        public void Add_GivenNegativeNumbersAndPositive_ShouldThrowAnException()
        {
            //Arrange
            var input = "-1, -2, 3, 9, -5";
            var expected = "negatives not allowed: -1 -2 -5";
            StringCalculator sut = CreateStringCalculator();

            //Act
            var actual = Assert.Throws<Exception>((() => sut.Add(input)));

            //Assert
            Assert.AreEqual(expected, actual.Message);
        }

        [TestCase("1000,1", 1001)]
        [TestCase("1005,2", 2)]
        [TestCase("8000,5", 5)]
        public void Add_GivenANumberOver1000_ShouldNotAdd(string input, int expected)
        {
            //Arrange
            StringCalculator sut = CreateStringCalculator();

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
