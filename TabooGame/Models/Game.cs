using System.Collections.Generic;

namespace TabooGame.Models
{
    public class Game
    {
        public Game(Lobby lobby, int numberOfWin, int counter, int rightToTaboo, int rightToPass)
        {
            Lobby = lobby;
            NumberOfWin = numberOfWin;
            Counter = counter;
            RightToTaboo = rightToTaboo;
            RightToPass = rightToPass;
        }

        public Lobby Lobby { get; set; }

        public int NumberOfWin { get; set; }
        public int Counter { get; set; }
        public int RightToTaboo { get; set; }
        public int RightToPass { get; set; }

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
