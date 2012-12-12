using NUnit.Framework;

namespace TennisV2.tests
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

        [Test]
        public void Register_wins_after_game_over_does_not_change_score()
        {
            var sut = new Referee(new string[2], new[] { 6, 4 });
            var score = sut.RegisterWinFor(Referee.Players.Player2);
            Assert.AreEqual("Game over", score);
        }
    }
}
