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
            _playerWins = new int[2];
            Count_wins(0);
            var score = Score_wins();
            Assert.AreEqual("15:Love", score);
        }

        [Test]
        public void Player1_wins_ball()
        {
            _playerWins = new int[2];
            Count_wins(1);
            var score = Score_wins();
            Assert.AreEqual("Love:15", score);            
        }

        [Test]
        public void Initial_score()
        {
            _playerWins = new int[2];
            var score = Score_wins();
            Assert.AreEqual("Love:Love", score);
        }

        [Test]
        public void Game_over_without_deuce()
        {
            _playerWins = new[] {3, 2};
            Count_wins(0);
            var score = Score_wins();
            Assert.AreEqual("Game over", score);
        }


        int[] _playerWins = new int[2];
        void Count_wins(int player)
        {
            _playerWins[player]++;
        }

        private string[] _labels = new[] {"Love", "15"};
        string Score_wins()
        {
            if (Math.Abs(_playerWins[0] - _playerWins[1]) >= 2 && Math.Max(_playerWins[0], _playerWins[1]) > 3)
                return "Game over";

            return string.Format("{0}:{1}", _labels[_playerWins[0]], _labels[_playerWins[1]]);
        }
    }
}
