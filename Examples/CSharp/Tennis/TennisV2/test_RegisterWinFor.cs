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
            var score = sut.RegisterWinFor(Referee.Players.Player1);
            Assert.AreEqual("15:Love", score);
        }

        [Test]
        public void Player1_wins_ball()
        {
            var sut = new Referee();
            var score = sut.RegisterWinFor(Referee.Players.Player2);
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
            var score = sut.RegisterWinFor(Referee.Players.Player1);
            Assert.AreEqual("Game over", score);
        }

        [Test]
        public void Game_enters_Deuce()
        {
            var sut = new Referee(new[] {3, 2});
            var score = sut.RegisterWinFor(Referee.Players.Player2);
            Assert.AreEqual("Deuce", score);
        }

        [Test]
        public void Advantage_is_gained()
        {
            var playerWins = new[] {3, 3};
            var sut = new Referee(playerWins);
            sut.Count_win_for(0);
            var score = "?:40";
            const int leadingPlayer = 0;
            if (Math.Abs(playerWins[0] - playerWins[1]) == 1 && playerWins[leadingPlayer] > 3)
                score = "Advantage A";
            Assert.AreEqual("Advantage A", score);
        }
    }


    public class Referee
    {
        public enum Players
        {
            Player1,
            Player2
        }


        private readonly string[] _labels = new[] { "Love", "15", "30", "40" };
        readonly int[] _playerWins = new int[2];


        internal Referee(int[] playerWins) { _playerWins = playerWins; }
        public Referee() : this(new int[2]) {}


        public string RegisterWinFor(Players player)
        {
            Count_win_for((int)player);
            return Score_wins();
        }


        internal void Count_win_for(int player)
        {
            _playerWins[player]++;
        }

        internal string Score_wins()
        {
            if (Is_game_over())
                return "Game over";

            if (Is_deuce())
                return "Deuce";

            return string.Format("{0}:{1}", _labels[_playerWins[0]], _labels[_playerWins[1]]);
        }

        private bool Is_game_over()
        {
            return Math.Abs(_playerWins[0] - _playerWins[1]) >= 2 && 
                   Math.Max(_playerWins[0], _playerWins[1]) > 3;
        }

        private bool Is_deuce()
        {
            return _playerWins[0] == _playerWins[1] && _playerWins[0] >= 3;
        }
    }
}
