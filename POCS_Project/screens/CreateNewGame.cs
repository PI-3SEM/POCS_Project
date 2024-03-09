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
            _gameController.Create(tbxNameGame.Text, tbxNameGroup.Text, tbxPasswordGame.Text);
            this.ChangeScreen(new SelectAnExistentGame());
        }

        private void CheckInput(object sender, EventArgs e)
        {
            if (tbxNameGame.Text.Trim().Length > 0 && tbxNameGroup.Text.Trim().Length > 0 && tbxPasswordGame.Text.Trim().Length > 0)
                CreateNewGameBtn.Enabled = true;
            else 
                CreateNewGameBtn.Enabled = false;
        }
    }
}
