using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesktopCalculator.domain
{
    class Calculator : ICalculator
    {
        internal Func<int, int> _previousOp = i => 0 + i;

        public int Calculate(int currentNumber, string op)
        {
            var result = _previousOp(currentNumber);

            _previousOp = i => result + i;

            return result;
        }
    }
}
