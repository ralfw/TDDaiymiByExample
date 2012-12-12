using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TennisV2.tests
{
    [TestFixture]
    public class test_CurrentScore
    {
        [Test]
        public void Reflects_score_returned_by_last_RegisterWinFor_call()
        {
            var sut = new Referee("", "");
            Assert.AreEqual("Love:Love", sut.CurrentScore);
            sut.RegisterWinFor(Referee.Players.Player1);
            Assert.AreEqual("15:Love", sut.CurrentScore);
        }
    }
}
