using MagicTrickServer;
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
        private Player WhoPlay;
        private bool IsAutonomousMode = false;
        private bool IsYourTime = false;
        private int CurrentRound = 1;
        private Game _gameData;
        private readonly GameController _gameController = new GameController();
        private readonly LogicController _logicController = new LogicController();
        private readonly ImageController _imageController = new ImageController();
        private readonly Player LoggedUser;
        private Dictionary<Player, List<Card>> PlayersInGame = new Dictionary<Player, List<Card>>();
        private Dictionary<Player, TableLayoutPanel> PlayersGridCards = new Dictionary<Player, TableLayoutPanel>();
        private Dictionary<Player, int> PlayersScoreRounds = new Dictionary<Player, int>();
        private Dictionary<Player, int> PlayersScoreGame = new Dictionary<Player, int>();
        private Dictionary<Player, int> PlayersBet = new Dictionary<Player, int>();
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
            List<Card> cards = _gameController.GetCards(_gameData.Players, _gameData.Id);
            foreach (Player player in _gameData.Players)
            {
                PlayersInGame.Add(player, cards.Where(x => x.Owner == player).ToList());
                PlayersGridCards.Add(player, new TableLayoutPanel { CellBorderStyle = TableLayoutPanelCellBorderStyle.Single });
                if (PlayersBet.Count < PlayersInGame.Count)
                {
                    PlayersBet.Add(player, 0);
                    PlayersScoreGame.Add(player, 0);
                }
            }
        }
        
        private void RenderCard(Player player,TableLayoutPanel grid)
        {
            grid.Controls.Clear();
            grid.RowCount = 0;
            grid.ColumnCount = 0;

            List<Card> cards = PlayersInGame[player];
            int indexColumn = 0;
            int indexRow = 0;

            bool isTopOrBottom = grid.Dock == DockStyle.Top || grid.Dock == DockStyle.Bottom;
            grid.RowCount = isTopOrBottom ? 2: cards.Count / 2;
            grid.ColumnCount = isTopOrBottom ? cards.Count / 2 : 2;


            /*Verificação se a carta foi usada*/
            for(int i = 0; i < cards.Count; i++)
                if (PlayedCards.Where(x => x.Owner == player).Any(x => x.Order == PlayersInGame[player][i].Order))
                    PlayersInGame[player][i].WasUsed = true;
            
            cards = PlayersInGame[player];
            foreach (Card card in cards)
            {

                Panel pbCard = new Panel
                {
                    BackgroundImageLayout = ImageLayout.Center,
                    MaximumSize = new Size(CardStyle.x, CardStyle.y + 5)
                };
                List<string> pathImage = !card.WasUsed?CardStyle.pathsNotPlayed:CardStyle.pathsPlayed;
                Image image = Image.FromFile(pathImage.FirstOrDefault(x => x.Contains(card.Suit.GetDisplayName())));

                if (card.WasUsed)
                {
                    _imageController.TurnImageBlackAndWhite(ref image);
                    _imageController.ModifyCardImageInsertValue(ref image, card);
                }
                pbCard.BackgroundImage = image;
                
                /* Feature da proposta inicial de poder jogar sem modo autônomo */
                if(player.Id == LoggedUser.Id)
                {
                    pbCard.Click += SendCard;
                    pbCard.Cursor = Cursors.Hand;
                    pbCard.Name = $"{card.Order},{card.Owner.Id}";
                }

                if (isTopOrBottom)
                {
                    if (indexColumn >= cards.Count/2)
                    {
                        indexRow = 2;
                        indexColumn = 0;
                    }
                    grid.Controls.Add(pbCard, indexColumn++, indexRow);
                }
                else
                {
                    if (indexColumn == 0) indexRow++;
                    grid.Controls.Add(pbCard, (indexColumn++ % 2) - 1, indexRow);
                }
            }

            foreach (RowStyle row in grid.RowStyles)
            {
                row.SizeType = SizeType.Absolute;
                row.Height = CardStyle.y + 15;
            }
            foreach (ColumnStyle col in grid.ColumnStyles)
            {
                col.SizeType = SizeType.Absolute;
                col.Width = CardStyle.x + 15;
            }
        }

        private void VerifyTime()
        {
            bool response = false;
            string[] gameStrStatus = _gameController.GetGameStatus(_gameData.Id, ref _gameData, ref WhoPlay, ref CurrentRound);
            
            /* definição de vez */
            if (WhoPlay != null && _gameData.Situation != GameSituation.Closed)
            {
                response = WhoPlay.Id == LoggedUser.Id;
                lblPlayerTimeIndicator.Text = response? "É a sua vez!" : $"É a vez de {WhoPlay.Name}";
            }

            /* Verificação de apostas */
            if (gameStrStatus.Any(x => x.StartsWith("A:")))
                _gameController.GetBet(_gameData.Id, ref PlayersBet);

            /* Separação das cartas jogadas */
            if (gameStrStatus.Count() > 1)
            {
                VerifyRounds();
                PlayedCards = _gameController.GetPlayedCards(_gameData.Id, PlayersInGame.Keys.ToList());
            }

            IsYourTime = response;
        }

        private void VerifyRounds()
        {
            PlayersScoreRounds = _gameController.GetWinners(_gameData.Id, PlayersInGame.Keys.ToList());
            string scoreStr = "",
                   roundsStr = "",
                   scorePlayerLayoutStr = "    %[PLAYERNAME]%: %[SCOREPLAYER]%",
                   winnersRoundsLayoutStr = "    %[PLAYERNAME]%: %[ROUNDSWON]%",
                   textDisplay= "Score:\n%[SCORE]%\nRounds:\n%[ROUNDS]%"
            ;

            foreach(var score in PlayersScoreGame)
            {
                scoreStr += scorePlayerLayoutStr
                        .Replace("%[PLAYERNAME]%", score.Key.Name)
                        .Replace("%[SCOREPLAYER]%", score.Value.ToString()) + "\n";
            }

            foreach(var winnerRound in PlayersScoreRounds)
            {
                roundsStr += winnersRoundsLayoutStr
                        .Replace("%[PLAYERNAME]%",winnerRound.Key.Name)
                        .Replace("%[ROUNDSWON]%", winnerRound.Value.ToString()) + "\n";
            }
            
            textDisplay = textDisplay.Replace("%[ROUNDS]%", roundsStr);
            textDisplay = textDisplay.Replace("%[SCORE]%", scoreStr);

            tbxDisplayRounds.Text = textDisplay;
        }

        private void RenderSendedCards(object sender, EventArgs e)
        {
            VerifyTime();
            if (IsAutonomousMode)
            {
                if (PlayersInGame[LoggedUser].Where(x => !x.WasUsed).ToList().Count == 0)
                    VerifyEndPlay();

                if (IsYourTime)
                    AutonomousSystemPlay(sender, e);   
            }

            if (PlayedCards.Count > 0)
            {
                Card cardData = PlayedCards.Last();
                Image cardImage = Image.FromFile(CardStyle.pathsPlayed.FirstOrDefault(x => x.Contains(cardData.Suit.GetDisplayName())));
                _imageController.ModifyCardImageInsertValue(ref cardImage, cardData);
                pbPlayedCard.Image = cardImage;
            }
        }

        private void AutonomousSystemPlay(object sender, EventArgs e)
        {
            List<Card> myCards = PlayersInGame[LoggedUser].Where(x=>!x.WasUsed).ToList();
            if (myCards.Count == 0)
            {
                VerifyEndPlay();
                return;
            }
            Card cardToPlay;
            int cardToPlayIndex = 0;

            Dictionary<string, int[]> lol = _logicController.FirstStep(myCards);

            if (PlayedCards.Count > 0)
                cardToPlayIndex = myCards.FindIndex(x=>x.Order == _logicController.AfterThem(PlayedCards, myCards, CurrentRound));
            else
                cardToPlayIndex = myCards.FindIndex(x => x.Order == _logicController.FirstPlay(myCards));

            cardToPlay = myCards[cardToPlayIndex];
            try
            {
                if (myCards.Count == 1)
                {
                    string valueCard = Jogo.Apostar(LoggedUser.Id, LoggedUser.Password, cardToPlay.Order);
                    if (valueCard.ToLower().Contains("momento da aposta"))
                        throw new Exception("jogue uma carta");
                    cardToPlayIndex = PlayersInGame[LoggedUser].FindIndex(x => x.Order == cardToPlay.Order);
                    PlayersInGame[LoggedUser][cardToPlayIndex].Value = Convert.ToInt32(valueCard);
                    PlayersInGame[LoggedUser][cardToPlayIndex].WasUsed = true;
                    lblPlayerTimeIndicator.Text = $"Foi realizado a aposta, a aposta foi vencer {PlayersInGame[LoggedUser][cardToPlayIndex].Value} partidas!";
                }
                else
                {
                    SendCard(cardToPlay);
                    Jogo.Apostar(LoggedUser.Id, LoggedUser.Password, 0);
                }
                IsYourTime = false;
            }
            catch(Exception error)
            {
                if(error.Message == "jogue uma carta")
                {
                    SendCard(cardToPlay);
                    Jogo.Apostar(LoggedUser.Id, LoggedUser.Password, 0);
                }
                lblPlayerTimeIndicator.Text = error.Message;
            }
        }

        private void CalculateScore()
        {
            if(PlayersScoreRounds.Count == _gameData.Players.Count)
            foreach(var bet in PlayersBet)
            {
                int roundsWon = PlayersScoreRounds[bet.Key];
                if (bet.Value == roundsWon)
                    PlayersScoreGame[bet.Key] += 3;
                else if (bet.Value > roundsWon)
                    PlayersScoreGame[bet.Key] += roundsWon - bet.Value;
                else
                    PlayersScoreGame[bet.Key] -= roundsWon - bet.Value;
            }
        }

        private void VerifyEndPlay()
        {
            CalculateScore();
            VerifyTime();
            List<Card> cards = _gameController.GetCards(_gameData.Players, _gameData.Id);
            List<Player> players = PlayersInGame.Keys.ToList();

            // Atualiza as cartas lógicamente
            foreach (var player in players)
                PlayersInGame[player] = cards.Where(x => x.Owner.Id == player.Id).ToList();
            // Atualiza as cartas visualmente
            foreach (var player in PlayersGridCards)
                RenderCard(player.Key,player.Value);
            
            if(_gameData.Situation == GameSituation.Closed)
                this.ChangeScreen(new SelectAnExistentGame());
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
                foreach(var player in PlayersGridCards)
                    RenderCard(player.Key, player.Value);
            }
        }

        private void RenderPlayersGridCards() {
            DockStyle[] possiblePosition = { DockStyle.Top, DockStyle.Left, DockStyle.Right };
            foreach(var playersGridCards in PlayersGridCards)
            {
                if (playersGridCards.Key.Id == LoggedUser.Id)
                    playersGridCards.Value.Dock = DockStyle.Bottom;
                else
                {
                    playersGridCards.Value.Dock = possiblePosition[0];
                    possiblePosition = possiblePosition.Skip(1).ToArray();
                }
                if (playersGridCards.Value.Dock == DockStyle.Top || playersGridCards.Value.Dock == DockStyle.Bottom)
                    playersGridCards.Value.Height = CardStyle.y * 2 + 30;
                else
                    playersGridCards.Value.Width = CardStyle.x * 2 + 30;
            }
            /* ordenação da renderização */
            foreach(var playersGridCards in PlayersGridCards.OrderBy(x=>x.Value.Dock))
            {
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
            GameScreen_SizeChanged(sender, e);
        }

        private void GameScreen_SizeChanged(object sender, EventArgs e)
        {
            pbPlayedCard.Location = new Point((pnlGame.Width / 2 - CardStyle.x / 2), (pnlGame.Height / 2 - CardStyle.y / 2));
        }
    }
}
