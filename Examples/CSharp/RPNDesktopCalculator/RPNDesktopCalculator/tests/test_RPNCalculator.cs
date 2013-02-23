using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RPNDesktopCalculator.tests
{
    [TestFixture]
    public class test_RPNCalculator
    {
        [Test]
        public void Push_on_empty_stack()
        {
            var sut = new RPNCalculator();

            Tuple<IEnumerable<int>, int> result = null;
            sut.Result += _ => result = _;
            sut.Push(1);

            Assert.AreEqual(new[]{1}, result.Item1);
            Assert.AreEqual(1, result.Item2);
        }

        [Test]
        public void Push_number_on_non_empty_stack()
        {
            var initialStack = new Stack<int>();
            initialStack.Push(1);
            var sut = new RPNCalculator(initialStack);

            Tuple<IEnumerable<int>, int> result = null;
            sut.Result += _ => result = _;
            sut.Push(2);

            Assert.AreEqual(new[] { 1, 2 }, result.Item1);
            Assert.AreEqual(2, result.Item2);
        }


        [Test]
        public void Add_number_to_single_value_stack()
        {
            var initialStack = new Stack<int>();
            initialStack.Push(2);
            var sut = new RPNCalculator(initialStack);

            Tuple<IEnumerable<int>, int> result = null;
            sut.Result += _ => result = _;
            sut.Calculate(new Tuple<string, int>("+", 3));

            Assert.AreEqual(new int[]{}, result.Item1);
            Assert.AreEqual(5, result.Item2);
        }

        [Test]
        public void Add_number_to_stack_top()
        {
            var initialStack = new Stack<int>();
            initialStack.Push(2);
            initialStack.Push(3);
            var sut = new RPNCalculator(initialStack);

            Tuple<IEnumerable<int>, int> result = null;
            sut.Result += _ => result = _;
            sut.Calculate(new Tuple<string, int>("+", 4));

            Assert.AreEqual(new[]{2}, result.Item1);
            Assert.AreEqual(7, result.Item2);
        }


        [Test]
        public void Drop_number_from_empty_stack()
        {
            var initialStack = new Stack<int>();
            var sut = new RPNCalculator(initialStack);

            Tuple<IEnumerable<int>, int> result = null;
            sut.Result += _ => result = _;
            sut.Drop();

            Assert.AreEqual(new int[] { }, result.Item1);
            Assert.AreEqual(0, result.Item2);
        }

        [Test]
        public void Drop_number_from_non_empty_stack()
        {
            var initialStack = new Stack<int>();
            initialStack.Push(1);
            var sut = new RPNCalculator(initialStack);

            Tuple<IEnumerable<int>, int> result = null;
            sut.Result += _ => result = _;
            sut.Drop();

            Assert.AreEqual(new int[] { }, result.Item1);
            Assert.AreEqual(1, result.Item2);
        }


        [Test]
        public void Calculate_factorial_for_current_number()
        {
            var sut = new RPNCalculator();

            Tuple<IEnumerable<int>, int> result = null;
            sut.Result += _ => result = _;
            sut.Calculate(new Tuple<string, int>("!", 3));

            Assert.AreEqual(new int[] {}, result.Item1);
            Assert.AreEqual(6, result.Item2);
        }
    }


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
