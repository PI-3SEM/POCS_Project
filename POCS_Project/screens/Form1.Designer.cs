namespace POCS_Project
{
    partial class ChoosePlayMode
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.SinglePlayerBtn = new System.Windows.Forms.Button();
            this.MultiplayerBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SinglePlayerBtn
            // 
            this.SinglePlayerBtn.Location = new System.Drawing.Point(12, 102);
            this.SinglePlayerBtn.Name = "SinglePlayerBtn";
            this.SinglePlayerBtn.Size = new System.Drawing.Size(109, 45);
            this.SinglePlayerBtn.TabIndex = 0;
            this.SinglePlayerBtn.Text = "Single Player";
            this.SinglePlayerBtn.UseVisualStyleBackColor = true;
            // 
            // MultiplayerBtn
            // 
            this.MultiplayerBtn.Location = new System.Drawing.Point(12, 168);
            this.MultiplayerBtn.Name = "MultiplayerBtn";
            this.MultiplayerBtn.Size = new System.Drawing.Size(109, 45);
            this.MultiplayerBtn.TabIndex = 1;
            this.MultiplayerBtn.Text = "Multiplayer";
            this.MultiplayerBtn.UseVisualStyleBackColor = true;
            this.MultiplayerBtn.Click += new System.EventHandler(this.MultiplayerBtn_Click);
            // 
            // ChoosePlayMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 593);
            this.Controls.Add(this.MultiplayerBtn);
            this.Controls.Add(this.SinglePlayerBtn);
            this.MinimumSize = new System.Drawing.Size(1024, 640);
            this.Name = "ChoosePlayMode";
            this.Text = "Choose Play Mode";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SinglePlayerBtn;
        private System.Windows.Forms.Button MultiplayerBtn;
    }
}

