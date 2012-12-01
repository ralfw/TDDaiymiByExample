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
    }
}
