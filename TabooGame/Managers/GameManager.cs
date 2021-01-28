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
        private static void SetWordCard(this Game game) =>
            game.WordCard = new WordCard
            {
                ID = 0,
                Word = "Test",
                ForbiddenWords = new System.Collections.Generic.List<string>
                {
                    "A",
                    "B",
                    "C",
                    "D",
                    "E"
                }
            };
        public static void RightGuess(this Game game)
        {
            if (game.CurrentPlayingTeam == game.Lobby.Team1)
                game.Team1Score++;
            else
                game.Team2Score++;
            SetWordCard(game);
        }
        public static void ForbiddenWord(this Game game)
        {
            if (game.CurrentPlayingTeam == game.Lobby.Team1)
                game.Team1Score--;
            else
                game.Team2Score--;
            SetWordCard(game);
        }
        public static void SkipWord(this Game game) => SetWordCard(game);
    }
}
