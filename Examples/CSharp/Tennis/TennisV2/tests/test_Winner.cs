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
            var playerWins = new[] {4, 2};
            var playerNames = new[] {"A", "B"};
            var sut = new Referee(playerNames, playerWins);
            var winner = "";
            if (sut.Is_game_over())
                winner = playerNames[sut.Leading_player()];
            Assert.AreEqual("A", winner);
        }
    }
}
