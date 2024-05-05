﻿using MagicTrickServer;
using Org.BouncyCastle.Crypto;
using POCS_Project.controllers;
using POCS_Project.entities;
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
        private int IdInitPlayer;
        private bool IsAutonomousMode = false;
        private bool IsYourTime = false;
        private readonly Game _gameData;
        private readonly GameController _gameController = new GameController();
        private readonly LogicController _logicController = new LogicController();
        private readonly Player LoggedUser;
        private Dictionary<Player, List<Card>> PlayersInGame = new Dictionary<Player, List<Card>>();
        private Dictionary<Player, TableLayoutPanel> PlayersGridCards = new Dictionary<Player, TableLayoutPanel>();
        private Dictionary<Player, int> PlayersScore = new Dictionary<Player, int>();
        private List<Card> PlayedCards = new List<Card>();
        private CardStyle CardStyle = new CardStyle();

        public GameScreen(Player loggedPlayer ,Game game, bool isAutonomousMode)
        {
            InitializeComponent();
            LoggedUser = loggedPlayer;
            IsAutonomousMode = isAutonomousMode;
            lblVersionOnGame.Text = Jogo.Versao; 
            int indexLoggedUser = game.Players.FindIndex(x => x.Id == loggedPlayer.Id);
            game.Players[indexLoggedUser] = loggedPlayer;
            _gameData = game;

            DistributeCards();
            VerifyTime();
            RenderPlayersGridCards();
        }
        
        private void DistributeCards()
        {
            PlayersInGame.Clear();
            PlayersGridCards.Clear();
            List<Card> cards = _gameController.GetCards(_gameData.Players, _gameData.Id);
            foreach (Player player in _gameData.Players)
            {
                PlayersInGame.Add(player, cards.Where(x => x.Owner == player).ToList());
                PlayersGridCards.Add(player, new TableLayoutPanel { CellBorderStyle = TableLayoutPanelCellBorderStyle.Single });
            }
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

            foreach (Card card in cards)
            {

                Panel pbCard = new Panel();
                {
                    BackgroundImageLayout = ImageLayout.Center;
                };
                pbCard.MaximumSize = new Size(CardStyle.x, CardStyle.y + 5);


                if (card.WasUsed)
                {
                    pbCard.BackgroundImage = base.BackgroundImage;
                }
                else
                {
                    string item = CardStyle.pathsNotPlayed.FirstOrDefault(x => x.Contains(card.Suit.GetDisplayName()));
                    pbCard.BackgroundImage = Image.FromFile(item);
                }


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

            foreach (RowStyle row in grid.RowStyles)
            {
                row.SizeType = SizeType.Absolute;
                row.Height = CardStyle.y;
            }
        }

        private void VerifyTime()
        {
            bool response = false;
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
                VerifyRounds();
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

            IsYourTime = response;
        }

        private void VerifyRounds()
        {
            var winners = _gameController.GetWinners(_gameData.Id, PlayersInGame.Keys.ToList());
            string winnersLayoutStr = "%[PLAYERNAME]% - %[ROUNDSWON]%";
            string textWinners= "";
            foreach(var winner in winners)
            {
                textWinners+= winnersLayoutStr
                        .Replace("%[PLAYERNAME]%",winner.Key.Name)
                        .Replace("%[ROUNDSWON]%", winner.Value.ToString()) + "\n";
            }
            tbxDisplayRounds.Text = textWinners;
        }

        private void RenderSendedCards(object sender, EventArgs e)
        {
            VerifyTime();
            if(PlayedCards.Count > 0)
            {
                Card cardData = PlayedCards.Last();
                Image cardImage = Image.FromFile(CardStyle.pathsPlayed.FirstOrDefault(x => x.Contains(cardData.Suit.GetDisplayName())));
                ModifyCardImageInsertValue(ref cardImage, cardData);
                pbPlayedCard.Image = cardImage; 
            }
            if (IsAutonomousMode)
            {
                if(IsYourTime)
                    AutonomousSystemPlay(sender, e);
                if (!PlayersInGame.Any(x => x.Value.Any(y => !y.WasUsed)))
                    EndPlay();
            }
        }

        private void AutonomousSystemPlay(object sender, EventArgs e)
        {
            List<Card> myCards = PlayersInGame[LoggedUser].Where(x=>!x.WasUsed).ToList();
            Card cardToPlay;
            int cardToPlayIndex = 0;

            Dictionary<string, int[]> lol = _logicController.FirstStep(myCards);

            if (PlayedCards.Count > 0)
                cardToPlayIndex = myCards.FindIndex(x=>x.Order == _logicController.AfterThem(PlayedCards, myCards));
            else
                cardToPlayIndex = myCards.FindIndex(x => x.Order == _logicController.FirstPlay(myCards));

            cardToPlay = myCards[cardToPlayIndex];
            try
            {
                SendCard(cardToPlay);
                btnProvBet0_Click(sender, e);
                IsYourTime = false;
            }
            catch(Exception error)
            {
                lblPlayerTimeIndicator.Text = error.Message;
                if (myCards.Count == 1)
                {
                    PlayersInGame[LoggedUser][cardToPlayIndex].Value = Convert.ToInt32(Jogo.Apostar(LoggedUser.Id, LoggedUser.Password, cardToPlay.Order));
                    lblPlayerTimeIndicator.Text = $"Foi realizado a aposta, a aposta foi vencer {PlayersInGame[LoggedUser][cardToPlayIndex].Value} partidas!";
                }
            }
        }

        private void EndPlay()
        {
            
        }

        private void SendCard(object sender, EventArgs e)
        {   
            Panel clickedCard = sender as Panel;
            string[] cardData = Regex.Split(clickedCard.Name, ",");
            int cardId = Convert.ToInt32(cardData[0]);
            int ownerId = Convert.ToInt32(cardData[1]);
            try
            {
                if (IsYourTime) {
                    Player keyLogged = PlayersInGame.Keys.FirstOrDefault(x => x.Id == LoggedUser.Id);
                    string playResult = Jogo.Jogar(ownerId, LoggedUser.Password, cardId);
                    int cardValue = Convert.ToInt32(playResult);
                    int indexCard = PlayersInGame[keyLogged].FindIndex(x=>x.Order == cardId);
                    PlayersInGame[keyLogged][indexCard].Value = cardValue;
                    PlayersInGame[LoggedUser][indexCard].WasUsed = true;
                    RenderPlayersGridCards();
                }
            }
            catch(Exception error)
            {
                lblPlayerTimeIndicator.Text = error.Message;
            }
        }

        private void SendCard(Card cardToPlay)
        {
            if (IsYourTime)
            {
                string playResult = Jogo.Jogar(cardToPlay.Owner.Id, LoggedUser.Password, cardToPlay.Order);
                int cardValue = Convert.ToInt32(playResult);
                int indexCard = PlayersInGame[LoggedUser].FindIndex(x => x.Order == cardToPlay.Order);
                PlayersInGame[LoggedUser][indexCard].Value = cardValue;
                PlayersInGame[LoggedUser][indexCard].WasUsed = true;
                RenderPlayersGridCards();
            }
        }

        private void ModifyCardImageInsertValue(ref Image cardImage, Card cardData)
        {
            var grafic = Graphics.FromImage(cardImage);
            grafic.DrawString(
                Convert.ToString(cardData.Value),
                new Font("arial", 10F, FontStyle.Regular),
                Brushes.Black,
                new PointF(10, 5)
            );
            grafic.DrawString(
                Convert.ToString(cardData.Value),
                new Font("arial", 10F, FontStyle.Regular),
                Brushes.Black,
                new PointF(cardImage.Width - 10, 5)
            );
            grafic.Dispose();
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
                playersGridCards.Value.Height = CardStyle.y*2-40;
                pnlGame.Controls.Add(playersGridCards.Value);
                RenderCard(playersGridCards.Key, playersGridCards.Value);
            }
        }

        private void btnProvBet0_Click(object sender, EventArgs e)
        {
            Jogo.Apostar(LoggedUser.Id, LoggedUser.Password, 0);
            VerifyTime();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            var MyTimer = new Timer
            {
                Interval = 5000,
                Enabled = true
            };
            MyTimer.Tick += new EventHandler(RenderSendedCards);
            MyTimer.Start();
        }

        private void GameScreen_SizeChanged(object sender, EventArgs e)
        {
            pbPlayedCard.Location = new Point((pnlGame.Width / 2 - CardStyle.x / 2), (pnlGame.Height / 2 - CardStyle.y / 2));
        }
    }
}
