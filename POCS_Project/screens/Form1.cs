using MagicTrickServer;
using POCS_Project.utils;
using System;
using System.Windows.Forms;

namespace POCS_Project
{
    public partial class ChoosePlayMode : Form
    {
        public ChoosePlayMode()
        {
            InitializeComponent();
            lblVersion.Text = $"Versão {Jogo.Versao}";
        }

        private void MultiplayerBtn_Click(object sender, EventArgs e)
        {
            this.ChangeScreen(new SelectAnExistentGame());
        }

        private void ChoosePlayMode_Load(object sender, EventArgs e)
        {

        }
    }
}
