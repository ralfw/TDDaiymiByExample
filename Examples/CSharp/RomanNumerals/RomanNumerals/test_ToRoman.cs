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
            var roman = new Dictionary<int, string>{{5, "V"}}[5];
            Assert.AreEqual("V", roman);
        }

        [Test]
        public void Decimal_needs_to_be_build_from_non_repeating_building_blocks()
        {
            var romanNumerals = new Dictionary<int, string> {{5, "V"}, {1, "I"}};
            var roman = romanNumerals[5];
            roman = roman + romanNumerals[1];
            Assert.AreEqual("VI", roman);
        }

        [Test]
        public void Decimal_needs_to_be_build_from_repeating_building_blocks()
        {
            var romanNumerals = new Dictionary<int, string> { { 5, "V" }, { 1, "I" } };
            var roman = romanNumerals[5];
            roman = roman + romanNumerals[1];
            roman = roman + romanNumerals[1];
            Assert.AreEqual("VII", roman);
        }
    }
}
