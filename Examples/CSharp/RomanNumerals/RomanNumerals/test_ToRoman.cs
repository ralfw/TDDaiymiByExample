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
        private readonly List<KeyValuePair<int,string>> _romanNumerals = new List<KeyValuePair<int,string>> { 
                                                                                new KeyValuePair<int, string>(5, "V"), 
                                                                                new KeyValuePair<int, string>(1, "I")};

        [Test]
        public void Decimal_matches_building_block()
        {
            var roman = "" + _romanNumerals.First(kvp => kvp.Key == 5).Value;
            Assert.AreEqual("V", roman);
        }

        [Test]
        public void Decimal_needs_to_be_build_from_non_repeating_building_blocks()
        {
            var roman = "" + _romanNumerals.First(kvp => kvp.Key == 5).Value;
            roman = roman + _romanNumerals.First(kvp => kvp.Key == 1).Value;
            Assert.AreEqual("VI", roman);
        }

        [Test]
        public void Decimal_needs_to_be_build_from_repeating_building_blocks()
        {
            var decimalNumber = 7;

            var buildingBlock = _romanNumerals.First(kvp => kvp.Key <= decimalNumber);
            var roman = "" + buildingBlock.Value;
            decimalNumber -= buildingBlock.Key;

            buildingBlock = _romanNumerals.First(kvp => kvp.Key <= decimalNumber);
            roman = roman + buildingBlock.Value;
            decimalNumber -= buildingBlock.Key;

            buildingBlock = _romanNumerals.First(kvp => kvp.Key <= decimalNumber);
            roman = roman + buildingBlock.Value;
            decimalNumber -= buildingBlock.Key;

            Assert.AreEqual("VII", roman);
            Assert.AreEqual(0, decimalNumber);
        }
    }
}
