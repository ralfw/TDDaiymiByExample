using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesktopCalculator.domain;
using NUnit.Framework;

namespace DesktopCalculator.tests
{
    [TestFixture]
    public class test_Calculator
    {
        [Test]
        public void Happy_day_Nth_op_builds_on_previous()
        {
            var sut = new Calculator();
            sut.Calculate(2, "+");
            var result = sut.Calculate(3, "+");
            Assert.AreEqual(5, result);
        }

        [Test]
        public void First_op_returns_current_number()
        {
            var sut = new Calculator();
            var result = sut.Calculate(2, "+");
            Assert.AreEqual(2, result);
        }

        [TestCase("+", Result = 15)]
        [TestCase("-", Result = 9)]
        [TestCase("*", Result = 36)]
        [TestCase("/", Result = 4)]
        public int Check_ops(string op)
        {
            var sut = new Calculator();

            sut.Calculate(12, op);

            return sut.Calculate(3, "=");
        }

        [Test]
        public void Equal_resets_previous_data()
        {
            var sut = new Calculator();
            sut.Calculate(2, "+");
            sut.Calculate(3, "=");

            Assert.AreEqual(4, sut.Calculate(4, "*"));
            Assert.AreEqual(8, sut.Calculate(2, "="));
        }

        [Test]
        public void Division_by_zero_throws_exception()
        {
            var sut = new Calculator();
            sut.Calculate(2, "/");
            Assert.Throws<DivideByZeroException>(() => sut.Calculate(0, "="));
        }
    }
}
