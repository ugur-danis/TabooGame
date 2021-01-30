using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using TabooGame.Data;
using TabooGame.Managers;
using TabooGame.Models;

namespace TabooGame.Hubs
{
    public class GameHub : Hub
    {
        public const string url = "/gameHub";
        private static IHubCallerClients _clients;
        private static GameHub _self;
        private MyTimer _timer;

        public override async Task OnConnectedAsync()
        {
            _clients = Clients;
            _self = this;
            await Clients.Caller.SendAsync("GetPlayerID", Context.ConnectionId);
        }

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
        #endregion

        #region Round Start
        public async Task RoundStart(string lobbyID, int counter)
        {
            GameDatabase.Lobbies.Find(x => x.ID == lobbyID).Game.GenerateGame();
            await _clients.Group(lobbyID).SendAsync("RoundStart");
            StartRoundStartCounter(lobbyID, counter);
        }
        private void StartRoundStartCounter(string lobbyID, int counter)
        {
            _timer = new MyTimer(1000, GameConfig.RoundStartCounter, null, () => StartGameCounter(lobbyID, counter));
            _timer.StartTimer();
        }
        #endregion

        #region GAME
        private void StartGameCounter(string lobbyId, int counter)
        {
            _timer = new MyTimer(1000, counter, null, async () => await _self.RoundStart(lobbyId, counter));
            _timer.StartTimer();
        }
        #endregion
    }
}