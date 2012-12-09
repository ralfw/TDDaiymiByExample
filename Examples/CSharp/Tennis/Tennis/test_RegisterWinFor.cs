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
            var pointIndexOfPlayer = new int[] {1, 0};

            var score = Build_score(pointIndexOfPlayer);
            Assert.AreEqual("15:0", score);
        }

        [Test]
        public void Second_win_same_player()
        {
            var pointIndexOfPlayer = new int[2];

            pointIndexOfPlayer[0]++;
            pointIndexOfPlayer[0]++;

            var score = Build_score(pointIndexOfPlayer);
            Assert.AreEqual("30:0", score);
        }

        [Test]
        public void Players_winning_alternately()
        {
            var pointIndexOfPlayer = new int[2];

            pointIndexOfPlayer[0]++;
            pointIndexOfPlayer[1]++;
            pointIndexOfPlayer[0]++;

            var score = Build_score(pointIndexOfPlayer);
            Assert.AreEqual("30:15", score);
        }

        [Test]
        public void Winning_a_game_without_deuce()
        {
            var pointIndexOfPlayer = new int[2];

            pointIndexOfPlayer[0]++; // 15:0
            pointIndexOfPlayer[0]++; // 30:0
            pointIndexOfPlayer[0]++; // 40:0
            pointIndexOfPlayer[0]++; // Game over

            var score = pointIndexOfPlayer[0] >= POINT_VALUES.Length ? "Game over" : POINT_VALUES[pointIndexOfPlayer[0]];

            Assert.AreEqual("Game over", score);
        }

        [Test]
        public void Entering_deuce_state()
        {
            var pointIndexOfPlayer = new[]{3,2}; // 40:30

            pointIndexOfPlayer[1]++; // 40:40

            var score = pointIndexOfPlayer[0] == 3 && (pointIndexOfPlayer[0] == pointIndexOfPlayer[1]) ? "Deuce" : "?";

            Assert.AreEqual("Deuce", score);
        }


        readonly string[] POINT_VALUES = new string[]{ "0", "15", "30", "40"};

        string Build_score(int[] pointIndexOfPlayer)
        {
            var score = string.Format("{0}:{1}", POINT_VALUES[pointIndexOfPlayer[0]], POINT_VALUES[pointIndexOfPlayer[1]]);
            return score;
        }
    }
}
