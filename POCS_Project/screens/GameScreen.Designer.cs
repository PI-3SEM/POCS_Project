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
            this.SuspendLayout();
            // 
            // lblPlayerTimeIndicator
            // 
            this.lblPlayerTimeIndicator.AutoSize = true;
            this.lblPlayerTimeIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerTimeIndicator.ForeColor = System.Drawing.Color.Maroon;
            this.lblPlayerTimeIndicator.Location = new System.Drawing.Point(12, 9);
            this.lblPlayerTimeIndicator.Name = "lblPlayerTimeIndicator";
            this.lblPlayerTimeIndicator.Size = new System.Drawing.Size(273, 20);
            this.lblPlayerTimeIndicator.TabIndex = 0;
            this.lblPlayerTimeIndicator.Text = "[PLAYER] realiza a primeira jogada";
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 594);
            this.Controls.Add(this.lblPlayerTimeIndicator);
            this.MinimumSize = new System.Drawing.Size(1021, 641);
            this.Name = "GameScreen";
            this.Text = "Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayerTimeIndicator;
    }
}