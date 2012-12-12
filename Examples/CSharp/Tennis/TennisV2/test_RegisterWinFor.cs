﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TennisV2
{
    [TestFixture]
    public class test_RegisterWinFor
    {
        [Test]
        public void Player0_wins_ball()
        {
            var labels = new[] {"Love", "15"};
            var player0Wins = 0;
            player0Wins++;
            var score = string.Format("{0}:{1}", labels[player0Wins], labels[0]);
            Assert.AreEqual("15:Love", score);
        }

        [Test]
        public void Player1_wins_ball()
        {
            var labels = new[] { "Love", "15" };
            var player1Wins = 0;
            player1Wins++;
            var score = string.Format("{0}:{1}", labels[0], labels[player1Wins]);
            Assert.AreEqual("Love:15", score);            
        }

        [Test]
        public void Initial_score()
        {
            var labels = new[] { "Love", "15" };
            var score = string.Format("{0}:{1}", labels[0], labels[0]);
            Assert.AreEqual("Love:Love", score);
        }
    }
}
