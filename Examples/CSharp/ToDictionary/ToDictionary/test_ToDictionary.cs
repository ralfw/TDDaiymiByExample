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

        [Test]
        public void Multi_char_name()
        {
            var kvp = Split_assignment("abc=1");
            Assert.AreEqual("abc", kvp.Key);
        }

        [Test]
        public void Multi_char_value()
        {
            var kvp = Split_assignment("a=1234");
            Assert.AreEqual("1234", kvp.Value);
        }

        [Test]
        public void Empty_value()
        {
            var kvp = Split_assignment("a=");
            Assert.AreEqual("", kvp.Value);
        }


        [Test]
        public void Whitespace_in_name()
        {
            var kvp = Split_assignment(" a =1");
            Assert.AreEqual("a", kvp.Key);
        }


        [Test]
        public void Whitespace_in_value()
        {
            var kvp = Split_assignment("a= 1 ");
            Assert.AreEqual(" 1 ", kvp.Value);
        }

        [Test]
        public void Equal_sign_in_value()
        {
            var kvp = Split_assignment("a==");
            Assert.AreEqual("=", kvp.Value);
        }


        [Test]
        public void No_value_provided()
        {
            var indexOfEqual = "a".IndexOf("=");
            var name = "a".Substring(0, indexOfEqual).Trim();
            var value = "a".Substring(indexOfEqual + 1);
            var kvp = new KeyValuePair<string, string>(name, value);
            Assert.AreEqual("a", kvp.Key);
            Assert.AreEqual("", kvp.Value);
        }


        static KeyValuePair<string,string> Split_assignment(string assignment)
        {
            var indexOfEqual = assignment.IndexOf("=");
            var name = assignment.Substring(0, indexOfEqual).Trim();
            var value = assignment.Substring(indexOfEqual + 1);
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
