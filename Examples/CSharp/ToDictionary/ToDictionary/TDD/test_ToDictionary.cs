﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ToDictionary.TDD
{
    [TestFixture]
    public class test_ToDictionary
    {
        [Test]
        public void Single_name_value_pair()
        {
            Assert.That("a=1".ToDictionary(), Is.EqualTo(new Dictionary<string,string>{{"a", "1"}}));
        }

        [Test]
        public void Multiple_name_value_pairs()
        {
            Assert.That("a=1;b=2".ToDictionary(), Is.EqualTo(new Dictionary<string, string> { { "a", "1" }, {"b", "2"} }));
        }

        [Test]
        public void Multi_char_name()
        {
            Assert.That("abc=1".ToDictionary(), Is.EqualTo(new Dictionary<string, string> { { "abc", "1" } }));
        }

        [Test]
        public void Multi_char_value()
        {
            Assert.That("a=1234".ToDictionary(), Is.EqualTo(new Dictionary<string, string> { { "a", "1234" } }));
        }

        [Test]
        public void Empty_value()
        {
            Assert.That("a=".ToDictionary(), Is.EqualTo(new Dictionary<string, string> { { "a", "" } }));   
        }

        [Test]
        public void Whitespace_in_name()
        {
            Assert.That(" a =1".ToDictionary(), Is.EqualTo(new Dictionary<string, string> { { "a", "1" } })); 
        }

        [Test]
        public void Whitespace_in_value()
        {
            Assert.That("a= 1 ".ToDictionary(), Is.EqualTo(new Dictionary<string, string> { { "a", " 1 " } })); 
        }

        [Test]
        public void Equal_in_value()
        {
            Assert.That("a==".ToDictionary(), Is.EqualTo(new Dictionary<string, string> { { "a", "=" } })); 
        }

        [Test]
        public void No_value_provided()
        {
            Assert.That("a".ToDictionary(), Is.EqualTo(new Dictionary<string, string> { { "a", "" } }));
        }

        [Test]
        public void Semicolon_seemingly_in_value()
        {
            Assert.That("a=1;2".ToDictionary(), Is.EqualTo(new Dictionary<string, string> { { "a", "1" }, {"2", ""} }));
        }

        [Test]
        public void Skipping_consecutive_semicolons()
        {
            Assert.That("a=1;;b=2".ToDictionary(), Is.EqualTo(new Dictionary<string, string> { { "a", "1" }, { "b", "2" } }));
        }

        [Test]
        public void Multiple_values_for_same_name()
        {
            Assert.That("a=1;a=2".ToDictionary(), Is.EqualTo(new Dictionary<string, string> { { "a", "2" } }));
        }

        [Test]
        public void Empty_string()
        {
            Assert.That("".ToDictionary(), Is.EqualTo(new Dictionary<string, string> { }));
        }

        [Test]
        public void Null_string()
        {
            string s = null;
            Assert.Throws<NullReferenceException>(() => s.ToDictionary());
        }

        [Test]
        public void No_name_given()
        {
            Assert.Throws<ArgumentException>(() => "=1".ToDictionary());
        }
    }
}
