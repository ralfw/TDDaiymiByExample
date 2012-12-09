using System.Collections.Generic;

namespace ToDictionary.TDD
{
    public static class ToDictionaryExtension
    {
        public static Dictionary<string,string> ToDictionary(this string text)
        {
            var dict = new Dictionary<string, string>();

            var assignments = text.Split(';');

            var nameValue = assignments[0].Split('=');
            dict.Add(nameValue[0], nameValue[1]);

            nameValue = assignments[1].Split('=');
            dict.Add(nameValue[0], nameValue[1]);

            return dict;
        } 
    }
}