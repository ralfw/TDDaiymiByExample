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
            var roman = ToRoman("", 5);
            Assert.AreEqual("V", roman);
        }

        [Test]
        public void Decimal_needs_to_be_build_from_non_repeating_building_blocks()
        {
            var roman = ToRoman("", 6);
            Assert.AreEqual("VI", roman);
        }

        [Test]
        public void Decimal_needs_to_be_build_from_repeating_building_blocks()
        {
            var roman = ToRoman("", 7);
            Assert.AreEqual("VII", roman);
        }


        internal string ToRoman(string roman, int decimalNumber)
        {
            if (decimalNumber == 0) return roman;

            var buildingBlock = _romanNumerals.First(kvp => kvp.Key <= decimalNumber);
            roman += buildingBlock.Value;

            return ToRoman(roman, decimalNumber - buildingBlock.Key);
        }
    }
}
