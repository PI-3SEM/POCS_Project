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
    public class GameController
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
                    Players = _playersController.GetAllPlayers(id)
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

        private string[] GetGameStrStatus(int gameId)
        {
            string strVerifyTime = Jogo.VerificarVez(gameId);
            string[] dataVerifyTime = Regex.Split(strVerifyTime, "\r\n");
            Array.Resize(ref dataVerifyTime, dataVerifyTime.Length - 1);
            return dataVerifyTime;
        }

        public string[] GetGameStatus(int gameId, ref Game game, ref Player whoPlay, ref int currentRound)
        {
            string[] gameStrStatus = GetGameStrStatus(gameId);            
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
                foreach(string strCard in Regex.Split(Jogo.ConsultarMao(gameId),"\r\n"))
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
    
        public Dictionary<Player, int> GetWinners(int gameId, List<Player> playersInGame)
        {
            Dictionary<Player, int> response = new Dictionary<Player, int>();
            Dictionary<int, List<Round>> roundsGrouped = new Dictionary<int, List<Round>>();
            string plays = Jogo.ExibirJogadas(gameId);
            string[] playsArr = Regex.Split(plays, "\r\n").Where(x=>x.Count() > 0).ToArray();
            
            /* separa os rounds jogados em id's */
            foreach(string dataPlay in playsArr)
            {
                string[] data = Regex.Split(dataPlay, ",");
                int idRound = Convert.ToInt32(data[0]);
                int idPLayer = Convert.ToInt32(data[1]);
                Suits suitCard = (Suits)data[2][0];
                int valueCard = Convert.ToInt32(data[3]);
                if(!roundsGrouped.ContainsKey(idRound))
                   roundsGrouped.Add(idRound,new List<Round>());
                roundsGrouped[idRound].Add(new Round {
                    Id = idRound,
                    IdPLayer = idPLayer,
                    CardPlayed = new Card
                    {
                        Suit = suitCard,
                        Value = valueCard,
                    }
                });
            }
            /* conta quantidade de rodadas ganhas por cada jogador */
            foreach (KeyValuePair<int, List<Round>> rounds in roundsGrouped)
            {
                // pegando o jogador que jogou a maior carta
                Player winner = playersInGame.FirstOrDefault(x => x.Id == rounds.Value.FirstOrDefault(y => y.CardPlayed.Value == rounds.Value.Max(z => z.CardPlayed.Value)).IdPLayer);
                if(response.Count == 0 || !response.Keys.Contains(winner))
                    response.Add(winner, 1);
                else
                    response[winner]++;
            }
            
            return response;
        }
    
        public List<Card> GetPlayedCards(int gameId, List<Player> playersInGame)
        {
            string[] strPlayedCards = Regex.Split(Jogo.ExibirJogadas(gameId), "\r\n");
            Array.Resize(ref strPlayedCards, strPlayedCards.Length - 1);

            List<Card> playedCards = new List<Card>();
            foreach (string cardData in strPlayedCards)
            {
                var data = Regex.Split(cardData, ",");
                playedCards.Add(new Card
                {
                    Owner = playersInGame.FirstOrDefault(x => x.Id == Convert.ToInt32(data[1])),
                    Suit = (Suits)data[2][0],
                    Value = Convert.ToInt32(data[3])
                });
            }
            return playedCards;
        }

        public void GetBet(int gameId, ref Dictionary<Player, int> playersBet)
        {
            string[] gameStrStatus = GetGameStrStatus(gameId);
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
