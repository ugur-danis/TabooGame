using System.Collections.Generic;

namespace TabooGame.Models
{
    public class WordCard
    {
        public int ID { get; set; }
        public string Word { get; set; }
        public List<string> ForbiddenWords { get; set; }
        public bool Asked { get; set; }
    }
}
