using System;

namespace AweriaCalc
{
    public static class Calculator
    {
        public static void Add(decimal firstValue, decimal secondValue, Action<decimal> action)
        {
            action(firstValue + secondValue);
        }

        public static void Subtract(decimal firstValue, decimal secondValue, Action<decimal> action)
        {
            action(firstValue - secondValue);
        }

        public static void Multiply(decimal firstValue, decimal secondValue, Action<decimal> action)
        {
            action(firstValue * secondValue);
        }

        public static void Divide(decimal firstValue, decimal secondValue, Action<decimal> action)
        {
            action(firstValue / secondValue);
        }
    }
}
