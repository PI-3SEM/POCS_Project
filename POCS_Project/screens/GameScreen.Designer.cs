namespace POCS_Project.screens
{
    partial class GameScreen
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
            this.lblPlayerTimeIndicator = new System.Windows.Forms.Label();
            this.pnlGame = new System.Windows.Forms.Panel();
            this.pbPlayedCard = new System.Windows.Forms.PictureBox();
            this.lblVersionOnGame = new System.Windows.Forms.Label();
            this.tbxDisplayRounds = new System.Windows.Forms.RichTextBox();
            this.pnlGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayedCard)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlayerTimeIndicator
            // 
            this.lblPlayerTimeIndicator.AutoSize = true;
            this.lblPlayerTimeIndicator.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPlayerTimeIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerTimeIndicator.ForeColor = System.Drawing.Color.Maroon;
            this.lblPlayerTimeIndicator.Location = new System.Drawing.Point(0, 0);
            this.lblPlayerTimeIndicator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPlayerTimeIndicator.Name = "lblPlayerTimeIndicator";
            this.lblPlayerTimeIndicator.Size = new System.Drawing.Size(230, 17);
            this.lblPlayerTimeIndicator.TabIndex = 0;
            this.lblPlayerTimeIndicator.Text = "[PLAYER] realiza a primeira jogada";
            // 
            // pnlGame
            // 
            this.pnlGame.Controls.Add(this.pbPlayedCard);
            this.pnlGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGame.Location = new System.Drawing.Point(0, 17);
            this.pnlGame.Margin = new System.Windows.Forms.Padding(2);
            this.pnlGame.Name = "pnlGame";
            this.pnlGame.Size = new System.Drawing.Size(786, 664);
            this.pnlGame.TabIndex = 1;
            // 
            // pbPlayedCard
            // 
            this.pbPlayedCard.Location = new System.Drawing.Point(409, 221);
            this.pbPlayedCard.Margin = new System.Windows.Forms.Padding(2);
            this.pbPlayedCard.Name = "pbPlayedCard";
            this.pbPlayedCard.Size = new System.Drawing.Size(60, 79);
            this.pbPlayedCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlayedCard.TabIndex = 1;
            this.pbPlayedCard.TabStop = false;
            // 
            // lblVersionOnGame
            // 
            this.lblVersionOnGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersionOnGame.AutoSize = true;
            this.lblVersionOnGame.Location = new System.Drawing.Point(840, 1);
            this.lblVersionOnGame.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lblVersionOnGame.Name = "lblVersionOnGame";
            this.lblVersionOnGame.Size = new System.Drawing.Size(0, 13);
            this.lblVersionOnGame.TabIndex = 2;
            // 
            // tbxDisplayRounds
            // 
            this.tbxDisplayRounds.Dock = System.Windows.Forms.DockStyle.Right;
            this.tbxDisplayRounds.Enabled = false;
            this.tbxDisplayRounds.Location = new System.Drawing.Point(786, 17);
            this.tbxDisplayRounds.Margin = new System.Windows.Forms.Padding(2);
            this.tbxDisplayRounds.Name = "tbxDisplayRounds";
            this.tbxDisplayRounds.Size = new System.Drawing.Size(101, 664);
            this.tbxDisplayRounds.TabIndex = 3;
            this.tbxDisplayRounds.Text = "";
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 681);
            this.Controls.Add(this.pnlGame);
            this.Controls.Add(this.tbxDisplayRounds);
            this.Controls.Add(this.lblVersionOnGame);
            this.Controls.Add(this.lblPlayerTimeIndicator);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(770, 526);
            this.Name = "GameScreen";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.SizeChanged += new System.EventHandler(this.GameScreen_SizeChanged);
            this.pnlGame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayedCard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayerTimeIndicator;
        private System.Windows.Forms.Panel pnlGame;
        private System.Windows.Forms.PictureBox pbPlayedCard;
        private System.Windows.Forms.Label lblVersionOnGame;
        private System.Windows.Forms.RichTextBox tbxDisplayRounds;
    }
}