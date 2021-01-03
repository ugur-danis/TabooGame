using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.SignalR;
using TabooGame.Data;
using TabooGame.Models;

namespace TabooGame.Hubs
{
    public class GameHub : Hub
    {
        private IHubCallerClients hubClients;

        public const string url = "/gameHub";
        private const string lobbyName = "MainLobby";
        private Timer timer;
        private int counter;


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
        public void GenerateGame()
        {
            GameDatabase.GameManager.GenerateGame();
            if (hubClients != null)
                hubClients.Group(lobbyName).SendAsync("GenerateGame");
            else
                Clients.Group(lobbyName).SendAsync("GenerateGame");
        }
        public void StartGame()
        {
            Clients.Group(lobbyName).SendAsync("StartGame");
            StartCounter();
        }
        public void TrueButton() => Clients.OthersInGroup(lobbyName).SendAsync("Refresh");
        public void TabooButton() => Clients.OthersInGroup(lobbyName).SendAsync("Refresh");
        public void PassButton() => Clients.OthersInGroup(lobbyName).SendAsync("Refresh");
        public void StartCounter()
        {
            hubClients = Clients;
            counter = GameDatabase.GameManager.GetCounter;
            timer = new Timer(1000);
            timer.Elapsed += OnTimer;
            timer.Enabled = true;
            timer.Start();
        }
        private void OnTimer(object o, ElapsedEventArgs eventArgs)
        {
            counter--;

            if (counter <= 0)
            {
                GameDatabase.GameManager.SetIsRoundStart(false);
                GenerateGame();
                timer.Dispose();
            }
        }
        #endregion
    }
}