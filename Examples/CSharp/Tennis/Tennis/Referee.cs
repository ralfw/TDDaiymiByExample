namespace Tennis
{
    public class Referee
    {
        public enum Players
        {
            Player1,
            Player2
        }

        readonly string[] POINT_VALUES = new string[] { "Love", "15", "30", "40", "Advantage" };
        private const int INDEX_FORTY_POINTS = 3;
        private readonly int[] _pointIndexOfPlayer;

        private readonly string _namePlayer1;
        private readonly string _namePlayer2;


        internal Referee(string namePlayer1, string namePlayer2, int[] pointIndexOfPlayer)
        {
            _namePlayer1 = namePlayer1;
            _namePlayer2 = namePlayer2;
            _pointIndexOfPlayer = pointIndexOfPlayer;
        }
        public Referee(string namePlayer1, string namePlayer2) : this(namePlayer1, namePlayer2, new int[2]) {}


        public string CurrentScore { get { return Build_score(); } }

        public string Winner {get
        {
            if (Is_game_over())
                return _pointIndexOfPlayer[0] > _pointIndexOfPlayer[1] ? _namePlayer1 : _namePlayer2;
            return "";
        }}

        public string RegisterWinFor(Players player)
        {
            Adjust_points_for_winner(player);
            return Build_score();
        }


        private void Adjust_points_for_winner(Players player)
        {
            if (!Is_game_over())
                if (Is_in_advantage_state())
                {
                    if (Is_advantage_player((int) player))
                        _pointIndexOfPlayer[(int) player]++;
                    else
                        _pointIndexOfPlayer[(int) (player == Players.Player1 ? Players.Player2 : Players.Player1)]--;
                }
                else
                    _pointIndexOfPlayer[(int) player]++;
        }


        internal string Build_score()
        {
            if (Is_game_over())
                return "Game over";

            if (Is_game_in_deuce_state())
                return "Deuce";

            if (Is_in_advantage_state())
                return Build_advantage_score();

            return Build_non_advantage_score();
        }

        internal bool Is_game_over()
        {
            return Is_game_over_from_advantage() || Is_game_over_before_deuce();
        }

        private bool Is_game_over_before_deuce()
        {
            return (POINT_VALUES[_pointIndexOfPlayer[0]] == "Advantage" && _pointIndexOfPlayer[1] < INDEX_FORTY_POINTS) ||
                   (POINT_VALUES[_pointIndexOfPlayer[1]] == "Advantage" && _pointIndexOfPlayer[0] < INDEX_FORTY_POINTS);
        }

        private bool Is_game_over_from_advantage()
        {
            return _pointIndexOfPlayer[0] >= POINT_VALUES.Length || _pointIndexOfPlayer[1] >= POINT_VALUES.Length;
        }

        private bool Is_game_in_deuce_state()
        {
            return _pointIndexOfPlayer[0] == 3 && (_pointIndexOfPlayer[0] == _pointIndexOfPlayer[1]);
        }

        private bool Is_in_advantage_state()
        {
            return Is_advantage_player(0) || Is_advantage_player(1);
        }

        private bool Is_advantage_player(int indexPlayer)
        {
            return POINT_VALUES[_pointIndexOfPlayer[indexPlayer]] == "Advantage";
        }

        private string Build_advantage_score()
        {
            return "Advantage " + (Is_advantage_player(0) ? _namePlayer1 : _namePlayer2);
        }

        private string Build_non_advantage_score()
        {
            return string.Format("{0}:{1}", POINT_VALUES[_pointIndexOfPlayer[0]], POINT_VALUES[_pointIndexOfPlayer[1]]);
        }
    }
}