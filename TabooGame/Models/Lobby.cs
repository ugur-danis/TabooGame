using System.Collections.Generic;

namespace TabooGame.Models
{
    public class Lobby
    {
        public Lobby(Player admin, string id)
        {
            ID = id;
            Admin = admin;
            Team1 = new Team();
            Team2 = new Team();
            Players = new List<Player> { admin };
            ReadyPlayers = new List<Player>();

            Team1.Name = "TEAM 1";
            Team2.Name = "TEAM 2";
        }
        public string ID { get; set; }
        public Player Admin { get; set; }
        public List<Player> Players { get; set; }
        public List<Player> ReadyPlayers { get; set; }
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public Game Game { get; set; }
    }
}
