using POCS_Project.controllers;
using POCS_Project.entities;
using POCS_Project.screens;
using POCS_Project.utils;
using System;
using System.Windows.Forms;

namespace POCS_Project
{
    public partial class SelectAnExistentGame : Form
    {
        private readonly GameController _gameController;

        public SelectAnExistentGame()
        {
            InitializeComponent();
            _gameController = new GameController();
            LoadGameList();
        }
        private void LoadGameList(GameSituation situation = GameSituation.All)
        {
            var gamesList = _gameController.Index();

            GamesTable.RowStyles[0].Height = 80;
            GamesTable.RowStyles[0].SizeType = SizeType.Absolute;

            for (int i = 0; i < gamesList.Count; i++) 
            {
                var game = gamesList[i];
                var textGame = new Label();
                var textPlayerLabel = new Label();
                
                textGame.Text = $"Id da partida: {game.Id}\nNome da Partida: {game.Name}\nStatus partida: {game.Situation.GetDisplayName()}";
                textGame.Size = new System.Drawing.Size(textGame.Size.Width, 150);
                GamesTable.RowStyles.Add(new RowStyle { Height = 80, SizeType=SizeType.Absolute });
                GamesTable.Controls.Add(textGame, 0, i);
                
                string playerText = "";
                foreach(var player in game.Players)
                {
                    playerText += $"Jogador {player.Id}: {player.Name}\nPontuação: {player.Record}\n";
                }
                textPlayerLabel.Text = playerText;
                textPlayerLabel.Size = new System.Drawing.Size(textPlayerLabel.Size.Width, textPlayerLabel.Size.Width * game.Players.Count);
                GamesTable.Controls.Add(textPlayerLabel, 1, i);

                if (game.Situation == GameSituation.Open)
                {
                    var enterInGameBtn = new Button();
                    enterInGameBtn.Text = "Entrar na Partida";
                    enterInGameBtn.Size = new System.Drawing.Size(140, enterInGameBtn.Size.Height);
                    GamesTable.Controls.Add(enterInGameBtn, 2, i);
                }
            }
        }

        private void BackToMenuBtn_Click(object sender, EventArgs e)
        {
            this.ChangeScreen(new ChoosePlayMode());
        }

        private void CreateNewGame_Btn_Click(object sender, EventArgs e)
        {
            this.ChangeScreen(new CreateNewGame());
        }
    }
}
