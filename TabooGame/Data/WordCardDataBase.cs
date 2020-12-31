using System;
using System.Collections.Generic;
using TabooGame.Models;

namespace TabooGame.Data
{
    public static class WordCardDataBase
    {
        private static List<WordCard> WordCards = new List<WordCard>
        {
            new WordCard
            {
                ID = 0,
                Word = "Salata",
                ForbiddenWords = new List<string>
                {
                    "Sebze","Meyve","Yeşil","Hıyar","Tuz"
                },
                Asked = false
            },
            new WordCard
            {
                ID = 1,
                Word = "ASD",
                ForbiddenWords = new List<string>
                {
                    "ASD 1","ASD 2","ASD 3","ASD 4","ASD 5"
                },
                Asked = false
            }
        };

        public static WordCard GetRandomWordCard()
        {
            Random random = new Random();

            if (WordCards.Count == WordCards.Where(x => x.Asked).ToList().Count)
                WordCards.ForEach(x => x.Asked = false);

            int wordCardIndex = random.Next(0, WordCards.Count);

            while (WordCards[wordCardIndex].Asked == true)
            {
                wordCardIndex = random.Next(0, WordCards.Count);
            }

            WordCards[wordCardIndex].Asked = true;
            return WordCards[wordCardIndex];
        }
    }
}
