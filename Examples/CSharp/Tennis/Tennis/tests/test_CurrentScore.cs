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
            var sut = new Referee("", "");
            Assert.AreEqual("Love:Love", sut.CurrentScore);
        }

        [Test]
        public void Score_after_some_wins()
        {
            var sut = new Referee("A", "B", new[] {3, 2});
            Assert.AreEqual("40:30", sut.CurrentScore);
        }
    }
}
