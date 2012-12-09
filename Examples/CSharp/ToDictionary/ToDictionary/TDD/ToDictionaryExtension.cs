using System.Collections.Generic;

namespace ToDictionary.TDD
{
    public static class ToDictionaryExtension
    {
        public static Dictionary<string,string> ToDictionary(this string text)
        {
            var dict = new Dictionary<string, string>();

            var assignments = text.Split(';');
            foreach (var assignment in assignments)
            {
                var nameValue = assignment.Split('=');
                dict.Add(nameValue[0], nameValue[1]);
            }

            return dict;
        } 
    }
}