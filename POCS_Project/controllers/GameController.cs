using MagicTrickServer;
using POCS_Project.entities;
using POCS_Project.utils;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Game> Index()
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
            return response;
        }
    
        public int Create(string nameGame, string Group, string password)
        {
            string response = Jogo.CriarPartida(nameGame, Group, password);
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
        
        public List<Card> GetCards(List<Player>playersInGame, int idPartida)
        {
            var response = new List<Card>();
            try
            {
                foreach(string strCard in Regex.Split(Jogo.ConsultarMao(idPartida),"\r\n"))
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
    }
}
