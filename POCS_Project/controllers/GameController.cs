using MagicTrickServer;
using POCS_Project.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCS_Project.controllers
{
    public class GameController
    {

        public List<Game> Index()
        {
            var response = new List<Game>();
                Jogo.ListarPartidas("T");
            return response;
        }
    }
}
