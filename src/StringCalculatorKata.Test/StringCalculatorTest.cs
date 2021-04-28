using NUnit.Framework;
using StringCalculatorKata;

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
    }
}
