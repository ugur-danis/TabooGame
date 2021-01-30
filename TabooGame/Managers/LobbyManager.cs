using System.Collections.Generic;
using System.Linq;
using TabooGame.Models;

namespace TabooGame.Managers
{
    public static class LobbyManager
    {
        public static bool CheckArePlayersReady(this Lobby lobby) => lobby.ReadyPlayers.Count == lobby.Players.Count;
        public static void ClearReadyPlayers(this Lobby lobby) => lobby.ReadyPlayers.Clear();
        public static Lobby CreateLobby(this List<Lobby> lobbies, Player admin)
        {
            System.Random random = new System.Random();
            string randomID = "";

            do
            {
                for (int i = 0; i < 5; i++)
                    randomID += random.Next(0, 10).ToString();

            } while (lobbies.Any(x => x.ID == randomID));

            lobbies.Add(new Lobby(admin) { ID = randomID });
            return lobbies.Find(x => x.ID == randomID);
        }
        public static Lobby JoinLobby(this List<Lobby> lobbies, Player player, string lobbyID)
        {
            Lobby lobby = lobbies.Find(x => x.ID == lobbyID);
            if (lobby == null) return null;

            lobby.Players.Add(player);
            return lobby;
        }
    }
}
