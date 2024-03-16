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
            this.lblPlayer = new System.Windows.Forms.Label();
            this.lblGameStatus = new System.Windows.Forms.Label();
            this.lblGameName = new System.Windows.Forms.Label();
            this.lblGameId = new System.Windows.Forms.Label();
            this.btnBackToListGames = new System.Windows.Forms.Button();
            this.btnEnterInGame = new System.Windows.Forms.Button();
            this.pnlInputToLogin = new System.Windows.Forms.Panel();
            this.tbxPasswordGame = new System.Windows.Forms.TextBox();
            this.tbxPlayerName = new System.Windows.Forms.TextBox();
            this.lblPasswordGame = new System.Windows.Forms.Label();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.ErrorsMessageLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            // lblPlayer
            // 
            this.lblPlayer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Location = new System.Drawing.Point(36, 154);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(0, 13);
            this.lblPlayer.TabIndex = 4;
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
            // btnEnterInGame
            // 
            this.btnEnterInGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEnterInGame.Enabled = false;
            this.btnEnterInGame.Location = new System.Drawing.Point(23, 167);
            this.btnEnterInGame.Name = "btnEnterInGame";
            this.btnEnterInGame.Size = new System.Drawing.Size(85, 30);
            this.btnEnterInGame.TabIndex = 2;
            this.btnEnterInGame.Text = "Entrar";
            this.btnEnterInGame.UseVisualStyleBackColor = true;
            // 
            // pnlInputToLogin
            // 
            this.pnlInputToLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInputToLogin.Controls.Add(this.ErrorsMessageLabel);
            this.pnlInputToLogin.Controls.Add(this.tbxPasswordGame);
            this.pnlInputToLogin.Controls.Add(this.btnEnterInGame);
            this.pnlInputToLogin.Controls.Add(this.tbxPlayerName);
            this.pnlInputToLogin.Controls.Add(this.lblPasswordGame);
            this.pnlInputToLogin.Controls.Add(this.lblPlayerName);
            this.pnlInputToLogin.Controls.Add(this.label4);
            this.pnlInputToLogin.Controls.Add(this.label1);
            this.pnlInputToLogin.Location = new System.Drawing.Point(434, 27);
            this.pnlInputToLogin.Name = "pnlInputToLogin";
            this.pnlInputToLogin.Size = new System.Drawing.Size(303, 335);
            this.pnlInputToLogin.TabIndex = 3;
            // 
            // tbxPasswordGame
            // 
            this.tbxPasswordGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbxPasswordGame.Location = new System.Drawing.Point(23, 126);
            this.tbxPasswordGame.Name = "tbxPasswordGame";
            this.tbxPasswordGame.Size = new System.Drawing.Size(113, 20);
            this.tbxPasswordGame.TabIndex = 3;
            this.tbxPasswordGame.TextChanged += new System.EventHandler(this.CheckInput);
            this.tbxPasswordGame.Enter += new System.EventHandler(this.VerifyEmptyFields);
            // 
            // tbxPlayerName
            // 
            this.tbxPlayerName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbxPlayerName.Location = new System.Drawing.Point(23, 68);
            this.tbxPlayerName.Name = "tbxPlayerName";
            this.tbxPlayerName.Size = new System.Drawing.Size(113, 20);
            this.tbxPlayerName.TabIndex = 2;
            this.tbxPlayerName.TextChanged += new System.EventHandler(this.CheckInput);
            this.tbxPlayerName.Enter += new System.EventHandler(this.VerifyEmptyFields);
            // 
            // lblPasswordGame
            // 
            this.lblPasswordGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPasswordGame.AutoSize = true;
            this.lblPasswordGame.Location = new System.Drawing.Point(27, 110);
            this.lblPasswordGame.Name = "lblPasswordGame";
            this.lblPasswordGame.Size = new System.Drawing.Size(88, 13);
            this.lblPasswordGame.TabIndex = 1;
            this.lblPasswordGame.Text = "Senha da partida";
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Location = new System.Drawing.Point(27, 52);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(88, 13);
            this.lblPlayerName.TabIndex = 0;
            this.lblPlayerName.Text = "Nome do jogador";
            // 
            // ErrorsMessageLabel
            // 
            this.ErrorsMessageLabel.AutoSize = true;
            this.ErrorsMessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorsMessageLabel.ForeColor = System.Drawing.Color.Brown;
            this.ErrorsMessageLabel.Location = new System.Drawing.Point(20, 22);
            this.ErrorsMessageLabel.Name = "ErrorsMessageLabel";
            this.ErrorsMessageLabel.Size = new System.Drawing.Size(261, 16);
            this.ErrorsMessageLabel.TabIndex = 4;
            this.ErrorsMessageLabel.Text = "Informe [Field] para entrar na partida";
            this.ErrorsMessageLabel.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(15, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(16, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "*";
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
        private System.Windows.Forms.Button btnEnterInGame;
        private System.Windows.Forms.Panel pnlInputToLogin;
        private System.Windows.Forms.TextBox tbxPasswordGame;
        private System.Windows.Forms.TextBox tbxPlayerName;
        private System.Windows.Forms.Label lblPasswordGame;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label ErrorsMessageLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}