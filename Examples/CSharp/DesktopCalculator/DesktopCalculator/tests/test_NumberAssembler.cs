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
            const string digit = "2";
            var result = int.Parse(digit);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Next_digit_is_added_to_number()
        {
            var result = 2;
            const string secondDigit = "3";
            result = 10*result + int.Parse(secondDigit);
            Assert.AreEqual(23, result);
        }
    }
}
