using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Tennis
{
    [TestFixture]
    public class test_RegisterWinFor
    {
        [Test]
        public void First_win()
        {
            var sut = new Referee(new[] {1, 0});
            Assert.AreEqual("15:0", sut.Build_score());
        }

        [Test]
        public void Second_win_same_player()
        {
            var sut = new Referee();

            sut.RegisterWinFor(Referee.Players.Player1);
            var score = sut.RegisterWinFor(Referee.Players.Player1);

            Assert.AreEqual("30:0", score);
        }

        [Test]
        public void Players_winning_alternately()
        {
            var sut = new Referee();

            sut.RegisterWinFor(Referee.Players.Player1);
            sut.RegisterWinFor(Referee.Players.Player2);
            var score = sut.RegisterWinFor(Referee.Players.Player1);

            Assert.AreEqual("30:15", score);
        }

        [Test]
        public void Winning_a_game_without_deuce()
        {
            var sut = new Referee();

            sut.RegisterWinFor(Referee.Players.Player1);
            sut.RegisterWinFor(Referee.Players.Player1);
            sut.RegisterWinFor(Referee.Players.Player1);
            var score = sut.RegisterWinFor(Referee.Players.Player1);

            Assert.AreEqual("Game over", score);
        }

        [Test]
        public void Entering_deuce_state()
        {
            var sut = new Referee(new[] {3, 2}); // 40:30

            var score = sut.RegisterWinFor(Referee.Players.Player2);

            Assert.AreEqual("Deuce", score);
        }

        [Test]
        public void Advantage()
        {
            var POINT_VALUES = new string[] { "0", "15", "30", "40", "Advantage" };
            var pointIndexOfPlayer = new[] {3, 3}; // deuce
            var nameOfPlayer = new[] {"A", "B"};

            pointIndexOfPlayer[0]++;

            var score = POINT_VALUES[pointIndexOfPlayer[0]] + " " + nameOfPlayer[0];

            Assert.AreEqual("Advantage A", score);
        }

        [Test]
        public void Winning_game_from_advantage()
        {
            var POINT_VALUES = new string[] { "0", "15", "30", "40", "Advantage" };
            var pointIndexOfPlayer = new[] { 4, 3 }; // advantage A

            pointIndexOfPlayer[0]++;

            var score = "";
            if (pointIndexOfPlayer[0] >= POINT_VALUES.Length)
                score = "Game over";

            Assert.AreEqual("Game over", score);   
        }

        [Test]
        public void Losing_advantage()
        {
            var pointIndexOfPlayer = new[] { 4, 3 }; // advantage A

            pointIndexOfPlayer[0]--;

            var score = "";
            if (pointIndexOfPlayer[0] == 3 && (pointIndexOfPlayer[0] == pointIndexOfPlayer[1]))
                score = "Deuce";

            Assert.AreEqual("Deuce", score);   
        }
    }


    class Referee
    {
        public enum Players
        {
            Player1,
            Player2
        }

        readonly string[] POINT_VALUES = new string[] { "0", "15", "30", "40", "Advantage" };
        private const int INDEX_FORTY_POINTS = 3;
        readonly int[] _pointIndexOfPlayer = new int[2];


        internal Referee(int[] pointIndexOfPlayer) { _pointIndexOfPlayer = pointIndexOfPlayer; }
        public Referee() {}


        public string RegisterWinFor(Players player)
        {
            _pointIndexOfPlayer[(int)player]++;
            return Build_score();
        }


        internal string Build_score()
        {
            if (Is_game_over_before_deuce())
                return "Game over";

            if (Is_game_in_deuce_state())
                return "Deuce";

            return string.Format("{0}:{1}", POINT_VALUES[_pointIndexOfPlayer[0]], POINT_VALUES[_pointIndexOfPlayer[1]]);
        }

        private bool Is_game_in_deuce_state()
        {
            return _pointIndexOfPlayer[0] == 3 && (_pointIndexOfPlayer[0] == _pointIndexOfPlayer[1]);
        }

        private bool Is_game_over_before_deuce()
        {
            return (POINT_VALUES[_pointIndexOfPlayer[0]] == "Advantage" && _pointIndexOfPlayer[1] < INDEX_FORTY_POINTS) ||
                   (POINT_VALUES[_pointIndexOfPlayer[1]] == "Advantage" && _pointIndexOfPlayer[0] < INDEX_FORTY_POINTS);
        }
    }
}
