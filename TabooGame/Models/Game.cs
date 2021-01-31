using System.Collections.Generic;
using TabooGame.Data;

namespace TabooGame.Models
{
    public class Game
    {
        public Game(Lobby lobby)
        {
            Lobby = lobby;
            NumberOfWin = GameConfig.SelectNumberOfWin[GameConfig.DefaultNumberOfWinIndex];
            Counter = GameConfig.SelectCounter[GameConfig.DefaultCounterIndex];
            RemainingPass = GameConfig.SelectRightToPass[GameConfig.DefaultRightToPassIndex];
        }

        public Lobby Lobby { get; set; }

        public int NumberOfWin { get; set; }
        public int Counter { get; set; }
        public int RemainingPass { get; set; }

        public int TeamQueue { get; set; }
        public int Team1PlayersQueue { get; set; }
        public int Team2PlayersQueue { get; set; }

        public int Team1Score { get; set; }
        public int Team2Score { get; set; }

        public Team CurrentPlayingTeam { get; set; }
        public Player CurrentNarratorPlayer { get; set; }

        public WordCard WordCard { get; set; }
        public List<WordCard> PastWordCards { get; set; }
    }
}
