using TabooGame.Data;
using TabooGame.Models;

namespace TabooGame.Managers
{
    public static class WordCardManager
    {
        public static WordCard GetWordCard(int id) => GameDatabase.WordCards.Find(x => x.ID == id);

        public static WordCard GetRandomWordCard()
        {
            int random = new System.Random().Next(0, GameConfig.WordCardsCount);
            return GetWordCard(random);
        }
    }
}
