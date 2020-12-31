using System.Collections.Generic;
using System.Linq;
using TabooGame.Models;

namespace TabooGame.Data
{
    public static class GameDatabase
    {
        private static List<Player> Players = new List<Player>();
        private static Game Game = new Game();
        public static GameManager GameManager = new GameManager(Game);

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

        #endregion
    }
}
