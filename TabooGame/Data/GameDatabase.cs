using System.Collections.Generic;
using TabooGame.Models;

namespace TabooGame.Data
{
    public static class GameDatabase
    {
        public static List<Lobby> Lobbies { get; } = new List<Lobby>();
    }

    public static class GameConfig
    {
        public static int StartRoundStartCounter { get; } = 5;
    }
}
