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
            var pointValues = new[] {"0", "15"};
            var pointIndexPlayer1 = 1;
            var pointIndexPlayer2 = 0;
            var score = string.Format("{0}:{1}", pointValues[pointIndexPlayer1], pointValues[pointIndexPlayer2]);
            Assert.AreEqual("15:0", score);
        }

        [Test]
        public void Second_win_same_player()
        {
            var pointValues = new[] {"0", "15", "30"};
            var pointIndexPlayer1 = 0;
            var pointIndexPlayer2 = 0;

            pointIndexPlayer1++;
            pointIndexPlayer1++;
            
            var score = string.Format("{0}:{1}", pointValues[pointIndexPlayer1], pointValues[pointIndexPlayer2]);
            Assert.AreEqual("30:0", score);
        }

        [Test]
        public void Players_winning_alternately()
        {
            var pointValues = new[] { "0", "15", "30" };
            var pointIndexOfPlayer = new int[2];

            pointIndexOfPlayer[0]++;
            pointIndexOfPlayer[1]++;
            pointIndexOfPlayer[0]++;

            var score = string.Format("{0}:{1}", pointValues[pointIndexOfPlayer[0]], pointValues[pointIndexOfPlayer[1]]);
            Assert.AreEqual("30:15", score);
        }
    }
}
