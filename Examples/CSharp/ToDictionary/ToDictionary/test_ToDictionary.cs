using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ToDictionary
{
    [TestFixture]
    public class test_ToDictionary
    {
        [Test]
        public void Single_name_value_pair()
        {
            var result = Build_dictionary_from_assignments(new[] {"a=1"});
            Assert.That(result, Is.EqualTo(new Dictionary<string,string>{{"a", "1"}}));
        }

        [Test]
        public void Multiple_name_value_pairs()
        {
            var nvpairs = "a=1;b=2".Split(';');
            var result = Build_dictionary_from_assignments(nvpairs);
            Assert.That(result, Is.EqualTo(new Dictionary<string,string>{{"a", "1"},{"b", "2"}}));
        }


        static KeyValuePair<string,string> Split_assignment(string assignment)
        {
            var name = assignment.Substring(0, 1);
            var value = assignment.Substring(2, 1);
            return new KeyValuePair<string, string>(name,value);
        } 

        static Dictionary<string,string> Aggregate_dictionary(Dictionary<string,string> dict, string name, string value)
        {
            dict.Add(name, value);
            return dict;
        }

        static Dictionary<string,string> Build_dictionary_from_assignments(IEnumerable<string> assignments)
        {
            return assignments.Select(Split_assignment)
                              .Aggregate(new Dictionary<string, string>(), 
                                         (current, kvp) => Aggregate_dictionary(current, kvp.Key, kvp.Value));
        } 
    }
}
