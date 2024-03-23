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
    public partial class GameScreen : Form
    {
        private readonly Game _gameData;
        private readonly GameController _gameController;
        private readonly Player LoggedUser;
        private Dictionary<Player, List<Card>> PlayersInGame = new Dictionary<Player, List<Card>>();
        private Dictionary<Player, TableLayoutPanel> PlayersGridCards = new Dictionary<Player, TableLayoutPanel>();

        public GameScreen(int idInitPlayer,Player loggedPlayer ,Game game)
        {
            LoggedUser = loggedPlayer;
            _gameController = new GameController();
            _gameData = game;
            
            List<Card> cards = _gameController.GetCards(_gameData.Players, _gameData.Id);
            foreach(Player player in _gameData.Players) {
                PlayersInGame.Add(player, cards.Where(x => x.Owner == player).ToList());
                PlayersGridCards.Add(player, new TableLayoutPanel { CellBorderStyle = TableLayoutPanelCellBorderStyle.Single });
            }

            InitializeComponent();
            lblPlayerTimeIndicator.Text = lblPlayerTimeIndicator.Text.Replace("[PLAYER]", $"{PlayersInGame.FirstOrDefault(x => x.Key.Id == idInitPlayer).Key.Name}, tendo como id {idInitPlayer}");
            RenderPlayersGridCards();
        }

        private void RenderCard(Player player,TableLayoutPanel grid)
        {
            List<Card> cards = PlayersInGame.FirstOrDefault(x => x.Key.Equals(player)).Value;
            int indexColumn = 0;
            int indexRow = 0;

            if (grid.Dock == DockStyle.Top || grid.Dock == DockStyle.Bottom)
            {
                grid.RowCount = 2;
                grid.ColumnCount = 6;
            }
            else
            {
                grid.RowCount = 6;
                grid.ColumnCount = 2;
            }
            
            foreach(Card card in cards)
            {
                Label provCard = new Label { 
                    Text = $"naipe: {card.Suit.GetDisplayName()}\norder:{card.Order}" ,
                    Dock = DockStyle.Fill
                };

                if (grid.Dock == DockStyle.Top || grid.Dock == DockStyle.Bottom)
                {
                    if (indexColumn >= 6)
                    {
                        indexRow = 1;
                        indexColumn = 0;
                    }
                    grid.Controls.Add(provCard, indexColumn, indexRow);
                    indexColumn++;
                }
                else
                {
                    
                    indexColumn = indexColumn == 0 ? 1 : 0;
                    if (indexColumn == 0) indexRow++;
                    grid.Controls.Add(provCard, indexColumn, indexRow);
                }
            }
        }

        private void RenderPlayersGridCards() {
            foreach(var playersGridCards in PlayersGridCards)
            {
                DockStyle[] possiblePosition = { DockStyle.Top, DockStyle.Left, DockStyle.Right };

                if (playersGridCards.Key.Id == LoggedUser.Id)
                    playersGridCards.Value.Dock = DockStyle.Bottom;
                else
                {
                    playersGridCards.Value.Dock = possiblePosition[0];
                    possiblePosition = possiblePosition.Skip(1).ToArray();
                }
                pnlGame.Controls.Add(playersGridCards.Value);
                RenderCard(playersGridCards.Key, playersGridCards.Value);
            }
        }
    }
}
