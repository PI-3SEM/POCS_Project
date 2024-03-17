using POCS_Project.controllers;
using POCS_Project.utils;
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
    public partial class CreateNewGame : Form
    {
        private readonly GameController _gameController;
        private string groupName = "Bratislava";

        public CreateNewGame()
        {
            InitializeComponent();
            _gameController = new GameController();
        }

        private void BackToMenuBtn_Click(object sender, EventArgs e)
        {
            this.ChangeScreen(new ChoosePlayMode());
        }

        private void CreateNewGameBtn_Click(object sender, EventArgs e)
        {
            try
            {
            _gameController.Create(tbxNameGame.Text, tbxPasswordGame.Text, groupName);
            this.ChangeScreen(new SelectAnExistentGame());
            }
            catch (Exception error)
            {
                ErrorsMessageLabel.Text = error.Message;
                ErrorsMessageLabel.Visible = true;
            }
        }

        private void CheckInput(object sender, EventArgs e)
        {
            if (tbxNameGame.Text.Trim().Length > 0 && groupName.Trim().Length > 0 && tbxPasswordGame.Text.Trim().Length > 0)
                CreateNewGameBtn.Enabled = true;
            else 
                CreateNewGameBtn.Enabled = false;
        }

        private void VerifyEmptyField(object sender, EventArgs e)
        {
            string message = "Informe [Field] para criar a partida";
            TextBox field = sender as TextBox;
            if (!CreateNewGameBtn.Enabled)
            {
                ErrorsMessageLabel.Visible = true;
                if(tbxNameGame.Text == null || tbxNameGame.Text == "")
                    message = message.Replace("[Field]","um nome");
                if (groupName == null || groupName == "")
                    message = message.Replace("[Field]","o nome do grupo");
                if(tbxPasswordGame.Text == null||tbxPasswordGame.Text == "")
                    message = message.Replace("[Field]","a senha");
                ErrorsMessageLabel.Text = message;
            }else
                ErrorsMessageLabel.Visible = false;
        }
    }
}
