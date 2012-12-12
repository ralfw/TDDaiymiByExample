using System;
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
            var sut = new Referee();
            sut.Count_wins(0);
            var score = sut.Score_wins();
            Assert.AreEqual("15:Love", score);
        }

        [Test]
        public void Player1_wins_ball()
        {
            var sut = new Referee();
            sut.Count_wins(1);
            var score = sut.Score_wins();
            Assert.AreEqual("Love:15", score);            
        }

        [Test]
        public void Initial_score()
        {
            var sut = new Referee();
            var score = sut.Score_wins();
            Assert.AreEqual("Love:Love", score);
        }

        [Test]
        public void Game_over_without_deuce()
        {
            var sut = new Referee(new[] {3, 2});
            sut.Count_wins(0);
            var score = sut.Score_wins();
            Assert.AreEqual("Game over", score);
        }



    }


    public class Referee
    {
        private readonly string[] _labels = new[] { "Love", "15" };
        readonly int[] _playerWins = new int[2];


        internal Referee(int[] playerWins) { _playerWins = playerWins; }
        public Referee() : this(new int[2]) {}


        internal void Count_wins(int player)
        {
            _playerWins[player]++;
        }

        internal string Score_wins()
        {
            if (Math.Abs(_playerWins[0] - _playerWins[1]) >= 2 && Math.Max(_playerWins[0], _playerWins[1]) > 3)
                return "Game over";

            return string.Format("{0}:{1}", _labels[_playerWins[0]], _labels[_playerWins[1]]);
        }
    }
}
