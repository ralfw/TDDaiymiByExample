using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals
{
    public static class RomanNumeralsExtension
    {
        public static string ToRoman(this int decimalNumber)
        {
            return ToRoman("", decimalNumber);
        }


        internal static string ToRoman(string roman, int decimalNumber)
        {
            if (decimalNumber == 0) return roman;

            var buildingBlock = _romanNumerals.First(kvp => kvp.Key <= decimalNumber);
            roman += buildingBlock.Value;

            return ToRoman(roman, decimalNumber - buildingBlock.Key);
        }


        private static readonly List<KeyValuePair<int, string>> _romanNumerals = 
            new List<KeyValuePair<int, string>> { 
                                                    new KeyValuePair<int, string>(1000, "M"),
                                                    new KeyValuePair<int, string>(900, "CM"),
                                                    new KeyValuePair<int, string>(500, "D"),
                                                    new KeyValuePair<int, string>(400, "CD"),
                                                    new KeyValuePair<int, string>(100, "C"),
                                                    new KeyValuePair<int, string>(90, "XC"),
                                                    new KeyValuePair<int, string>(50, "L"),
                                                    new KeyValuePair<int, string>(40, "XL"),
                                                    new KeyValuePair<int, string>(9, "IX"),
                                                    new KeyValuePair<int, string>(5, "V"), 
                                                    new KeyValuePair<int, string>(4, "IV"),
                                                    new KeyValuePair<int, string>(1, "I")};
    }
}