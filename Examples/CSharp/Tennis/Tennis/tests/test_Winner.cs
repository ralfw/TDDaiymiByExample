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
            var winner = "?";
            if (!sut.Is_game_over())
                winner = "";
            Assert.AreEqual("", winner);
        }
    }
}
