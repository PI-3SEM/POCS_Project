using MagicTrickServer;
using POCS_Project.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace POCS_Project.controllers
{
    public class PlayersController : Controller
    {

        public List<Player> GetPlayersInGame(int gameId)
        {
            List<Player> response = new List<Player>();
            string[] playersStr = GetStrStatus(Jogo.ListarJogadores2(gameId));
            foreach (string playerStrData in playersStr)
            {
                string[] playerData = Regex.Split(playerStrData, ",");
                response.Add(new Player
                {
                    Id = Convert.ToInt32(playerData[0]),
                    Name = playerData[1],
                    RoundsWon = Convert.ToInt32(playerData[3]),
                    Score = Convert.ToInt32(playerData[2]),
                });
            }
            return response;
        }
        
        public void UpdateGameScore(int gameId, ref List<Player> players)
        {
            string[] playersStr = GetStrStatus(Jogo.ListarJogadores2(gameId));
            foreach (string playerStrData in playersStr)
            {
                string[] playerData = Regex.Split(playerStrData, ",");
                int indexPlayer = players.FindIndex(x => x.Id == Convert.ToInt32(playerData[0]));
                players[indexPlayer].Score = Convert.ToInt32(playerData[2]);
                players[indexPlayer].RoundsWon = Convert.ToInt32(playerData[3]);
            }
        }

        public Player EnterInGame(string namePlayer, string gamePassword, int idPartida)
        {
            var player = new Player{ Name = namePlayer };
            var response = Jogo.EntrarPartida(idPartida, namePlayer, gamePassword);
            try
            {
                var arrDataResponse = Regex.Split(response, "\r\n");
                arrDataResponse = Regex.Split(arrDataResponse[0], ",");
                player.Id = Convert.ToInt32(arrDataResponse[0]);
                player.Password = arrDataResponse[1];
                return player;
            }
            catch
            {
                throw new Exception(response);
            }

        }
    }
}
