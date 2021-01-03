using System.Collections.Generic;

namespace TabooGame.Models
{
    public class Game
    {
        public Team Team1 { get; set; } = new Team() { Players = new List<Player>() };
        public Team Team2 { get; set; } = new Team() { Players = new List<Player>() };
        public int NumberOfWin { get; set; }
        public int Counter { get; set; }
        public int RightToTaboo { get; set; }
        public int RightToPass { get; set; }
        public bool IsGameOver { get; set; }
        public bool IsRoundStart { get; set; }
        public Team CurrentPlayingTeam { get; set; } = new Team() { Players = new List<Player>() };
        public Player CurrentSpeakerPlayer { get; set; }
        public List<Player> CurrentListenerPlayers { get; set; } = new List<Player>();
        public Teams CurrentOpponentPlayers { get; set; }
        public Teams LastPlayedTeam { get; set; }
        public List<Player> LastSpeakerPlayers { get; set; } = new List<Player>();
        public List<WordCard> PastWordCards { get; set; } = new List<WordCard>();
        public WordCard WordCard { get; set; }
    }
}
