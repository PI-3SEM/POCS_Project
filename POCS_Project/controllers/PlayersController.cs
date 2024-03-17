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
    public class PlayersController
    {

        public List<Player> GetAllPlayers(int id)
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
