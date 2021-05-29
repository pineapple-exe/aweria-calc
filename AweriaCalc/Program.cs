using System;
using System.Text.RegularExpressions;

namespace AweriaCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello and welcome to AweriaCalc");

            decimal firstNumber = AskReceiveValidateUntilSatisfaction<decimal>(
                "Enter the first number:",
                "Invalid input. Has to be a decimal.",
                new Regex("."));

            char op = AskReceiveValidateUntilSatisfaction<char>(
                "Enter arithmetic operator:", 
                "Invalid input. Specify with either [+], [-], [*] or [/].", 
                new Regex("[+\\-*/]"));

            decimal secondNumber = AskReceiveValidateUntilSatisfaction<decimal>(
                "Enter the second number:", 
                "Invalid input. Has to be a decimal.", 
                new Regex("."));

            Calculate(firstNumber, op, secondNumber);
        }

        private static T AskReceiveValidateUntilSatisfaction<T>(string request, string errorMessage, Regex extraCondition) where T : struct
        {
            while (true)
            {
                Console.WriteLine(request);

                bool correctFormat = TryParseInput<T>(extraCondition, out T result);

                if (!correctFormat)
                {
                    Console.WriteLine(errorMessage);
                    continue;
                }
                else
                    return result;
            }
        }

        private static bool TryParseInput<T>(Regex extraCondition, out T result) where T : struct
        {
            switch (typeof(T))
            {
                case var t when t == typeof(decimal):
                    { 
                        bool correctFormat = decimal.TryParse(Console.ReadLine(), out decimal number) && extraCondition.IsMatch(number.ToString());
                        result = (T)Convert.ChangeType(number, typeof(T));
                        return correctFormat;
                    }

                case var t when (t == typeof(char)):
                    { 
                        bool correctFormat = char.TryParse(Console.ReadLine(), out char symbol) && extraCondition.IsMatch(symbol.ToString());
                        result = (T)Convert.ChangeType(symbol, typeof(T));
                        return correctFormat;
                    }

                default: 
                    throw new NotImplementedException();
            }
        }

        private static void Calculate(decimal firstInput, char op, decimal secondInput)
        {
            switch (op)
            {
                case '+':
                    Print(Calculator.Add(firstInput, secondInput));
                    break;

                case '-':
                    Print(Calculator.Subtract(firstInput, secondInput));
                    break;

                case '*':
                    Print(Calculator.Multiply(firstInput, secondInput));
                    break;

                case '/':
                    Print(Calculator.Divide(firstInput, secondInput));
                    break;

                default:
                    break;
            }
        }

        private static void Print(decimal d)
        {
            Console.WriteLine($"Result of operation is: { d }");
        }
    }
}
