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
<<<<<<< HEAD
        public static int[] SelectNumberOfWin { get; } = new int[] { 10, 20, 30, 40, 50 };
        public static int[] SelectCounter { get; } = new int[] { 30, 40, 50, 60, 70, 80, 90 };
        public static int[] SelectRightToPass { get; } = new int[] { 1, 2, 3 };
        public static int RoundStartCounter { get; } = 5;
        public static int DefaultNumberOfWinIndex { get; } = 0;
        public static int DefaultCounterIndex { get; } = 3;
        public static int DefaultRightToPassIndex { get; } = 2;
=======
        public static int StartRoundStartCounter { get; } = 5;
>>>>>>> parent of 075ccec... Rename StartRoundStartCounter to RoundStartCounter
    }
}
