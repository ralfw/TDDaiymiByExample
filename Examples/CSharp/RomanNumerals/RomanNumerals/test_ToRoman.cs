using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace RomanNumerals
{
    [TestFixture]
    public class test_ToRoman
    {
        [Test]
        public void Decimal_matches_building_block()
        {
            Assert.AreEqual("V", roman);
        }
    }
}
