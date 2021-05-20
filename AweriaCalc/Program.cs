using System;

namespace AweriaCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello and welcome to AweriaCalc");
            Console.WriteLine("Enter the first number:");

            decimal firstNumber = ParseInput<decimal>();

            Console.WriteLine("Enter arithmetic operator:");

            char op = ParseInput<char>();

            Console.WriteLine("Enter the second number:");

            decimal secondNumber = ParseInput<decimal>();

            Calculate(firstNumber, op, secondNumber);
        }

        private static T ParseInput<T>() where T : struct
        {
            switch (typeof(T))
            {
                case var t when t == typeof(decimal): 
                    return (T)Convert.ChangeType(decimal.Parse(Console.ReadLine()), typeof(T));

                case var t when (t == typeof(string)) || (t == typeof(char)):
                    return (T)Convert.ChangeType(Console.ReadLine(), typeof(T));

                default: 
                    throw new NotImplementedException();
            }
        }

        private static void Calculate(decimal firstInput, char op, decimal secondInput)
        {
            switch (op)
            {
                case '+':
                    Calculator.Add(firstInput, secondInput, Output);
                    break;

                case '-':
                    Calculator.Subtract(firstInput, secondInput, Output);
                    break;

                case '*':
                    Calculator.Multiply(firstInput, secondInput, Output);
                    break;

                case '/':
                    Calculator.Divide(firstInput, secondInput, Output);
                    break;

                default:
                    break;
            }
        }

        private static void Output(decimal d)
        {
            Console.WriteLine($"Result of operation is: { d }");
        }
    }
}
