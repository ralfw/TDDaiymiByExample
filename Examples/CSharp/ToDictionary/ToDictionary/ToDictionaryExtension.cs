using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDictionary
{
    public static class ToDictionaryExtension
    {
        public static Dictionary<string,string> ToDictionary(this string text)
        {
            var assignments = Split_into_assignments(text);
            return Build_dictionary_from_assignments(assignments);
        } 

        internal static IEnumerable<string> Split_into_assignments(string text)
        {
            return text.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        }

        internal static Dictionary<string, string> Build_dictionary_from_assignments(IEnumerable<string> assignments)
        {
            return assignments.Select(Split_assignment)
                              .Aggregate(new Dictionary<string, string>(),
                                         (current, kvp) => Aggregate_dictionary(current, kvp.Key, kvp.Value));
        }

        internal static KeyValuePair<string, string> Split_assignment(string assignment)
        {
            var indexOfEqual = assignment.IndexOf("=");
            var name = assignment.Substring(0, indexOfEqual >= 0 ? indexOfEqual : assignment.Length).Trim();
            if (name == "") throw new ArgumentException("Missing name for value: " + assignment);
            var value = indexOfEqual >= 0 ? assignment.Substring(indexOfEqual + 1) : "";
            return new KeyValuePair<string, string>(name, value);
        }

        internal static Dictionary<string, string> Aggregate_dictionary(Dictionary<string, string> dict, string name, string value)
        {
            dict[name] = value;
            return dict;
        }
    }
}