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
    }
}
