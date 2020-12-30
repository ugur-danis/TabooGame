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
        private static Game Game = new Game();

        #region LOBBY
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

        public static void AddTeam(Player player)
        {
            if (player.Team == Teams.Team1)
            {
                Team1.Add(player);
                RemoveTeam(Teams.Team2, player);
            }
            else if (player.Team == Teams.Team2)
            {
                Team2.Add(player);
                RemoveTeam(Teams.Team1, player);
            }
        }

        public static void RemoveTeam(Teams team, Player player)
        {
            Player _player = GetTeam(team).Find(x => x.ID == player.ID);

            if (_player != null)
            {
                if (team == Teams.Team1)
                    Team1.RemoveAll(x => x.ID == player.ID);
                else Team2.RemoveAll(x => x.ID == player.ID);
            }
        }

        public static bool PlayersIsReady()
        {
            List<Player> readyPlayers = Players.Where(x => x.IsReady == true).ToList();
            if (readyPlayers.Count != Players.Count) return false;
            return true;
        }
        #endregion

        #region GAME

        #endregion
    }
}
