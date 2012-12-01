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
            var kvp = Split_assignment("a=1");
            var result = new Dictionary<string, string> {{kvp.Key, kvp.Value}};
            Assert.That(result, Is.EqualTo(new Dictionary<string,string>{{"a", "1"}}));
        }

        [Test]
        public void Multiple_name_value_pairs()
        {
            var nvpairs = "a=1;b=2".Split(';');

            var kvp = Split_assignment(nvpairs[0]);
            var result = new Dictionary<string, string> {{kvp.Key, kvp.Value}};

            kvp = Split_assignment(nvpairs[1]);
            result.Add(kvp.Key, kvp.Value);

            Assert.That(result, Is.EqualTo(new Dictionary<string,string>{{"a", "1"},{"b", "2"}}));
        }


        static KeyValuePair<string,string> Split_assignment(string assignment)
        {
            var name = assignment.Substring(0, 1);
            var value = assignment.Substring(2, 1);
            return new KeyValuePair<string, string>(name,value);
        } 
    }
}
