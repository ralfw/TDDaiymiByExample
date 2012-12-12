using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TennisV2.tests
{
    [TestFixture]
    public class Acceptance_tests
    {
        [Test]
        public void Non_deuce_game()
        {
            var sut = new Referee("A", "B");
            sut.RegisterWinFor(Referee.Players.Player2);
            sut.RegisterWinFor(Referee.Players.Player2);
            sut.RegisterWinFor(Referee.Players.Player1);
            Assert.AreEqual("15:30", sut.CurrentScore);
            sut.RegisterWinFor(Referee.Players.Player1);
            sut.RegisterWinFor(Referee.Players.Player1);
            Assert.AreEqual("Game over", sut.RegisterWinFor(Referee.Players.Player1));
            Assert.AreEqual("A", sut.Winner);
        }

        [Test]
        public void Deuce_game()
        {
            var sut = new Referee("A", "B");
            sut.RegisterWinFor(Referee.Players.Player1);
            sut.RegisterWinFor(Referee.Players.Player2);
            sut.RegisterWinFor(Referee.Players.Player1);
            sut.RegisterWinFor(Referee.Players.Player1);
            sut.RegisterWinFor(Referee.Players.Player2);
            sut.RegisterWinFor(Referee.Players.Player2);
            Assert.AreEqual("Deuce", sut.CurrentScore);
            sut.RegisterWinFor(Referee.Players.Player1); 
            sut.RegisterWinFor(Referee.Players.Player2);
            sut.RegisterWinFor(Referee.Players.Player2); 
            Assert.AreEqual("Advantage B", sut.CurrentScore);
            sut.RegisterWinFor(Referee.Players.Player2);
            Assert.AreEqual("Game over", sut.CurrentScore);
            Assert.AreEqual("B", sut.Winner);
        }
    }
}
