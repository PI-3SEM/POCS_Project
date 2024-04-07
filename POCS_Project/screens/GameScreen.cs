﻿using MagicTrickServer;
using Org.BouncyCastle.Crypto;
using POCS_Project.controllers;
using POCS_Project.entities;
using POCS_Project.screens.Component;
using POCS_Project.utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private CardStyle cardStyle = new CardStyle();

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
            
            foreach (RowStyle row in grid.RowStyles)
            {
                row.Height = cardStyle.y;
            }

            foreach (Card card in cards)
            {

                Panel pbCard = new Panel();
                {
                    BackgroundImageLayout = ImageLayout.Center;
                };
                pbCard.MaximumSize = new Size(cardStyle.x, cardStyle.y);

                string item = cardStyle.pathsNotPlayed.FirstOrDefault(x => x.Contains(card.Suit.GetDisplayName()));
                pbCard.BackgroundImage = Image.FromFile(item);


                if(player.Id == LoggedUser.Id)
                {
                    pbCard.Click += SendCard;
                    pbCard.Cursor = Cursors.Hand;
                    pbCard.Name = $"{card.Order},{card.Owner.Id}";
                }

                if (grid.Dock == DockStyle.Top || grid.Dock == DockStyle.Bottom)
                {
                    if (indexColumn >= 6)
                    {
                        indexRow = 2;
                        indexColumn = 0;
                    }
                    grid.Controls.Add(pbCard, indexColumn, indexRow);
                    indexColumn++;
                }
                else
                {
                    
                    indexColumn = indexColumn == 0 ? 2 : 0;
                    if (indexColumn == 0) indexRow++;
                    grid.Controls.Add(pbCard, indexColumn, indexRow);
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
            
            /* definição de vez */
            if (gameData.Length > 0)
            {
                if (IdInitPlayer == LoggedUser.Id)
                {
                    response = true;
                    lblPlayerTimeIndicator.Text = "É a sua vez!";
                }
                else
                    lblPlayerTimeIndicator.Text = $"É a vez de {PlayersInGame.FirstOrDefault(x => x.Key.Id == Convert.ToInt32(gameData[1])).Key.Name}";
                
            }

            /* Separação das cartas jogadas */
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

        private void RenderSendedCards(object sender, EventArgs e)
        {
            VerifyTime();
            foreach (Card playedCard in PlayedCards)
            {
                PictureBox pictureBox;
                DockStyle positionOnTable = PlayersGridCards[playedCard.Owner].Dock;

                switch(positionOnTable)
                {
                    case DockStyle.Left:
                        pictureBox = new RotatedCard(playedCard);
                        break;
                    case DockStyle.Right:
                        pictureBox = new RotatedCard(playedCard);
                        break;
                    default:  
                        pictureBox = new PictureBox();
                        break;
                }
                
                pictureBox.Location = new Point((pnlGame.Width / 2) - (cardStyle.x/2), (pnlGame.Height / 2) - (cardStyle.y / 2));
                pictureBox.Image = Image.FromFile(cardStyle.pathsPlayed.FirstOrDefault(x => x.Contains(playedCard.Suit.GetDisplayName())));
                pictureBox.Size = new Size(cardStyle.x,cardStyle.y);
                pnlGame.Controls.Add(pictureBox);
            };
        }

        private void SendCard(object sender, EventArgs e)
        {   
            Panel clickedCard = sender as Panel;
            string[] cardData = Regex.Split(clickedCard.Name, ",");
            int cardId = Convert.ToInt32(cardData[0]);
            int ownerId = Convert.ToInt32(cardData[1]);
            try
            {
                if (VerifyTime()) {
                    Player keyLogged = PlayersInGame.Keys.FirstOrDefault(x => x.Id == LoggedUser.Id);
                    string playResult = Jogo.Jogar(ownerId, LoggedUser.Password, cardId);
                    int cardValue = Convert.ToInt32(playResult);
                    int indexCard = PlayersInGame[keyLogged].FindIndex(x=>x.Order == cardId);
                    PlayersInGame[keyLogged][indexCard].Value = cardValue;
                    //lblPlayerTimeIndicator.Text = $"Você jogou uma carta com valor {cardId}";
                }
            }
            catch
            {
                lblPlayerTimeIndicator.Text = $"Não é a sua vez!!";
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

        private void btnProvBet0_Click(object sender, EventArgs e)
        {
            Jogo.Apostar(LoggedUser.Id, LoggedUser.Password, 0);
            VerifyTime();
            RenderSendedCards(sender, e);
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            Timer MyTimer = new Timer();
            MyTimer.Interval = (2000);
            MyTimer.Tick += new EventHandler(RenderSendedCards);
            MyTimer.Enabled = true;
            MyTimer.Start();
        }
    }
}
