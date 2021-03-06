using System;
using System.Collections.Generic;

namespace ToDictionary.TDD
{
    public static class ToDictionaryExtension
    {
        public static Dictionary<string,string> ToDictionary(this string text)
        {
            var dict = new Dictionary<string, string>();

            var assignments = text.Split(new[]{';'}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var assignment in assignments)
            {
                var name="";
                var value = "";

                var indexOfEqual = assignment.IndexOf("=");
                if (indexOfEqual < 0)
                    name = assignment;
                else
                {
                    name = assignment.Substring(0, indexOfEqual);
                    value = assignment.Substring(indexOfEqual + 1);
                }
                if (name == "") throw new ArgumentException("Missing name for value: " + assignment);

                dict[name.Trim()] = value;
            }

            return dict;
        } 
    }
}