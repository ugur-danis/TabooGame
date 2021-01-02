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

        public override async Task OnConnectedAsync() =>
            await Clients.Caller.SendAsync("GetPlayerID", Context.ConnectionId);

        #region LOBBY
        public void JoinLobby(Player player)
        {
            Groups.AddToGroupAsync(player.ID, lobbyName);
            Clients.OthersInGroup(lobbyName).SendAsync("JoinLobby");
        }
        public void JoinTeam() => Clients.OthersInGroup(lobbyName).SendAsync("Refresh");
        #endregion

        #region GAME
        public void GameStart()
        {
            GameDatabase.GameManager.GameStart();
            Clients.Group(lobbyName).SendAsync("GameStart");
        }
        public void TrueButton() => Clients.OthersInGroup(lobbyName).SendAsync("Refresh");
        public void TabooButton() => Clients.OthersInGroup(lobbyName).SendAsync("Refresh");
        public void PassButton() => Clients.OthersInGroup(lobbyName).SendAsync("Refresh");
        #endregion
    }
}
