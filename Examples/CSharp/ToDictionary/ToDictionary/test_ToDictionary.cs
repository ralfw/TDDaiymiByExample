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
            var name = "a=1".Substring(0, 1);
            var value = "a=1".Substring(2, 1);
            var result = new Dictionary<string, string> {{name, value}};
            Assert.That(result, Is.EqualTo(new Dictionary<string,string>{{"a", "1"}}));
        }

        [Test]
        public void Multiple_name_value_pairs()
        {
            var nvpairs = "a=1;b=2".Split(';');

            var name = nvpairs[0].Substring(0, 1);
            var value = nvpairs[0].Substring(2, 1);
            var result = new Dictionary<string, string> {{name, value}};

            name = nvpairs[1].Substring(0, 1);
            value = nvpairs[1].Substring(2, 1);
            result.Add(name,value);

            Assert.That(result, Is.EqualTo(new Dictionary<string,string>{{"a", "1"},{"b", "2"}}));
        }
    }
}
