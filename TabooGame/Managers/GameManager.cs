using TabooGame.Data;
using TabooGame.Models;

namespace TabooGame.Managers
{
    public static class GameManager
    {
        public static void GenerateGame(this Game game)
        {
            SetNextTeam(game);
            SetNextNarratorPlayer(game);
            SetWordCard(game);
        }
        private static void SetNextTeam(this Game game) =>
            game.CurrentPlayingTeam = game.TeamQueue++ % 2 == 0 ? game.Lobby.Team1 : game.Lobby.Team2;
        private static void SetNextNarratorPlayer(this Game game)
        {
            game.CurrentNarratorPlayer =
                game.CurrentPlayingTeam.Players
                [
                    game.CurrentPlayingTeam == game.Lobby.Team1
                    ? game.Team1PlayersQueue++ : game.Team2PlayersQueue++
                ];

            if (game.Team1PlayersQueue >= game.Lobby.Team1.Players.Count) game.Team1PlayersQueue = 0;
            if (game.Team2PlayersQueue >= game.Lobby.Team2.Players.Count) game.Team2PlayersQueue = 0;
        }
        private static void SetWordCard(this Game game)
        {
            if (game.PastWordCards.Count == GameConfig.WordCardsCount)
                game.PastWordCards.Clear();
            do
            {
                game.WordCard = WordCardManager.GetRandomWordCard();
            }
            while (game.PastWordCards.Contains(game.WordCard));

            game.PastWordCards.Add(game.WordCard);
        }
        public static void RightGuess(this Game game)
        {
            if (game.CurrentPlayingTeam == game.Lobby.Team1)
                game.Team1Score++;
            else
                game.Team2Score++;
            SetWordCard(game);
        }
        public static void TabooWord(this Game game)
        {
            if (game.CurrentPlayingTeam == game.Lobby.Team1)
                game.Team1Score--;
            else
                game.Team2Score--;
            SetWordCard(game);
        }
        public static void SkipWord(this Game game) => SetWordCard(game);
        public static bool WinnerCheck(this Game game) => game.Team1Score >= game.NumberOfWin || game.Team2Score >= game.NumberOfWin;
        public static void ResetGame(this Game game)
        {
            game.TeamQueue = 0;
            game.Team1Score = 0;
            game.Team2Score = 0;
            game.Team1PlayersQueue = 0;
            game.Team2PlayersQueue = 0;
        }
    }
}
