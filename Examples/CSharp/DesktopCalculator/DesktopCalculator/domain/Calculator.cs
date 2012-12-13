using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesktopCalculator.domain
{
    class Calculator : ICalculator
    {
        public int Calculate(int number, string op)
        {
            return number + 1;
        }
    }
}
