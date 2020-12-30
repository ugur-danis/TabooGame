using System.Collections.Generic;

namespace TabooGame.Models
{
    public class Game
    {
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public int NumberOfWin { get; set; }
        public int Countdown { get; set; }
        public int RightToTaboo { get; set; }
        public int RightToPass { get; set; }
        public bool IsGameOver { get; set; }
        public bool IsRoundEnd { get; set; }
        public Team CurrentPlayingTeam { get; set; }
        public Player CurrentSpeakerPlayer { get; set; }
        public List<Player> CurrentListenerPlayers { get; set; }
        public Team CurrentOpponentPlayers { get; set; }   // Gerekirse Teams enum yerine, Player listesi al
        public Teams LastPlayedTeam { get; set; }
        public List<Player> LastSpeakerPlayers { get; set; }
        public List<WordCard> PastWordCards { get; set; }
        public WordCard WordCard { get; set; }
    }
}
