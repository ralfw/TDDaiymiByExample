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
                var indexOfEqual = assignment.IndexOf("=");
                var name = assignment.Substring(0, indexOfEqual);
                var value = assignment.Substring(indexOfEqual + 1);
                dict.Add(name.Trim(), value);
            }

            return dict;
        } 
    }
}