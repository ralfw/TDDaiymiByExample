using System;

namespace TennisV2
{
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


        public string CurrentScore { get { return Score_wins(); } }

        public string Winner {get { return Is_game_over() ? _playerNames[Leading_player()] : ""; }}


        public string RegisterWinFor(Players player)
        {
            if (!Is_game_over())
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


        internal bool Is_game_over()
        {
            return Math.Abs(_playerWins[0] - _playerWins[1]) >= 2 &&
                   Math.Max(_playerWins[0], _playerWins[1]) > INDEX_FORTY_POINTS;
        }

        private bool Is_advantage()
        {
            return Math.Abs(_playerWins[0] - _playerWins[1]) == 1 && _playerWins[Leading_player()] > INDEX_FORTY_POINTS;
        }

        internal int Leading_player()
        {
            return _playerWins[0] > _playerWins[1] ? 0 : 1;
        }

        private bool Is_deuce()
        {
            return _playerWins[0] == _playerWins[1] && _playerWins[0] >= INDEX_FORTY_POINTS;
        }
    }
}