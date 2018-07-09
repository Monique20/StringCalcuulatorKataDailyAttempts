using NUnit.Framework;

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
            StringCalculator sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1",1)]
        [TestCase("2",2)]
        [TestCase("3",3)]
        public void Add_GivenNumberASingleNumber_ShouldReturnThatNumber(string input, int expected)
        {
            //Arrange
            StringCalculator sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1,2", 3)]
        [TestCase("1,8,9,3,5,4", 30)]
        [TestCase("1,8,9", 18)]
        public void Add_GivenMultipleNumbers_ShouldReturnSum(string input, int expected)
        {
            //Arrange
            StringCalculator sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenNewLineDelimiter_ShouldReturnSum()
        {
            //Arrange
            var input = "1\n2,3";
            var expected = 6;
            StringCalculator sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Add_GivenSemiColonDelimiter_ShouldReturnSum()
        {
            //Arrange
            var input = "//;\n1;2";
            var expected = 3;
            StringCalculator sut = new StringCalculator();

            //Act
            var actual = sut.Add(input);

            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
