using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RPNDesktopCalculator.tests
{
    [TestFixture]
    public class test_RPNCalculator
    {
        [Test, Category("Push")]
        public void Push_on_empty_stack()
        {
            var sut = new RPNCalculator();

            Tuple<IEnumerable<int>, int> result = null;
            sut.Result += _ => result = _;
            sut.Push(1);

            Assert.AreEqual(new[]{1}, result.Item1);
            Assert.AreEqual(1, result.Item2);
        }

        [Test, Category("Push")]
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


        [Test, Category("Calc")]
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

        [Test, Category("Calc")]
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


        [Test, Category("Drop")]
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

        [Test, Category("Drop")]
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


        [Test, Category("Calc")]
        public void Calculate_factorial_for_current_number()
        {
            var sut = new RPNCalculator();

            Tuple<IEnumerable<int>, int> result = null;
            sut.Result += _ => result = _;
            sut.Calculate(new Tuple<string, int>("!", 3));

            Assert.AreEqual(new int[] {}, result.Item1);
            Assert.AreEqual(6, result.Item2);
        }


        [TestCase(12, "-", 5, 7), Category("Calc")]
        [TestCase(12, "*", 2, 24), Category("Calc")]
        [TestCase(12, "/", 3, 4), Category("Calc")]
        public void More_basic_operations(int leftOperand, 
                                            string op, 
                                            int number, 
                                            int calcResult)
        {
            var initialStack = new Stack<int>();
            initialStack.Push(leftOperand);
            var sut = new RPNCalculator(initialStack);

            Tuple<IEnumerable<int>, int> result = null;
            sut.Result += _ => result = _;
            sut.Calculate(new Tuple<string, int>(op, number));

            Assert.AreEqual(new int[] { }, result.Item1);
            Assert.AreEqual(calcResult, result.Item2);   
        }
    }
}
