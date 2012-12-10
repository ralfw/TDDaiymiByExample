using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Tennis.tests
{
    [TestFixture]
    public class test_Winner
    {
        [Test]
        public void Game_still_on()
        {
            var sut = new Referee("A", "B", new[] {3, 2});
            Assert.AreEqual("", sut.Winner);
        }

        [Test]
        public void Game_has_been_won()
        {
            var sut = new Referee("A", "B", new[] {4, 2});
            Assert.AreEqual("A", sut.Winner);
        }
    }
}
