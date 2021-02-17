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
        public async Task LeaveLobby(string playerID, string lobbyID)
        {
            Lobby lobby = GameDatabase.Lobbies.Find(x => x.ID == lobbyID);

            lobby.Players.RemoveAll(x => x.ID == playerID);
            lobby.Team1.Players.RemoveAll(x => x.ID == playerID);
            lobby.Team2.Players.RemoveAll(x => x.ID == playerID);
            await Groups.RemoveFromGroupAsync(playerID, lobby.ID);
            await Clients.OthersInGroup(lobby.ID).SendAsync("LeaveLobby");
            await Clients.Client(playerID).SendAsync("LeavingPlayer");
        }
        public async Task ClosedLobby(string lobbyID)
        {
            Player[] players = GameDatabase.Lobbies.Find(x => x.ID == lobbyID).Players.ToArray();
            GameDatabase.Lobbies.RemoveAll(x => x.ID == lobbyID);
            await Clients.Group(lobbyID).SendAsync("ClosedLobby");
            foreach (var player in players)
            {
                await Groups.RemoveFromGroupAsync(player.ID, lobbyID);
            }
        }
        public async Task UpdateGameSetting(string lobbyID) => await Clients.OthersInGroup(lobbyID).SendAsync("Refresh");
        #endregion

        #region Round Start
        public async Task RoundStart(string lobbyID/*, int counter*/)
        {
            Game game = GameDatabase.Lobbies.Find(x => x.ID == lobbyID).Game;
            if (game.WinnerCheck())
            {
                game.ResetGame();
                await _clients.Group(lobbyID).SendAsync("GameOver");
            }
            else
            {
                game.GenerateGame();
                await _clients.Group(lobbyID).SendAsync("RoundStart");
                //StartRoundStartCounter(lobbyID, counter);
            }

        }
        //private void StartRoundStartCounter(string lobbyID, int counter)
        //{
        //    _timer = new MyTimer(1000, GameConfig.RoundStartCounter, null, () => StartGameCounter(lobbyID, counter));
        //    _timer.StartTimer();
        //}
        #endregion

        #region GAME
        public async Task StartRound(string lobbyID, int counter)
        {
            await _clients.Group(lobbyID).SendAsync("StartRound");
            StartGameCounter(lobbyID, counter);
        }
        private void StartGameCounter(string lobbyId, int counter)
        {
            _timer = new MyTimer(1000, counter, null, async () => await _self.RoundStart(lobbyId/*, counter*/));
            _timer.StartTimer();
        }
        #endregion

        #region WORD CARD CONTROLLER
        public async Task NewWord(string lobbyID) => await Clients.Group(lobbyID).SendAsync("Refresh");
        #endregion
    }
}