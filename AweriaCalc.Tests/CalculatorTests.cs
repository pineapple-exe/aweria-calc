using Xunit;

namespace AweriaCalc.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(3, -4, -1)]
        [InlineData(-5, -6, -11)]
        public void Adding_Two_Numbers_Yields_Correct_Result(decimal firstValue, decimal secondValue, decimal expected)
        {
            decimal actual = default;

            Calculator.Add(firstValue, secondValue, x => actual = x);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 2, -1)]
        [InlineData(3, -4, 7)]
        [InlineData(-5, -6, 1)]
        public void Subtracting_Two_Numbers_Yields_Correct_Result(decimal firstValue, decimal secondValue, decimal expected)
        {
            decimal actual = default;

            Calculator.Subtract(firstValue, secondValue, x => actual = x);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(3, -4, -12)]
        [InlineData(-5, -6, 30)]
        public void Multiplying_Two_Numbers_Yields_Correct_Result(decimal firstValue, decimal secondValue, decimal expected)
        {
            decimal actual = default;

            Calculator.Multiply(firstValue, secondValue, x => actual = x);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 2, 0.5)]
        [InlineData(3, -4, -0.75)]
        [InlineData(-5, -8, 0.625)]
        public void Dividing_Two_Numbers_Yields_Correct_Result(decimal firstValue, decimal secondValue, decimal expected)
        {
            decimal actual = default;

            Calculator.Divide(firstValue, secondValue, x => actual = x);

            Assert.Equal(expected, actual);
        }
    }
}
