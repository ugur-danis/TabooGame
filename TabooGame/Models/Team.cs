using System.Collections.Generic;

namespace TabooGame.Models
{
    public class Team
    {
        public int Score { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; }
    }
}
