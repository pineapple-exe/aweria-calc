using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AweriaCalc
{
    interface ICalculator
    {
        public void Add(decimal f, decimal s, Action<decimal> a);
    }
}
