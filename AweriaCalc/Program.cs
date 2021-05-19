using System;
using System.Threading.Tasks;

namespace AweriaCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello and welcome to AweriaCalc");
            Console.WriteLine("Enter the frist number:");

            var firstNumber = ParseInput<decimal>();

            Console.WriteLine("Enter arithmetic operator");

            var op = ParseInput<char>();

            Console.WriteLine("Enter the second number");

            var secondNumber = ParseInput<decimal>();

            CAlcuate(firstNumber, op, secondNumber);
        }

        private static T ParseInput<T>() where T : struct
        { 
            switch (typeof(T))
            {
                case var t when t == typeof(decimal): { 
                return (T)Convert.ChangeType(decimal.Parse(Console.ReadLine()), typeof(T)); }
                case var t when (t == typeof(string)) || (t == typeof(char)): {
                return (T)Convert.ChangeType(Console.ReadLine(), typeof(T)); }
                default: 
                throw new NotImplementedException();
            }
        }

        protected static void CAlcuate(decimal firstInput, char op, decimal secondInput)
        {
            Calculator calcuator = new();
            switch (op)
            {
                case '+':
                    calcuator.Add(firstInput, secondInput, x => Output(x));
                    break;
                case '-':
                    Subtract(firstInput, secondInput);
                    break;
                default:
                    break;
            }
        }

        private static void Subtract(decimal first, decimal second) => 
            Output(second - first);

        protected static async Task Output(decimal d)
        {
            Console.WriteLine($"Result of operation is: { d }");
        }
    }
}
