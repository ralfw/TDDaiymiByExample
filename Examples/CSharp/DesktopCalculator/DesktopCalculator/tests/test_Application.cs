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
            var sut = new Application(mna, null);
            Assert.AreEqual(2, sut.Assemble_number("23"));
            Assert.AreEqual("23", mna._Digits);
        }

        [Test]
        public void Execute_operator()
        {
            var mna = new MockNumberAssembler();
            var mc = new MockCalculator();
            var sut = new Application(mna, mc);

            mna._Number = 42;
            Assert.AreEqual(420, sut.Calculate("+"));
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
