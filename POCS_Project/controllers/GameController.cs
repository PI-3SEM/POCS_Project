using MagicTrickServer;
using POCS_Project.entities;
using POCS_Project.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace POCS_Project.controllers
{
    public class GameController:Controller
    {
        private readonly PlayersController _playersController;

        public GameController()
        {
            _playersController = new PlayersController();
        }

        public List<Game> Index(GameSituation situation = GameSituation.All)
        {
            var response = new List<Game>();
            string[] arrStrGames = Regex.Split(Jogo.ListarPartidas("A"), "\r\n")
                .Where(x=>x.Count() > 0)
                .ToArray();

            foreach(string game in arrStrGames)
            {
                string[] arrGameData = Regex.Split(game, ",");
                int id = Convert.ToInt32(arrGameData[0]);

                response.Add(new Game
                {
                    Id = id,
                    Name = arrGameData[1],
                    Situation = arrGameData[3].SearchEnumByDisplayName<GameSituation>(),
                    Players = _playersController.GetPlayersInGame(id)
                });
            }

            if (situation != GameSituation.All)
                response.Where(x => x.Situation == situation).ToList();

            return response;
        }
    
        public int Create(string nameGame, string password, string Group = "Bratislava")
        {
            string response = Jogo.CriarPartida(nameGame, password, Group);
            try
            {
                return Convert.ToInt32(response);
            }
            catch
            {
                throw new Exception(response);
            }
        }

        public int InitGame(int idPlayer, string passwordPlayer)
        {
            // retorno: id do jogador a fazer a primeira jogada
            var response = Jogo.IniciarPartida(idPlayer,passwordPlayer);
            try
            {
                return Convert.ToInt32(response);
            }
            catch
            {
                throw new Exception(response);
            }
        }

        public string[] GetGameStatus(int gameId, ref Game game, ref Player whoPlay, ref int currentRound)
        {
            string[] gameStrStatus = GetStrStatus(Jogo.VerificarVez2(gameId));            
            string[] gameData = Regex.Split(gameStrStatus[0], ",");
            game.Situation = gameData[0].SearchEnumByDisplayName<GameSituation>();
            whoPlay = game.Players.FirstOrDefault(x=>x.Id == Convert.ToInt32(gameData[1]));
            currentRound = Convert.ToInt32(gameData[2]);
            return gameStrStatus;
        }

        public List<Card> GetCards(List<Player>playersInGame, int gameId)
        {
            var response = new List<Card>();
            try
            {
                string[] arrStrCards = Regex.Split(Jogo.ConsultarMao(gameId), "\r\n");
                
                foreach (string strCard in arrStrCards)
                {
                    string[] cardData = Regex.Split(strCard, ",");
                    response.Add(new Card
                    {
                        Owner = playersInGame.FirstOrDefault(x=>x.Id == Convert.ToInt32(cardData[0])),
                        Order = Convert.ToInt32(cardData[1]),
                        Suit = (Suits)cardData[2][0]
                    });
                }
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            return response;
        }
    
        public List<Card> GetPlayedCards(int gameId, List<Player> playersInGame)
        {
            List<Card> playedCards = new List<Card>();
            foreach (string cardData in GetStrStatus(Jogo.ExibirJogadas2(gameId)))
            {
                var data = Regex.Split(cardData, ",");
                playedCards.Add(new Card
                {
                    RoundPlayed = Convert.ToInt32(data[0]),
                    Owner = playersInGame.FirstOrDefault(x => x.Id == Convert.ToInt32(data[1])),
                    Suit = (Suits)data[2][0],
                    Value = Convert.ToInt32(data[3]),
                    Order = Convert.ToInt32(data[4]),
                });
            }
            return playedCards;
        }

        public void GetBet(int gameId, ref Dictionary<Player, int> playersBet)
        {
            string[] gameStrStatus = GetStrStatus(Jogo.VerificarVez2(gameId));
            foreach (var data in gameStrStatus.Where(x => x.StartsWith("A:")))
            {
                var arrData = Regex.Split(data, ",");
                int idPlayer = Convert.ToInt32(Regex.Split(arrData[0], ":")[1]);
                Player whoBet = playersBet.Keys.FirstOrDefault(x => x.Id == idPlayer);
                playersBet[whoBet] = Convert.ToInt32(arrData[2]);
            }
        }

    }
}
