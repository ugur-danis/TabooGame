using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using TabooGame.Data;
using TabooGame.Models;

namespace TabooGame.Hubs
{
    public class GameHub : Hub
    {
        public const string url = "/gameHub";

        public void PlayerLogin(Player player)
        {
            player.ID = Context.ConnectionId;
            GameDatabase.players.Add(player);
        }

        public async Task CreateLobby(Player player)
        {
            await Groups.AddToGroupAsync(player.ID, player.LobbyName);
        }

        public async Task JoinLobby(Player player)
        {
            await Groups.AddToGroupAsync(player.ID, player.LobbyName);
            await Clients.OthersInGroup(player.LobbyName).SendAsync($"{player.Name} is join the lobby.");
        }
    }
}
