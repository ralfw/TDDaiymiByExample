using System;
using System.Collections.Generic;
using System.Linq;

namespace RPNDesktopCalculator.tests
{
    public class RPNCalculator
    {
        private readonly Stack<int> _stack;
        private readonly Dictionary<string, Func<Stack<int>, int>> _operations; 

        public RPNCalculator() : this(new Stack<int>()) {}
        public RPNCalculator(Stack<int> stack)
        {
            _stack = stack;

            _operations = new Dictionary<string, Func<Stack<int>, int>>
                {
                    {
                        "+", 
                        operands =>
                            {
                                var right = operands.Pop();
                                var left = operands.Pop();
                                return left + right;
                            }},
                    {
                        "-",
                        operands =>
                            {
                                var right = operands.Pop();
                                var left = operands.Pop();
                                return left - right;
                            }
                    },
                    {
                        "*",
                        operands =>
                            {
                                var right = operands.Pop();
                                var left = operands.Pop();
                                return left * right;
                            }
                    },                    
                    {
                        "/",
                        operands =>
                            {
                                var right = operands.Pop();
                                var left = operands.Pop();
                                return left / right;
                            }
                    },                       
                    {
                        "!",
                        operands =>
                            {
                                var operand = operands.Pop();
                                return Factorial(operand);
                            }
                    }
                };
        }


        public void Push(int number)
        {
            _stack.Push(number);
            Result(new Tuple<IEnumerable<int>, int>(_stack.Reverse(), number));
        }


        public void Calculate(Tuple<string, int> calcRequest)
        {
            _stack.Push(calcRequest.Item2);
            var operation = _operations[calcRequest.Item1];
            var result = operation(_stack);
            Result(new Tuple<IEnumerable<int>, int>(_stack.Reverse(), result));
        }

        public void Drop()
        {
            var number = _stack.Any() ? _stack.Pop() : 0;
            Result(new Tuple<IEnumerable<int>, int>(_stack.Reverse(), number));
        }


        public event Action<Tuple<IEnumerable<int>, int>> Result;


        int Factorial(int n)
        {
            if (n <= 1) return 1;
            return Factorial(n - 1)*n;
        }
    }
}