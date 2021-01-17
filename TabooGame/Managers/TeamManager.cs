using TabooGame.Models;

namespace TabooGame.Managers
{
    public static class TeamManager
    {
        public static void AddPlayer(this Team team, Player player)
        {
            if (!team.Players.Contains(player))
                team.Players.Add(player);
        }
        public static void RemovePlayer(this Team team, Player player) =>
            team.Players.Remove(player);
        public static void ChangeTeam(this Player player, Team newTeam, Team oldTeam)
        {
            newTeam.AddPlayer(player);
            oldTeam.RemovePlayer(player);
        }
    }
}
