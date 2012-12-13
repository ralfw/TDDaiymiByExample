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
            Func<int, int> previousOp = i => previousResult + i;
            const int currentNumber = 3;
            var result = previousOp(currentNumber);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void First_op_returns_current_number()
        {
            Func<int, int> previousOp = i => 0 + i;
            const int currentNumber = 2;
            var result = previousOp(currentNumber);
            Assert.AreEqual(2, result);
        }
    }
}
