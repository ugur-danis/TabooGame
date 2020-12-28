namespace TabooGame.Models
{
    public class Player
    {
        public string Name { get; set; }
        public string LobbyName { get; set; }
        public bool IsAdmin { get; set; }

        public Player(string name, string lobbyName)
        {
            Name = name;
            LobbyName = lobbyName;
        }
    }
}
