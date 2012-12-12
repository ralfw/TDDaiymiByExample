using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TennisV2.tests
{
    [TestFixture]
    public class test_Winner
    {
        [Test]
        public void Game_still_on()
        {
            var sut = new Referee("A", "B");
            Assert.AreEqual("", sut.Winner);
        }

        [Test]
        public void Game_is_over()
        {
            var sut = new Referee(new[] {"A", "B"}, new[] { 4, 2 });
            Assert.AreEqual("A", sut.Winner);
        }
    }
}
