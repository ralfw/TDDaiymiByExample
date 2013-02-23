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
    }


    public class RPNCalculator
    {
        private readonly Stack<int> _stack;

        public RPNCalculator() : this(new Stack<int>()) {}
        public RPNCalculator(Stack<int> stack)
        {
            _stack = stack;
        }

        public void Push(int number)
        {
            _stack.Push(number);
            Result(new Tuple<IEnumerable<int>, int>(_stack.Reverse(), number));
        }


        public event Action<Tuple<IEnumerable<int>, int>> Result;
    }
}
