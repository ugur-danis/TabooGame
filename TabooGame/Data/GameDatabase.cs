using System.Collections.Generic;
using System.Linq;
using TabooGame.Models;

namespace TabooGame.Data
{
    public static class GameDatabase
    {
        private static List<Player> Players = new List<Player>();
        private static List<Player> Team1 = new List<Player>();
        private static List<Player> Team2 = new List<Player>();
        public static Player GetPlayer(string id)
        {
            return Players.Where(x => x.ID == id).FirstOrDefault();
        }

        public static List<Player> GetPlayers()
        {
            return Players;
        }
        public static void AddPlayer(Player player)
        {
            Players.Add(player);
        }
        public static void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }
        public static List<Player> GetTeam(Teams team)
        {
            return team == Teams.Team1 ? Team1 : Team2;
        }
    }
}
