using MagicTrickServer;
using Org.BouncyCastle.Crypto;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POCS_Project.screens
{
    public partial class GameScreen : Form
    {
        private readonly Game _gameData;
        private readonly GameController _gameController;
        private readonly Player LoggedUser;
        private int IdInitPlayer;
        private Dictionary<Player, List<Card>> PlayersInGame = new Dictionary<Player, List<Card>>();
        private Dictionary<Player, TableLayoutPanel> PlayersGridCards = new Dictionary<Player, TableLayoutPanel>();
        private List<Card> PlayedCards = new List<Card>();

        public GameScreen(Player loggedPlayer ,Game game)
        {
            InitializeComponent();
            LoggedUser = loggedPlayer;
            _gameController = new GameController();
            _gameData = game;
            
            List<Card> cards = _gameController.GetCards(_gameData.Players, _gameData.Id);
            foreach(Player player in _gameData.Players) {
                PlayersInGame.Add(player, cards.Where(x => x.Owner == player).ToList());
                PlayersGridCards.Add(player, new TableLayoutPanel { CellBorderStyle = TableLayoutPanelCellBorderStyle.Single });
            }
            VerifyTime();
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
                    Dock = DockStyle.Fill,
                };
                // if(player == LoggedUser)
                //{
                    provCard.Click += SendCard;
                    provCard.Cursor = Cursors.Hand;
                    provCard.Name = $"{card.Order},{card.Owner.Id}";
                //}

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

        private bool VerifyTime()
        {
            bool response = true;
            string strVerifyTime = Jogo.VerificarVez(_gameData.Id);
            string[] dataVerifyTime = Regex.Split(strVerifyTime, "\r\n");
            Array.Resize(ref dataVerifyTime, dataVerifyTime.Length - 1);
            string[] gameData = Regex.Split(dataVerifyTime[0], ",");
            IdInitPlayer = Convert.ToInt32(gameData[1]);

            if (gameData.Length > 0)
            {
                if (IdInitPlayer == LoggedUser.Id)
                {
                    response = true;
                    lblPlayerTimeIndicator.Text = $"É a vez de {PlayersInGame.FirstOrDefault(x => x.Key.Id == Convert.ToInt32(gameData[1])).Key.Name}, tendo como id {Convert.ToInt32(gameData[1])}";
                }
                else
                    lblPlayerTimeIndicator.Text = "É a sua vez!";
                
            }

            
            if (dataVerifyTime.Count() > 1)
            {
                dataVerifyTime = dataVerifyTime.Skip(1).ToArray();
                List<Card> playedCards = new List<Card>();
                foreach(string cardData in dataVerifyTime)
                {
                    var data = Regex.Split(cardData.Substring(2),",");
                    playedCards.Add(new Card
                    {
                        Owner = PlayersInGame.FirstOrDefault(x => x.Key.Id == Convert.ToInt32(data[0])).Key,
                        Suit = (Suits)data[1][0],
                        Value = Convert.ToInt32(data[2])
                    });
                }
                PlayedCards = playedCards;
            }

            return response;
        }

        private void SendCard(object sender, EventArgs e)
        {   
            Label clickedCard = sender as Label;
            string[] cardData = Regex.Split(clickedCard.Name, ",");
            int cardId = Convert.ToInt32(cardData[0]);
            int ownerId = Convert.ToInt32(cardData[1]);
            if (VerifyTime()) {
                Player keyLogged = PlayersInGame.Keys.FirstOrDefault(x => x.Id == LoggedUser.Id);
                string playResult = Jogo.Jogar(ownerId, LoggedUser.Password, cardId);
                int cardValue = Convert.ToInt32(playResult);
                int indexCard = PlayersInGame[keyLogged].FindIndex(x=>x.Order == cardId);
                PlayersInGame[keyLogged][indexCard].Value = cardValue;
                lblPlayerTimeIndicator.Text = $"Você jogou uma carta com valor {cardId}";
            };
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

        private void btnProvBet0_Click(object sender, EventArgs e)
        {
            Jogo.Apostar(LoggedUser.Id, LoggedUser.Password, 0);
            VerifyTime();
        }
    }
}
