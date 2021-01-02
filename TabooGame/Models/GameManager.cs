using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TabooGame.Data;

namespace TabooGame.Models
{
    public class GameManager
    {
        private Game _game;
        public GameManager(Game game)
        {
            _game = game;
            GameConfiguration();
        }

        #region LOBBY
        public Team GetTeam(Teams team)
        {
            return team == Teams.Team1 ? _game.Team1 : _game.Team2;
        }

        public void AddTeam(Player player)
        {
            if (player.Team == Teams.Team1)
            {
                _game.Team1.Players.Add(player);
                RemoveTeam(Teams.Team2, player);
            }
            else if (player.Team == Teams.Team2)
            {
                _game.Team2.Players.Add(player);
                RemoveTeam(Teams.Team1, player);
            }
        }

        public void RemoveTeam(Teams team, Player player)
        {
            Player _player = GetTeam(team).Players.Find(x => x.ID == player.ID);

            if (_player != null)
            {
                if (team == Teams.Team1)
                    _game.Team1.Players.RemoveAll(x => x.ID == player.ID);
                else _game.Team2.Players.RemoveAll(x => x.ID == player.ID);
            }
        }

        public bool PlayersIsLobbyReady()
        {
            List<Player> players = GameDatabase.GetPlayers();
            List<Player> readyPlayers = players.Where(x => x.IsLobbyReady == true).ToList();

            if (readyPlayers.Count != players.Count) return false;
            return true;
        }
        #endregion

        #region GAME
        public string Team1Name => _game.Team1.Name;
        public string Team2Name => _game.Team2.Name;
        public int Team1Score => _game.Team1.Score;
        public int Team2Score => _game.Team2.Score;
        public int GetCounter => _game.Counter;
        public int NumberOfWin => _game.NumberOfWin;
        public bool IsGameOver => _game.IsGameOver;
        public bool IsRounEnd => _game.IsRoundEnd;
        public int RightToPass => _game.RightToPass;
        public int RightToTaboo => _game.RightToTaboo;
        public WordCard WordCard => _game.WordCard;
        public Player CurrentSpeakerPlayer => _game.CurrentSpeakerPlayer;
        public Team CurrentPlayingTeam => _game.CurrentPlayingTeam;

        public void GameConfiguration()
        {
            _game.Team1.Name = "Team 1";
            _game.Team2.Name = "Team 2";
            _game.Team1.Score = 0;
            _game.Team2.Score = 0;
            _game.Counter = 10;
            _game.NumberOfWin = 10;
            _game.RightToPass = 3;
            _game.RightToTaboo = 3;
        }

        public void GameStart()
        {
            _game.Team1.Players.ForEach(x => x.IsNextRoundReady = false);
            _game.Team2.Players.ForEach(x => x.IsNextRoundReady = false);

            _game.Counter = 10;
            _game.RightToPass = 3;
            _game.RightToTaboo = 3;

            SetWordCard();
            SetCurrentPlayingTeam();
            SetCurrentSpeakerPlayer();
            SetCurrentListenerPlayers();
            SetCurrentOpponentPlayers();
            _game.IsRoundEnd = false;
        }

        public bool IsOpponentPlayer(Player player) => player.Team == _game.CurrentOpponentPlayers;
        public bool IsSpeakerPlayer(Player player) => player.ID == _game.CurrentSpeakerPlayer.ID;
        public void SetIsRoundEnd(bool end) => _game.IsRoundEnd = end;

        public bool PlayersIsNextRoundReady()
        {
            List<Player> players = GameDatabase.GetPlayers();
            List<Player> readyPlayers = players.Where(x => x.IsNextRoundReady == true).ToList();

            if (readyPlayers.Count != players.Count) return false;
            return true;
        }

        public void SetWordCard() => _game.WordCard = WordCardDataBase.GetRandomWordCard();

        public void SetCurrentPlayingTeam()
        {
            if (_game.LastPlayedTeam == Teams.Team1) _game.CurrentPlayingTeam = _game.Team2;
            else if (_game.LastPlayedTeam == Teams.Team2) _game.CurrentPlayingTeam = _game.Team1;
            else _game.CurrentPlayingTeam = _game.Team1;

            _game.LastPlayedTeam = _game.CurrentPlayingTeam == _game.Team1 ? Teams.Team1 : Teams.Team2;
        }

        public void SetCurrentSpeakerPlayer()
        {
            Random random = new Random();

            if (_game.CurrentPlayingTeam == _game.Team1)
            {
                if (_game.LastSpeakerPlayers.Where(x => x.Team == Teams.Team1).ToList().Count == _game.Team1.Players.Count)
                    _game.LastSpeakerPlayers.Where(x => x.Team == Teams.Team1).ToList().Clear();

                _game.CurrentSpeakerPlayer = _game.Team1.Players[random.Next(0, _game.Team1.Players.Count)];
                _game.LastSpeakerPlayers.Add(_game.CurrentSpeakerPlayer);
            }
            else if (_game.CurrentPlayingTeam == _game.Team2)
            {
                if (_game.LastSpeakerPlayers.Where(x => x.Team == Teams.Team2).ToList().Count == _game.Team2.Players.Count)
                    _game.LastSpeakerPlayers.Where(x => x.Team == Teams.Team2).ToList().Clear();

                _game.CurrentSpeakerPlayer = _game.Team2.Players[random.Next(0, _game.Team2.Players.Count)];
                _game.LastSpeakerPlayers.Add(_game.CurrentSpeakerPlayer);
            }
        }

        public void SetCurrentListenerPlayers()
        {
            _game.CurrentListenerPlayers = _game.CurrentPlayingTeam.Players.Where(x => x.ID != _game.CurrentSpeakerPlayer.ID).ToList();
        public void TrueButton()
        {
            _game.CurrentPlayingTeam.Score++;
            SetWordCard();
        }

        public void SetCurrentOpponentPlayers()
        public void TabooButton()
        {
            _game.CurrentPlayingTeam.Score--;
            SetWordCard();
        }
        #endregion
    }
}
