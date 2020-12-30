using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using TabooGame.Data;
using TabooGame.Models;

namespace TabooGame.Hubs
{
    public class GameHub : Hub
    {
        public const string url = "/gameHub";
        private const string lobbyName = "MainLobby";

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("GetPlayerID", Context.ConnectionId);
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
