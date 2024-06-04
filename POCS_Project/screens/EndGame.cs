using POCS_Project.controllers;
using POCS_Project.entities;
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
    public partial class EndGame : Form
    {
        Game _gameData;
        PlayersController _playersController = new PlayersController();
        List <Player> Players = new List<Player>();
        public EndGame(Game game)
        {
            _gameData = game;
            InitializeComponent();
            dgRanking.DataSource = CreateRanking();
            PutDataInString();
        }

        private void PutDataInString()
        {
            Player winner = Players.First();
            lblWinner.Text = lblWinner.Text
                .Replace("%[JOGADOR]%", winner.Name)
                .Replace("%[PONTUACAO]%", winner.Score.ToString());
        }

        private List<RankingRow> CreateRanking()
        {
            List<RankingRow> response = new List<RankingRow>();
            Players = _playersController.GetPlayersInGame(_gameData.Id)
                .OrderByDescending(x=>x.Score)
                .ToList();
            foreach(Player player in Players)
            {
                response.Add(new RankingRow
                {
                    NamePlayer = player.Name,
                    Score = player.Score,
                });
            }
            return response;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.ChangeScreen(new ChoosePlayMode());
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            this.ChangeScreen(new SelectAnExistentGame());
        }
    }
}
