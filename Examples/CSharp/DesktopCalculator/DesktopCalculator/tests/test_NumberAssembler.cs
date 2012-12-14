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
            _number = 2;
            var result = Number;
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Set_number_and_read_it()
        {
            _number = 0;
            Number = 23;
            var result = Number;
            Assert.AreEqual(23, result);
        }

        [Test]
        public void Set_number_and_send_a_digit()
        {
            _number = 0;
            Number = 23;
            var result = Add_digit("9");
            Assert.AreEqual(9, result);
        }

        private int _number;
        private bool _numberHasBeenSet;
        int Add_digit(string digit)
        {
            var d = int.Parse(digit);
            if (_numberHasBeenSet)
            {
                _number = d;
                _numberHasBeenSet = false;
            }
            else
                _number = 10 * _number + d;
            return _number;
        }

        int Number
        {
            get { return _number; }
            set { _number = value; _numberHasBeenSet = true; }
        }
    }
}
