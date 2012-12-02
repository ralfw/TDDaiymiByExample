using System;
using System.Text;
using NUnit.Framework;

namespace RomanNumerals
{
    [TestFixture]
    public class test_ToRoman
    {
        [TestCase(5, Result = "V")]
        [TestCase(9, Result = "IX")]
        public string Decimal_matches_building_block(int decimalNumber)
        {
            return RomanNumeralsExtension.ToRoman("", decimalNumber);
        }

        [TestCase(6, Result = "VI")]
        [TestCase(906, Result = "CMVI")]
        public string Decimal_needs_to_be_build_from_non_repeating_building_blocks(int decimalNumber)
        {
            return RomanNumeralsExtension.ToRoman("", decimalNumber);
        }

        [TestCase(7, Result = "VII")]
        public string Decimal_needs_to_be_build_from_repeating_building_blocks(int decimalNumber)
        {
            return RomanNumeralsExtension.ToRoman("", decimalNumber);
        }

        [TestCase(3001)]
        [TestCase(0)]
        public void Outside_of_range(int decimalNumber)
        {
            Assert.Throws<ArgumentException>(() => decimalNumber.ToRoman());
        }

        [TestCase(1999, Result = "MCMXCIX")]
        [TestCase(3000, Result = "MMM")]
        [TestCase(1954, Result = "MCMLIV")]
        public string Acceptance_tests(int decimalNumber)
        {
            return decimalNumber.ToRoman();
        }
    }
}
