using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Tennis.tests
{
    [TestFixture]
    public class test_CurrentScore
    {
        [Test]
        public void No_wins_yet()
        {
            var POINT_VALUES = new string[] { "0", "15", "30", "40", "Advantage" };
            var score = string.Format("{0}:{1}", POINT_VALUES[0], POINT_VALUES[0]);
            Assert.AreEqual("Love:Love", score);
        }
    }
}
