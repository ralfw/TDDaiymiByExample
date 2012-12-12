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
            var winner = "";
            if (sut.Is_game_over())
                winner = "And the winner is...";
            Assert.AreEqual("", winner);
        }

        [Test]
        public void Game_is_over()
        {
            var sut = new Referee(new[] {"A", "B"}, new[] {4, 2});
            var winner = "";
            if (sut.Is_game_over())
                winner = "And the winner is...";
            Assert.AreEqual("A", winner);
        }
    }
}
