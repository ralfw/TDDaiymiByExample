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
            var sut = new Referee("", "", new[] {1, 0});
            Assert.AreEqual("15:0", sut.Build_score());
        }

        [Test]
        public void Second_win_same_player()
        {
            var sut = new Referee("", "");

            sut.RegisterWinFor(Referee.Players.Player1);
            var score = sut.RegisterWinFor(Referee.Players.Player1);

            Assert.AreEqual("30:0", score);
        }

        [Test]
        public void Players_winning_alternately()
        {
            var sut = new Referee("", "");

            sut.RegisterWinFor(Referee.Players.Player1);
            sut.RegisterWinFor(Referee.Players.Player2);
            var score = sut.RegisterWinFor(Referee.Players.Player1);

            Assert.AreEqual("30:15", score);
        }

        [Test]
        public void Winning_a_game_without_deuce()
        {
            var sut = new Referee("", "");

            sut.RegisterWinFor(Referee.Players.Player1);
            sut.RegisterWinFor(Referee.Players.Player1);
            sut.RegisterWinFor(Referee.Players.Player1);
            var score = sut.RegisterWinFor(Referee.Players.Player1);

            Assert.AreEqual("Game over", score);
        }

        [Test]
        public void Entering_deuce_state()
        {
            var sut = new Referee("", "", new[] { 3, 2 }); // 40:30

            var score = sut.RegisterWinFor(Referee.Players.Player2);

            Assert.AreEqual("Deuce", score);
        }

        [Test]
        public void Gaining_advantage()
        {
            var sut = new Referee("A", "B", new[] {3, 3});
            var score = sut.RegisterWinFor(Referee.Players.Player1);
            Assert.AreEqual("Advantage A", score);
        }

        [Test]
        public void Losing_advantage()
        {
            var sut = new Referee("A", "B", new[] {4, 3}); // advantage A
            var score = sut.RegisterWinFor(Referee.Players.Player2);
            Assert.AreEqual("Deuce", score);   
        }

        [Test]
        public void Winning_game_from_advantage()
        {
            var sut = new Referee("A", "B", new[] { 4, 3 }); // advantage A
            var score = sut.RegisterWinFor(Referee.Players.Player1);
            Assert.AreEqual("Game over", score);   
        }

        [Test]
        public void Registering_wins_after_game_over_does_not_change_score()
        {
            var sut = new Referee("A", "B", new[] {3, 2}); // 40:30
            var score = sut.RegisterWinFor(Referee.Players.Player1); // A wins the game
            score = sut.RegisterWinFor(Referee.Players.Player2);
            Assert.AreEqual("Game over", score);
        }
    }
}
