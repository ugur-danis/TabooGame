using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace TabooGame.Hubs
{
    public class GameHub : Hub
    {
        public const string url = "/gameHub";

        public override async Task OnConnectedAsync() =>
            await Clients.Caller.SendAsync("GetPlayerID", Context.ConnectionId);

        #region LOGIN LOBBY
        public async Task CreateLobby(string adminID, string lobbyName) => await Groups.AddToGroupAsync(adminID, lobbyName);
        public async Task JoinLobby(string playerID, string lobbyName)
        {
            await Groups.AddToGroupAsync(playerID, lobbyName);
            await Clients.OthersInGroup(lobbyName).SendAsync("Refresh");
        }
        #endregion

        #region LOBBY
        public async Task ChangeTeam(string lobbyID) => await Clients.OthersInGroup(lobbyID).SendAsync("Refresh");
        public async Task RoundStart(string lobbyID) => await Clients.Group(lobbyID).SendAsync("RoundStart");
        #endregion

        #region GAME
        public async Task StartGame(string lobbyID) => await Clients.OthersInGroup(lobbyID).SendAsync("StartGame");
        #endregion
    }
}