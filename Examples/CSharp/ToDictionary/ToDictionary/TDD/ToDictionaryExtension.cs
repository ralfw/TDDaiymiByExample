using System.Collections.Generic;

namespace ToDictionary.TDD
{
    public static class ToDictionaryExtension
    {
        public static Dictionary<string,string> ToDictionary(this string text)
        {
            var nameValue = text.Split('=');
            return new Dictionary<string, string>{{nameValue[0], nameValue[1]}};
        } 
    }
}