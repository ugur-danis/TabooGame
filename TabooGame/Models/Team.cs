using System.Collections.Generic;

namespace TabooGame.Models
{
    public class Team
    {
        public Team() => Players = new List<Player>();
        public string Name { get; set; }
        public List<Player> Players { get; set; }
    }
}
