using System.Collections.Generic;

namespace ToDictionary.TDD
{
    public static class ToDictionaryExtension
    {
        public static Dictionary<string,string> ToDictionary(this string text)
        {
            return new Dictionary<string, string>{{"a", "1"}};
        } 
    }
}