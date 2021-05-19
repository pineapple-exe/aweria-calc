using System;
using Xunit;

namespace AweriaCalc.Tests
{
    public class CalculatorTEsts
    {
        protected readonly Calculator _classUnderTest;
        public CalculatorTEsts()
        {
            _classUnderTest = new Calculator();
        }

        [Fact]
        public void Adding_Two_Numbers_Yields_Correct_Result()
        {
            var expected = 20;
            decimal actual = default;

            _classUnderTest.Add(10, 10, x => actual = x);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Subtracting_Two_Numbers_Yields_Correct_Result()
        {
            var expected = 0;
            decimal actual = default;

            _classUnderTest.Subtract(10, 10, x => actual = x);

            Assert.Equal(expected, actual);
        }
    }
}
