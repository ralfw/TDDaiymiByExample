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
            Assert.AreEqual("15:Love", score);
        }
    }
}
