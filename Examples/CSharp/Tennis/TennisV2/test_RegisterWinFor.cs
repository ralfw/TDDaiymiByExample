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
            var sut = new Referee("","");
            var score = sut.RegisterWinFor(Referee.Players.Player1);
            Assert.AreEqual("15:Love", score);
        }

        [Test]
        public void Player1_wins_ball()
        {
            var sut = new Referee("","");
            var score = sut.RegisterWinFor(Referee.Players.Player2);
            Assert.AreEqual("Love:15", score);            
        }

        [Test]
        public void Initial_score()
        {
            var sut = new Referee("","");
            var score = sut.Score_wins();
            Assert.AreEqual("Love:Love", score);
        }

        [Test]
        public void Game_over_without_deuce()
        {
            var sut = new Referee(new string[2] ,new[] {3, 2});
            var score = sut.RegisterWinFor(Referee.Players.Player1);
            Assert.AreEqual("Game over", score);
        }

        [Test]
        public void Game_enters_Deuce()
        {
            var sut = new Referee(new string[2], new[] {3, 2});
            var score = sut.RegisterWinFor(Referee.Players.Player2);
            Assert.AreEqual("Deuce", score);
        }

        [Test]
        public void Advantage_is_gained()
        {
            var sut = new Referee(new[]{"A", "B"}, new[]{3,3});
            var score = sut.RegisterWinFor(Referee.Players.Player1);
            Assert.AreEqual("Advantage A", score);
        }

        [Test]
        public void Advantage_is_lost()
        {
            var sut = new Referee(new string[2], new[] {4, 3});
            var score = sut.RegisterWinFor(Referee.Players.Player2);
            Assert.AreEqual("Deuce", score);
        }

        [Test]
        public void Game_over_after_advantage()
        {
            var sut = new Referee(new string[2], new[] {5, 4});
            var score = sut.RegisterWinFor(Referee.Players.Player1);
            Assert.AreEqual("Game over", score);
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
        private const int INDEX_FORTY_POINTS = 3;
        readonly int[] _playerWins = new int[2];
        readonly string[] _playerNames = new string[2];


        internal Referee(string[] playerNames, int[] playerWins)
        {
            _playerNames = playerNames;
            _playerWins = playerWins;
        }
        public Referee(string namePlayer1, string namePlayer2) : this(new[]{namePlayer1, namePlayer2}, new int[2]) {}


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

            if (Is_advantage())
                return "Advantage " + _playerNames[Leading_player()];

            if (Is_deuce())
                return "Deuce";

            return string.Format("{0}:{1}", _labels[_playerWins[0]], _labels[_playerWins[1]]);
        }


        private bool Is_game_over()
        {
            return Math.Abs(_playerWins[0] - _playerWins[1]) >= 2 &&
                   Math.Max(_playerWins[0], _playerWins[1]) > INDEX_FORTY_POINTS;
        }

        private bool Is_advantage()
        {
            return Math.Abs(_playerWins[0] - _playerWins[1]) == 1 && _playerWins[Leading_player()] > INDEX_FORTY_POINTS;
        }

        private int Leading_player()
        {
            return _playerWins[0] > _playerWins[1] ? 0 : 1;
        }

        private bool Is_deuce()
        {
            return _playerWins[0] == _playerWins[1] && _playerWins[0] >= INDEX_FORTY_POINTS;
        }
    }
}
