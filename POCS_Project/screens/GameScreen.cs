using POCS_Project.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POCS_Project.screens
{
    public partial class GameScreen : Form
    {
        private List<Player> PlayersInGame { get; set; }

        public GameScreen(List<Player> players, int idInitPlayer)
        {
            InitializeComponent();
            PlayersInGame = players;
            lblPlayerTimeIndicator.Text = lblPlayerTimeIndicator.Text.Replace("[PLAYER]", $"{PlayersInGame.FirstOrDefault(x => x.Id == idInitPlayer).Name}, tendo como id {idInitPlayer}");
        }
    }
}
