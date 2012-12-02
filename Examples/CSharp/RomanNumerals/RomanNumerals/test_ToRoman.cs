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
                                                                                new KeyValuePair<int, string>(900, "CM"),
                                                                                new KeyValuePair<int, string>(9, "IX"),
                                                                                new KeyValuePair<int, string>(5, "V"), 
                                                                                new KeyValuePair<int, string>(1, "I")};

        [TestCase(5, Result = "V")]
        [TestCase(9, Result = "IX")]
        public string Decimal_matches_building_block(int decimalNumber)
        {
            return ToRoman("", decimalNumber);
        }

        [TestCase(6, Result = "VI")]
        [TestCase(906, Result = "CMVI")]
        public string Decimal_needs_to_be_build_from_non_repeating_building_blocks(int decimalNumber)
        {
            return ToRoman("", decimalNumber);
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
