using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesktopCalculator.domain;
using NUnit.Framework;

namespace DesktopCalculator.tests
{
    [TestFixture]
    public class test_Application
    {
        [Test]
        public void Add_digit_to_number()
        {
            var mna = new MockNumberAssembler();
            Assert.AreEqual(2, mna.Add_digit("23"));
            Assert.AreEqual("23", mna._Digits);
        }

        [Test]
        public void Execute_operator()
        {
            var mna = new MockNumberAssembler();
            var mc = new MockCalculator();

            mna._Number = 99;
            var result = mc.Calculate(42, "+");
            mna._Number = result;
            Assert.AreEqual(420, mna.Number);
        }


        class MockNumberAssembler : INumberAssembler
        {
            public string _Digits;

            public int Add_digit(string digit)
            {
                _Digits += digit;
                return digit.Length;
            }


            public int _Number;

            public int Number
            {
                get { return _Number; }
                set { _Number = value; }
            }
        }

        class MockCalculator : ICalculator
        {
            public int Calculate(int number, string op)
            {
                return number*10;
            }
        }
    }
}
