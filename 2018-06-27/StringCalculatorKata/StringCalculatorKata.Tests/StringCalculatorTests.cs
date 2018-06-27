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
        [Test]
        public void Add_GivenAnEmptyString_ShouldReturn0()
        {
            //Arrange
            var input = "";
            var expected = 0;
            var sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenWhitespace_ShouldReturn0()
        {
            //Arrange
            var input = " ";
            var expected = 0;
            var sut = CreateStringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase("1", 1, 1)]
        [TestCase("5", 5, 5)]
        [TestCase("10", 10, 10)]
        public void Add_GivenASingleNumber_ShouldReturnThatNumber(string input, int expected, int actual)
        {
            //Arrange
            var sut = CreateStringCalculator();

            //Act
            sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2", 3)]
        [TestCase("5,5", 10)]
        [TestCase("9,2", 11)]
        public void Add_GivenTwoNumbers_ShouldReturnTheSum(string input, int expected)
        {
            //Arrange
            StringCalculator sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2,8,6,11,5,12", 45)]
        [TestCase("1,2,8,6,11,5,12,20,15,8,3,6", 97)]
        [TestCase("1,2,8,6,11,5,122,4,8,9,2,6,3,50", 237)]
        public void Add_GivenMultipleNumbers_ShouldReturnTheSum(string input, int expected)
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
