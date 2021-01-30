using System.Collections.Generic;
using TabooGame.Models;

namespace TabooGame.Data
{
    public static class GameDatabase
    {
        public static List<Lobby> Lobbies { get; } = new List<Lobby>();
        public static List<WordCard> WordCards { get; } = new List<WordCard>
        {
            new WordCard{ ID=0, Word = "FUAR",ForbiddenWords = new List<string>{"İZMİR","SERGİ","TİCARİ","PANAYIR","ALAN"}},
            new WordCard{ ID=1, Word = "ATTİLA İLHAN",ForbiddenWords = new List<string>{"BEN SANA MECBURUM","ŞAİR","DENEME","YAZAR","AYRILIK SEVDAYA DAHİL"}},
            new WordCard{ ID=2, Word = "FERMAN",ForbiddenWords = new List<string>{"TUĞRA","BUYRUK","EMİR","PADİŞAH","OSMANLI"}},
            new WordCard{ ID=3, Word = "ŞER",ForbiddenWords = new List<string>{"ŞEYTAN","HAYIR","FENALIK","KÖTÜ","KORUMAK"}},
            new WordCard{ ID=4, Word = "HOW I MET YOUR MOTHER",ForbiddenWords = new List<string>{"YABANCI","DİZİ","BARNEY","TED","SİT-COM"}},
            new WordCard{ ID=5, Word = "RADYASYON",ForbiddenWords = new List<string>{"BOZULMA","ENERJİ","DALGA","TEHLİKE","YAYILIM"}},
            new WordCard{ ID=6, Word = "KURT COBAİN",ForbiddenWords = new List<string>{"MÜZİSYEN","NİRVANA","İNTİHAR","GRUNGE","SOLİST"}},
            new WordCard{ ID=7, Word = "ANAKONDA",ForbiddenWords = new List<string>{"ÖLDÜRMEK","YILAN","SIKMAK","FİLM","KOBRA"}},
            new WordCard{ ID=8, Word = "KONÇERTO",ForbiddenWords = new List<string>{"SOLO","BESTE","ORKESTRA","ÇALGI","ÇALMAK"}},
            new WordCard{ ID=9, Word = "İŞLEMCİ",ForbiddenWords = new List<string>{"BİLGİSAYAR","MİKRO","ÇİP","INTEL","CPU"}},
            new WordCard{ ID=10, Word = "MASUMİYET",ForbiddenWords = new List<string>{"ZEKİ DEMİRKUBUZ","SAF","SUÇSUZ","TEMİZ","ORHAN PAMUK"}},
            new WordCard{ ID=11, Word = "TÜMEVARIM",ForbiddenWords = new List<string>{"İSPAT","ÖZEL","TÜMDENGELİM","GENEL","MATEMATİK"}},
            new WordCard{ ID=12, Word = "İMLA",ForbiddenWords = new List<string>{"HATA","KURAL","DİL BİLGİSİ","YAZIM","TERİM"}},
            new WordCard{ ID=13, Word = "NIKOLA TESLA",ForbiddenWords = new List<string>{"EDISON","BİLİM İNSANI","ELEKTRİK","FİZİKÇİ","MAGNETİK ALAN"}},
            new WordCard{ ID=14, Word = "TÜZÜK",ForbiddenWords = new List<string>{"YÖNETMELİK","KURAL","BAKANLIK","KANUN","MEVZUAT"}},
            new WordCard{ ID=15, Word = "TAVİZ",ForbiddenWords = new List<string>{"İVAZ","VERMEK","FERAGAT","ÖDÜN","UZLAŞMAK"}},
            new WordCard{ ID=16, Word = "MESAFE",ForbiddenWords = new List<string>{"KATETMEK","UZAKLIK","IRAK","ARA","SERDAR ORTAÇ"}},
            new WordCard{ ID=17, Word = "KEHANET",ForbiddenWords = new List<string>{"HİS","BİLME","KAHİN","TAHMİN","SEZGİ"}},
            new WordCard{ ID=18, Word = "TESBİH",ForbiddenWords = new List<string>{"SİMGE","ÇEKMEK","TANE","İBADET","KÜLHANBEY"}},
            new WordCard{ ID=19, Word = "BEYTİ",ForbiddenWords = new List<string>{"FLORYA","KEBAP","YEMEK","İSKENDER","MAHLAS"}},
            new WordCard{ ID=20, Word = "BUĞU",ForbiddenWords = new List<string>{"CAM","YOĞUNLAŞMA","SICAK","BUHAR","AYNA"}},
            new WordCard{ ID=21, Word = "VAN GOGH",ForbiddenWords = new List<string>{"KESMEK","RESSAM","ŞİZOFREN","KULAK","HOLLANDA"}},
            new WordCard{ ID=22, Word = "3D",ForbiddenWords = new List<string>{"TEKNOLOJİ","BOYUT","FİLM","OYUN","GÖZLÜK"}},
            new WordCard{ ID=23, Word = "KURBAĞA PRENS",ForbiddenWords = new List<string>{"DÖNÜŞMEK","MASAL","ÖPMEK","PRENSES","HAYVAN"}},
            new WordCard{ ID=24, Word = "POYRAZ",ForbiddenWords = new List<string>{"LİMAN","RÜZGAR","AKDENİZ","KUZEY DOĞU","DENİZ"}},
            new WordCard{ ID=25, Word = "ALÜMİNYUM",ForbiddenWords = new List<string>{"DOĞRAMA","METAL","İLETKEN","AL","KİMYA"}},
            new WordCard{ ID=26, Word = "FOLİK ASİT",ForbiddenWords = new List<string>{"B12","B","KANSIZLIK","VİTAMİN","FOLAT"}},
            new WordCard{ ID=27, Word = "STÜDYO",ForbiddenWords = new List<string>{"ÇEKİM","DAİRE","PROGRAM","TELEVİZYON","KAYIT"}},
            new WordCard{ ID=28, Word = "MAT",ForbiddenWords = new List<string>{"YENMEK","ŞAH","ETMEK","SATRANÇ","UYKU TULUMU"}},
            new WordCard{ ID=29, Word = "LAPTOP",ForbiddenWords = new List<string>{"MOBİL","DİZÜSTÜ","NOTEBOOK","BİLGİSAYAR","CİHAZ"}},
            new WordCard{ ID=30, Word = "KÖPÜK",ForbiddenWords = new List<string>{"BANYO","DENİZ","TÜRK KAHVESİ","ÜST","SABUN"}},
            new WordCard{ ID=31, Word = "TAVUK ŞİŞ",ForbiddenWords = new List<string>{"IZGARA","YEMEK","ÖRGÜ","ÇUBUK","ET"}},
            new WordCard{ ID=32, Word = "ŞADIRVAN",ForbiddenWords = new List<string>{"HAVUZ","CAMİ","KUBBE","ABDEST","AVLU"}},
            new WordCard{ ID=33, Word = "KOKTEYL",ForbiddenWords = new List<string>{"TOPLANTI","KARIŞIM","PARTİ","İÇKİ","BARMEN"}},
            new WordCard{ ID=34, Word = "EVLİLİK CÜZDANI",ForbiddenWords = new List<string>{"VERMEK","NİKAH","DAMAT","GELİN","NÜFUS"}},
            new WordCard{ ID=35, Word = "KASVET",ForbiddenWords = new List<string>{"KAYGI","İÇ SIKINTI","ÇÖKMEK","HUZURSUZLUK","BASMAK"}},
            new WordCard{ ID=36, Word = "PİMPİRİK",ForbiddenWords = new List<string>{"KUŞKU","EVHAM","TİTİZLİK","İŞKİLLENMEK","GEREKSİZ"}},
            new WordCard{ ID=37, Word = "WOODY ALLEN",ForbiddenWords = new List<string>{"KOMEDİ","SİNEMA","YÖNETMEN","HOLLYWOOD","MIDNIGHT IN PARIS"}},
            new WordCard{ ID=38, Word = "SENDROM",ForbiddenWords = new List<string>{"PAZARTESİ","BELİRTİ","SEMPTOM","BULGU","SIKINTI"}},
            new WordCard{ ID=39, Word = "PAUL AUSTER",ForbiddenWords = new List<string>{"POSTMODERN","YAZAR","AMERİKAN","ŞAİR","BAŞBAKAN"}},
            new WordCard{ ID=40, Word = "MAYTAP",ForbiddenWords = new List<string>{"FİŞEK","PATLATMAK","YAKMAK","GEÇMEK","PASTA"}},
            new WordCard{ ID=41, Word = "FARENJİT",ForbiddenWords = new List<string>{"TOZ","HASTALIK","İLTİHAP","BOĞAZ","SPREY"}},
            new WordCard{ ID=42, Word = "MEHMET GÜNSÜR",ForbiddenWords = new List<string>{"AŞK TESADÜFLERİ SEVER","OYUNCU","İTALYA","O ŞİMDİ ASKER","HAMAM"}},
            new WordCard{ ID=43, Word = "DEDİKODU",ForbiddenWords = new List<string>{"YAPMAK","KONUŞMAK","GIYBET","KADIN","ARKA"}},
            new WordCard{ ID=44, Word = "RTÜK",ForbiddenWords = new List<string>{"YASAKLAMAK","RADYO","KURUL","TELEVİZYON","DENETLEMEK"}},
            new WordCard{ ID=45, Word = "GELECEKTEN BİR GÜN",ForbiddenWords = new List<string>{"ŞANSSIZLIK","FİLM","ARDA KURAL","HAYRETTİN","SİNEMA"}},
            new WordCard{ ID=46, Word = "FRANSIZ İHTİLALİ",ForbiddenWords = new List<string>{"AVRUPA","MİLLİYETÇİLİK","DEVRİM","AKIM","MONARŞİ"}},
            new WordCard{ ID=47, Word = "ÖDÜNÇ VERMEK",ForbiddenWords = new List<string>{"İSTEMEK","EŞYA","GERİ ALMAK","GERİ VERMEK","BORÇ"}},
            new WordCard{ ID=48, Word = "PERUK",ForbiddenWords = new List<string>{"YAPAY","SAÇ","TAKMA","KADIN","DOĞAL"}},
            new WordCard{ ID=49, Word = "KOMEDİ DÜKKANI",ForbiddenWords = new List<string>{"TOLGA ÇEVİK","YÖNETMEN","MİNİK","KOMEDYEN","KEL"}},
            new WordCard{ ID=50, Word = "YOYO",ForbiddenWords = new List<string>{"İP","OYUNCAK","ATMAK","ÇOCUK","GERİ GELMEK"}}
        };
    }

    public static class GameConfig
    {
        public static int[] SelectNumberOfWin { get; } = new int[] { 10, 20, 30, 40, 50 };
        public static int[] SelectCounter { get; } = new int[] { 30, 40, 50, 60, 70, 80, 90 };
        public static int[] SelectRightToPass { get; } = new int[] { 1, 2, 3 };
        public static int RoundStartCounter { get; } = 5;
        public static int DefaultNumberOfWinIndex { get; } = 0;
        public static int DefaultCounterIndex { get; } = 3;
        public static int DefaultRightToPassIndex { get; } = 2;
    }
}
