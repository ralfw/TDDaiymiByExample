using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace DesktopCalculator.tests
{
    [TestFixture]
    public class test_Calculator
    {
        [Test]
        public void Happy_day_Nth_op_build_on_previous()
        {
            const int previousResult = 2;
            _previousOp = i =>  previousResult + i;
            var result = Calculate(3);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void First_op_returns_current_number()
        {
            _previousOp = i => 0 + i;
            var result = Calculate(2);
            Assert.AreEqual(2, result);
        }


        private Func<int, int> _previousOp = i => 0 + 1; 
        int Calculate(int currentNumber)
        {
            var result = _previousOp(currentNumber);

            _previousOp = i => result + i;

            return result;
        }
    }
}
