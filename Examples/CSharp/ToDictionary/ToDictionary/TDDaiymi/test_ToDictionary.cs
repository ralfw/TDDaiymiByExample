using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ToDictionary.TDDaiymi
{
    [TestFixture]
    public class test_ToDictionary
    {
        [Test]
        public void Single_name_value_pair()
        {
            var result = ToDictionaryExtension.Build_dictionary_from_assignments(new[] {"a=1"});
            Assert.That(result, Is.EqualTo(new Dictionary<string, string> {{"a", "1"}}));
        }


        [Test]
        public void Multiple_name_value_pairs()
        {
            var nvpairs = ToDictionaryExtension.Split_into_assignments("a=1;b=2");
            var result = ToDictionaryExtension.Build_dictionary_from_assignments(nvpairs);
            Assert.That(result, Is.EqualTo(new Dictionary<string, string> {{"a", "1"},{"b", "2"}}));
        }


        [Test]
        public void Multi_char_name()
        {
            var kvp = ToDictionaryExtension.Split_assignment("abc=1");
            Assert.AreEqual("abc", kvp.Key);
        }

        [Test]
        public void Multi_char_value()
        {
            var kvp = ToDictionaryExtension.Split_assignment("a=1234");
            Assert.AreEqual("1234", kvp.Value);
        }

        [Test]
        public void Empty_value()
        {
            var kvp = ToDictionaryExtension.Split_assignment("a=");
            Assert.AreEqual("", kvp.Value);
        }


        [Test]
        public void Whitespace_in_name()
        {
            var kvp = ToDictionaryExtension.Split_assignment(" a =1");
            Assert.AreEqual("a", kvp.Key);
        }


        [Test]
        public void Whitespace_in_value()
        {
            var kvp = ToDictionaryExtension.Split_assignment("a= 1 ");
            Assert.AreEqual(" 1 ", kvp.Value);
        }

        [Test]
        public void Equal_sign_in_value()
        {
            var kvp = ToDictionaryExtension.Split_assignment("a==");
            Assert.AreEqual("=", kvp.Value);
        }


        [Test]
        public void No_value_provided()
        {
            var kvp = ToDictionaryExtension.Split_assignment("a");
            Assert.AreEqual("a", kvp.Key);
            Assert.AreEqual("", kvp.Value);
        }


        [Test]
        public void Semicolon_seemingly_in_value()
        {
            var assignments = ToDictionaryExtension.Split_into_assignments("a=1;2");
            Assert.That(assignments, Is.EqualTo(new[]{"a=1", "2"}));
        }

        [Test]
        public void Skipping_consecutive_semicolons()
        {
            var assignments = ToDictionaryExtension.Split_into_assignments("a=1;;b=2");
            Assert.That(assignments, Is.EqualTo(new[]{"a=1", "b=2"}));
        }


        [Test]
        public void Multiple_values_for_same_name()
        {
            var dict = ToDictionaryExtension.Build_dictionary_from_assignments(new[] {"a=1", "a=2"});
            Assert.That(dict, Is.EqualTo(new Dictionary<string, string> {{"a", "2"}}));
        }

        [Test]
        public void Empty_string()
        {
            var dict = ToDictionaryExtension.Build_dictionary_from_assignments(new string[]{});
            Assert.That(dict, Is.EqualTo(new Dictionary<string, string>()));
        }


        [Test]
        public void Null_as_input()
        {
            Assert.Throws<NullReferenceException>(() => ToDictionaryExtension.Split_into_assignments(null));
        }


        [Test]
        public void No_name_given()
        {
            Assert.Throws<ArgumentException>(() => ToDictionaryExtension.Split_assignment("=1"));
        }


        [Test]
        public void Integration_test_for_extension_method()
        {
            Assert.That("a=1;b=2".ToDictionary(), Is.EqualTo(new Dictionary<string, string> {{"a", "1"},{"b", "2"}}));
        }
    }
}
