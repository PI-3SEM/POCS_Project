namespace POCS_Project.screens
{
    partial class LoginGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlGameInfo = new System.Windows.Forms.Panel();
            this.lblGameStatus = new System.Windows.Forms.Label();
            this.lblGameName = new System.Windows.Forms.Label();
            this.lblGameId = new System.Windows.Forms.Label();
            this.btnBackToListGames = new System.Windows.Forms.Button();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlInputToLogin = new System.Windows.Forms.Panel();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.lblPasswordGame = new System.Windows.Forms.Label();
            this.tbxPlayerName = new System.Windows.Forms.TextBox();
            this.tbxPasswordGame = new System.Windows.Forms.TextBox();
            this.pnlGameInfo.SuspendLayout();
            this.pnlInputToLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGameInfo
            // 
            this.pnlGameInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlGameInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlGameInfo.Controls.Add(this.lblPlayer);
            this.pnlGameInfo.Controls.Add(this.lblGameStatus);
            this.pnlGameInfo.Controls.Add(this.lblGameName);
            this.pnlGameInfo.Controls.Add(this.lblGameId);
            this.pnlGameInfo.Location = new System.Drawing.Point(26, 27);
            this.pnlGameInfo.Name = "pnlGameInfo";
            this.pnlGameInfo.Size = new System.Drawing.Size(340, 336);
            this.pnlGameInfo.TabIndex = 0;
            // 
            // lblGameStatus
            // 
            this.lblGameStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGameStatus.AutoSize = true;
            this.lblGameStatus.Location = new System.Drawing.Point(36, 89);
            this.lblGameStatus.Name = "lblGameStatus";
            this.lblGameStatus.Size = new System.Drawing.Size(0, 13);
            this.lblGameStatus.TabIndex = 3;
            // 
            // lblGameName
            // 
            this.lblGameName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGameName.AutoSize = true;
            this.lblGameName.Location = new System.Drawing.Point(36, 55);
            this.lblGameName.Name = "lblGameName";
            this.lblGameName.Size = new System.Drawing.Size(0, 13);
            this.lblGameName.TabIndex = 2;
            // 
            // lblGameId
            // 
            this.lblGameId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGameId.AutoSize = true;
            this.lblGameId.Location = new System.Drawing.Point(36, 22);
            this.lblGameId.Name = "lblGameId";
            this.lblGameId.Size = new System.Drawing.Size(0, 13);
            this.lblGameId.TabIndex = 1;
            // 
            // btnBackToListGames
            // 
            this.btnBackToListGames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBackToListGames.Location = new System.Drawing.Point(26, 425);
            this.btnBackToListGames.Name = "btnBackToListGames";
            this.btnBackToListGames.Size = new System.Drawing.Size(58, 30);
            this.btnBackToListGames.TabIndex = 1;
            this.btnBackToListGames.Text = "Voltar";
            this.btnBackToListGames.UseVisualStyleBackColor = true;
            this.btnBackToListGames.Click += new System.EventHandler(this.btnBackToListGames_Click);
            // 
            // lblPlayer
            // 
            this.lblPlayer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Location = new System.Drawing.Point(36, 154);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(0, 13);
            this.lblPlayer.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(30, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Entrar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pnlInputToLogin
            // 
            this.pnlInputToLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInputToLogin.Controls.Add(this.tbxPasswordGame);
            this.pnlInputToLogin.Controls.Add(this.button1);
            this.pnlInputToLogin.Controls.Add(this.tbxPlayerName);
            this.pnlInputToLogin.Controls.Add(this.lblPasswordGame);
            this.pnlInputToLogin.Controls.Add(this.lblPlayerName);
            this.pnlInputToLogin.Location = new System.Drawing.Point(434, 27);
            this.pnlInputToLogin.Name = "pnlInputToLogin";
            this.pnlInputToLogin.Size = new System.Drawing.Size(303, 335);
            this.pnlInputToLogin.TabIndex = 3;
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Location = new System.Drawing.Point(27, 22);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(88, 13);
            this.lblPlayerName.TabIndex = 0;
            this.lblPlayerName.Text = "Nome do jogador";
            // 
            // lblPasswordGame
            // 
            this.lblPasswordGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPasswordGame.AutoSize = true;
            this.lblPasswordGame.Location = new System.Drawing.Point(27, 80);
            this.lblPasswordGame.Name = "lblPasswordGame";
            this.lblPasswordGame.Size = new System.Drawing.Size(88, 13);
            this.lblPasswordGame.TabIndex = 1;
            this.lblPasswordGame.Text = "Senha da partida";
            // 
            // tbxPlayerName
            // 
            this.tbxPlayerName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbxPlayerName.Location = new System.Drawing.Point(30, 38);
            this.tbxPlayerName.Name = "tbxPlayerName";
            this.tbxPlayerName.Size = new System.Drawing.Size(113, 20);
            this.tbxPlayerName.TabIndex = 2;
            // 
            // tbxPasswordGame
            // 
            this.tbxPasswordGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbxPasswordGame.Location = new System.Drawing.Point(30, 96);
            this.tbxPasswordGame.Name = "tbxPasswordGame";
            this.tbxPasswordGame.Size = new System.Drawing.Size(113, 20);
            this.tbxPasswordGame.TabIndex = 3;
            // 
            // LoginGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 491);
            this.Controls.Add(this.pnlInputToLogin);
            this.Controls.Add(this.btnBackToListGames);
            this.Controls.Add(this.pnlGameInfo);
            this.MinimumSize = new System.Drawing.Size(770, 530);
            this.Name = "LoginGame";
            this.Text = "LoginGame";
            this.pnlGameInfo.ResumeLayout(false);
            this.pnlGameInfo.PerformLayout();
            this.pnlInputToLogin.ResumeLayout(false);
            this.pnlInputToLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGameInfo;
        private System.Windows.Forms.Label lblGameStatus;
        private System.Windows.Forms.Label lblGameName;
        private System.Windows.Forms.Label lblGameId;
        private System.Windows.Forms.Button btnBackToListGames;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlInputToLogin;
        private System.Windows.Forms.TextBox tbxPasswordGame;
        private System.Windows.Forms.TextBox tbxPlayerName;
        private System.Windows.Forms.Label lblPasswordGame;
        private System.Windows.Forms.Label lblPlayerName;
    }
}