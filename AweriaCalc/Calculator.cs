using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AweriaCalc
{
    public class Calculator : ICalculator
    {
        public void Add(decimal f, decimal s, Action<decimal> a)
        {
            a(f + s);
        }

        public void Subtract(decimal firstValue, decimal secondValue, Action<decimal> output)
        {
            output(secondValue - firstValue);
        }
    }
}
