using static TabooGame.Data.GameDatabase;

namespace TabooGame.Models
{
    public class Player
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        public Teams Team { get; set; }
        public bool IsLobbyReady { get; set; }
        public bool IsNextRoundReady { get; set; }
    }
}
