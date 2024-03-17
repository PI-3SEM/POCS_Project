using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POCS_Project.controllers;
using POCS_Project.entities;
using POCS_Project.utils;

namespace POCS_Project.screens
{
    public partial class LoginGame : Form
    {
        private readonly Game _gameData;

        private readonly GameController _gameController;

        private readonly PlayersController _playersController;

        private Player LoggedPlayer { get; set; }

        public LoginGame(Game gameData)
        {
            _gameData = gameData;
            _playersController = new PlayersController();
            _gameController = new GameController();
            InitializeComponent();
            loadGameData(_gameData);
        }

        private void loadGameData(Game data)
        {

            lblGameId.Text = $"Id da Partida: {Convert.ToString(data.Id)}";
            lblGameName.Text = $"Nome da Partida: {data.Name}";
            lblGameStatus.Text = $"Status da Partida: {Convert.ToString(data.Situation)}";

            string PlayerText = "";
            foreach (var player in data.Players)
            {
                PlayerText += $"Jogador {player.Id}: {player.Name}\n";
            }
            lblPlayer.Text = PlayerText;
            lblPlayer.Size = new System.Drawing.Size(lblPlayer.Size.Width, lblPlayer.Size.Width * data.Players.Count);
        }

        private void btnBackToListGames_Click(object sender, EventArgs e)
        {
            this.ChangeScreen(new SelectAnExistentGame());
        }

        private void CheckInput(object sender, EventArgs e)
        {
            if (tbxPasswordGame.Text.Trim().Length > 0 && tbxPlayerName.Text.Trim().Length > 0)
                btnEnterInGame.Enabled = true;
            else
                btnEnterInGame.Enabled = false;
        }

        private void VerifyEmptyFields(object sender, EventArgs e)
        {
            string message = "Informe [Field] para entrar na partida";
            TextBox field = sender as TextBox;
            if (!btnEnterInGame.Enabled)
            {
                ErrorsMessageLabel.Visible = true;
                if (tbxPlayerName.Text == null || tbxPlayerName.Text == "")
                    message = message.Replace("[Field]", "um nome");
                if (tbxPasswordGame.Text == null || tbxPasswordGame.Text == "")
                    message = message.Replace("[Field]", "a senha");
                ErrorsMessageLabel.Text = message;
            }
            else
                ErrorsMessageLabel.Visible = false;
        }

        private void btnEnterInGame_Click(object sender, EventArgs e)
        {
            try
            {
                LoggedPlayer = _playersController.EnterInGame(tbxPlayerName.Text, tbxPasswordGame.Text,_gameData.Id);
                _gameData.Players = _playersController.GetAllPlayers(_gameData.Id);
                loadGameData(_gameData);
                tbxPlayerName.Enabled = false;
                tbxPasswordGame.Enabled = false;
                btnEnterInGame.Enabled = false;
                btnInitGame.Enabled = true;
            }
            catch(Exception error)
            {
                ErrorsMessageLabel.Text = error.Message;
            }
        }

        private void btnInitGame_Click(object sender, EventArgs e)
        {
            try
            {
                var idInitPlayer = _gameController.initGame(LoggedPlayer.Id, LoggedPlayer.Password);
                var gameScreen = new GameScreen(_gameData.Players, idInitPlayer);
                this.ChangeScreen(gameScreen);
            }
            catch(Exception error)
            {
                ErrorsMessageLabel.Text = error.Message;
            }
        }
    }
}
