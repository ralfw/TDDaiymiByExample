using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace DesktopCalculator.tests
{
    [TestFixture]
    public class test_NumberAssembler
    {
        [Test]
        public void First_digit_is_returned_as_number()
        {
            _number = 0;
            var result = Add_digit("2"); 
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Next_digit_is_added_to_number()
        {
            _number = 2;
            var result = Add_digit("3");
            Assert.AreEqual(23, result);
        }

        [Test]
        public void Read_number()
        {
            _number = 0;
            Add_digit("2");
            Assert.AreEqual(2, _number);
        }

        [Test]
        public void Set_number_and_read_it()
        {
            _number = 23;
            Assert.AreEqual(23, _number);
        }

        private int _number;
        int Add_digit(string digit)
        {
            _number = 10*_number + int.Parse(digit);
            return _number;
        }
    }
}
