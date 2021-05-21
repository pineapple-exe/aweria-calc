﻿using System;
using System.Text.RegularExpressions;

namespace AweriaCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello and welcome to AweriaCalc");

            decimal firstNumber = Ask_Receive_Validate_Until_Satisfaction<decimal>("Enter the first number:", "Invalid input. Has to be a decimal.", new Regex("."));

            char op = Ask_Receive_Validate_Until_Satisfaction<char>("Enter arithmetic operator:", "Invalid input. Specify with either [+], [-], [*] or [/].", new Regex("[+\\-*/]"));

            decimal secondNumber = Ask_Receive_Validate_Until_Satisfaction<decimal>("Enter the second number:", "Invalid input. Has to be a decimal.", new Regex("."));

            Calculate(firstNumber, op, secondNumber);
        }

        private static T Ask_Receive_Validate_Until_Satisfaction<T>(string request, string errorMessage, Regex extraCondition) where T : struct
        {
            while (true)
            {
                Console.WriteLine(request);

                T value = ParseInput<T>(extraCondition, out bool correctFormat);

                if (!correctFormat)
                {
                    Console.WriteLine(errorMessage);
                    continue;
                }
                else
                    return value;
            }
        }

        private static T ParseInput<T>(Regex extraCondition, out bool correctFormat) where T : struct
        {
            switch (typeof(T))
            {
                case var t when t == typeof(decimal):
                    correctFormat = decimal.TryParse(Console.ReadLine(), out decimal number) && extraCondition.IsMatch(number.ToString());
                    return (T)Convert.ChangeType(number, typeof(T));

                case var t when (t == typeof(string)) || (t == typeof(char)):
                    correctFormat = char.TryParse(Console.ReadLine(), out char symbol) && extraCondition.IsMatch(symbol.ToString());
                    return (T)Convert.ChangeType(symbol, typeof(T));

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
