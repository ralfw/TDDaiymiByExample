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
            var scorePlayer1 = 15;
            var scorePlayer2 = 0;
            var score = string.Format("{0}:{1}", scorePlayer1, scorePlayer2);
            Assert.AreEqual("15:0", score);
        }

        [Test]
        public void Second_win_same_player()
        {
            var pointValues = new[] {"0", "15", "30"};
            var pointIndexPlayer1 = 0;
            var pointindexPlayer2 = 0;

            pointIndexPlayer1++;
            pointIndexPlayer1++;
            
            var score = string.Format("{0}:{1}", pointValues[pointIndexPlayer1], pointValues[pointindexPlayer2]);
            Assert.AreEqual("30:0", score);
        }
    }
}
