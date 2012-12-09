using System;
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
    }
}
