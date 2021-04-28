using NUnit.Framework;
using StringCalculatorKata;
using System;

namespace StringCalculatorKata.Test
{
    public class StringCalculatorTest
    {
        [Test]
        public void Add_EmptyStringAsParam_ReturnsZero()
        {
            Assert.AreEqual(0, StringCalculator.Add(""));
        }

        [Test]
        public void Add_StringWithSingleNumberAsParam_ReturnsTheNumber()
        {
            Assert.AreEqual(5, StringCalculator.Add("5"));
        }

        [Test]
        public void Add_StringWithTwoNumbersAsParam_ReturnsTheirSum()
        {
            Assert.AreEqual(10, StringCalculator.Add("2,8"));
        }

        [Test]
        public void Add_StringWithThreeNumbersAsParam_ReturnsTheirSum()
        {
            Assert.AreEqual(14, StringCalculator.Add("2,8,4"));
        }

        [TestCase("1,2,3", 6)]
        [TestCase("1,0,0,0", 1)]
        [TestCase("7,3,8,2,5", 25)]
        [TestCase("28, 4, 10,0,0,0,7", 49)]
        [TestCase("1,2,3,4,5,6,7,8,9,10", 55)]
        public void Add_StringWithDifferentAmountofNumbers_ReturnsTheirSum(string numbers, int result)
        {
            Assert.AreEqual(result, StringCalculator.Add(numbers));
        }

        [Test]
        public void Add_StringWithNewLineAsDelimiter_ReturnsTheSumOfTheNumbers()
        {
            Assert.AreEqual(14, StringCalculator.Add("2\n8,4"));
        }

        [TestCase("//$\n1$2$3", 6)]
        [TestCase("//@\n2@3@4@9", 18)]
        [TestCase("//#\n17#28#3", 48)]
        public void Add_SyntaxSupportingDifferentDelimiters_AcceptsTheDifferentDelimiter(
            string numbers, int expected)
        {
            Assert.AreEqual(expected, StringCalculator.Add(numbers));
        }

        [Test]
        public void Add_StringWithNegativeNumberAsParam_ThrowsException()
        {
            string numbers = "1,2,3,-5";
            Assert.Throws<ArgumentException>(
                () => StringCalculator.Add(numbers),
                "negatives not allowed: -5");
        }

        [TestCase("1001, 1", 1)]
        [TestCase("1000, 1", 1001)]
        [TestCase("999, 1", 1000)]
        [TestCase("1,2,3,2021", 6)]
        public void Add_StringWithNumbersLargerThan100_ReturnsTheSumIgnoringNumbersLargerThan1000(
            string numbers,
            int expected
        )
        {
            Assert.AreEqual(expected, StringCalculator.Add(numbers));
        }
    }
}
