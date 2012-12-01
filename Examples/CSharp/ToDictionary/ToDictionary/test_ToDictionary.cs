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
            Assert.That(result, Is.EqualTo(new Dictionary<string,string>{{"a", "1"}}));
        }
    }
}
