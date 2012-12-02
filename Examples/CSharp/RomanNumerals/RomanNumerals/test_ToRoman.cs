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
        private readonly Dictionary<int,string> _romanNumerals = new Dictionary<int, string> {{5, "V"}, {1, "I"}};

        [Test]
        public void Decimal_matches_building_block()
        {
            var roman = "" + _romanNumerals[5];
            Assert.AreEqual("V", roman);
        }

        [Test]
        public void Decimal_needs_to_be_build_from_non_repeating_building_blocks()
        {
            var roman = "" + _romanNumerals[5];
            roman = roman + _romanNumerals[1];
            Assert.AreEqual("VI", roman);
        }

        [Test]
        public void Decimal_needs_to_be_build_from_repeating_building_blocks()
        {
            var decimalNumber = 7;

            var buildingBlockKey = 5;
            decimalNumber -= buildingBlockKey;
            var roman = "" + _romanNumerals[buildingBlockKey];

            buildingBlockKey = 1;
            decimalNumber -= buildingBlockKey;
            roman = roman + _romanNumerals[buildingBlockKey];

            buildingBlockKey = 1;
            decimalNumber -= buildingBlockKey;
            roman = roman + _romanNumerals[1];

            Assert.AreEqual("VII", roman);
            Assert.AreEqual(0, decimalNumber);
        }
    }
}
