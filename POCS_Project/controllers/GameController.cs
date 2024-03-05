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

        public List<Game> Index()
        {
            var response = new List<Game>();
            string[] arrStrGames = Regex.Split(Jogo.ListarPartidas("T"), "\r\n")
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
                    Players = GetAllPlayers(id)
                });
            }
            return response;
        }
    
        public int Create(string nameGame, string Group, string password)
        {
            return Convert.ToInt32(Jogo.CriarPartida(nameGame, Group, password));
        }

        private List<Player> GetAllPlayers(int id)
        {
            var response = new List<Player>();
            string strPlayers = Jogo.ListarJogadores(id);
            string[] arrStrPlayers = Regex.Split(strPlayers, "\r\n")
                    .Where(x => x.Count() > 0)
                    .ToArray();
            foreach (string strPlayer in arrStrPlayers)
            {
                string[] arrPlayer = Regex.Split(strPlayer, ",");
                response.Add(new Player
                {
                    Id = Convert.ToInt32(arrPlayer[0]),
                    Name = arrPlayer[1],
                    Record = Convert.ToInt32(arrPlayer[2])
                });
            }
            return response;
        }

    }
}
