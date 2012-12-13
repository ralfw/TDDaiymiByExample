using System;

namespace DesktopCalculator.domain
{
    class Calculator : ICalculator
    {
        internal Func<int, int> _previousOp = i => i;

        public int Calculate(int currentNumber, string op)
        {
            var result = _previousOp(currentNumber);

            _previousOp = Remember_op(op, result);

            return result;
        }

        static Func<int,int> Remember_op(string op, int result)
        {
            switch (op)
            {
                case "+":
                    return i => result + i;
                case "-":
                    return i => result - i;
                case "*":
                    return i => result * i;
                case "/":
                    return i => result / i;
                default:
                    return i => i;
            }
        } 
    }
}
