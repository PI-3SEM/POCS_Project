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
            this.btnProvBet0 = new System.Windows.Forms.Button();
            this.pnlGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPlayerTimeIndicator
            // 
            this.lblPlayerTimeIndicator.AutoSize = true;
            this.lblPlayerTimeIndicator.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPlayerTimeIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerTimeIndicator.ForeColor = System.Drawing.Color.Maroon;
            this.lblPlayerTimeIndicator.Location = new System.Drawing.Point(0, 0);
            this.lblPlayerTimeIndicator.Name = "lblPlayerTimeIndicator";
            this.lblPlayerTimeIndicator.Size = new System.Drawing.Size(273, 20);
            this.lblPlayerTimeIndicator.TabIndex = 0;
            this.lblPlayerTimeIndicator.Text = "[PLAYER] realiza a primeira jogada";
            // 
            // pnlGame
            // 
            this.pnlGame.Controls.Add(this.btnProvBet0);
            this.pnlGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGame.Location = new System.Drawing.Point(0, 20);
            this.pnlGame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlGame.Name = "pnlGame";
            this.pnlGame.Size = new System.Drawing.Size(1005, 582);
            this.pnlGame.TabIndex = 1;
            // 
            // btnProvBet0
            // 
            this.btnProvBet0.Location = new System.Drawing.Point(859, 485);
            this.btnProvBet0.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProvBet0.Name = "btnProvBet0";
            this.btnProvBet0.Size = new System.Drawing.Size(72, 30);
            this.btnProvBet0.TabIndex = 0;
            this.btnProvBet0.Text = "Apostar 0";
            this.btnProvBet0.UseVisualStyleBackColor = true;
            this.btnProvBet0.Click += new System.EventHandler(this.btnProvBet0_Click);
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 602);
            this.Controls.Add(this.pnlGame);
            this.Controls.Add(this.lblPlayerTimeIndicator);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1021, 639);
            this.Name = "GameScreen";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.pnlGame.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayerTimeIndicator;
        private System.Windows.Forms.Panel pnlGame;
        private System.Windows.Forms.Button btnProvBet0;
    }
}