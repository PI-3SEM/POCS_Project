﻿namespace POCS_Project
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChoosePlayMode));
            this.MultiplayerBtn = new System.Windows.Forms.Button();
            this.lbltitlemenu = new System.Windows.Forms.Label();
            this.btniconbratislava = new System.Windows.Forms.Button();
            this.pnlMenuBox = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pnlMenuBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MultiplayerBtn
            // 
            this.MultiplayerBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MultiplayerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MultiplayerBtn.Location = new System.Drawing.Point(213, 202);
            this.MultiplayerBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MultiplayerBtn.MaximumSize = new System.Drawing.Size(400, 49);
            this.MultiplayerBtn.MinimumSize = new System.Drawing.Size(107, 49);
            this.MultiplayerBtn.Name = "MultiplayerBtn";
            this.MultiplayerBtn.Size = new System.Drawing.Size(271, 49);
            this.MultiplayerBtn.TabIndex = 1;
            this.MultiplayerBtn.Text = "Iniciar";
            this.MultiplayerBtn.UseVisualStyleBackColor = true;
            this.MultiplayerBtn.Click += new System.EventHandler(this.MultiplayerBtn_Click);
            // 
            // lbltitlemenu
            // 
            this.lbltitlemenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbltitlemenu.AutoSize = true;
            this.lbltitlemenu.BackColor = System.Drawing.Color.Transparent;
            this.lbltitlemenu.Font = new System.Drawing.Font("Matura MT Script Capitals", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitlemenu.ForeColor = System.Drawing.Color.Black;
            this.lbltitlemenu.Location = new System.Drawing.Point(5, 28);
            this.lbltitlemenu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltitlemenu.MaximumSize = new System.Drawing.Size(667, 98);
            this.lbltitlemenu.MinimumSize = new System.Drawing.Size(133, 49);
            this.lbltitlemenu.Name = "lbltitlemenu";
            this.lbltitlemenu.Size = new System.Drawing.Size(459, 53);
            this.lbltitlemenu.TabIndex = 2;
            this.lbltitlemenu.Text = "Bem vindo a Bratislava";
            // 
            // btniconbratislava
            // 
            this.btniconbratislava.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btniconbratislava.BackColor = System.Drawing.Color.Transparent;
            this.btniconbratislava.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btniconbratislava.BackgroundImage")));
            this.btniconbratislava.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btniconbratislava.FlatAppearance.BorderSize = 0;
            this.btniconbratislava.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btniconbratislava.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btniconbratislava.ForeColor = System.Drawing.Color.Transparent;
            this.btniconbratislava.Location = new System.Drawing.Point(507, 28);
            this.btniconbratislava.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btniconbratislava.Name = "btniconbratislava";
            this.btniconbratislava.Size = new System.Drawing.Size(145, 101);
            this.btniconbratislava.TabIndex = 3;
            this.btniconbratislava.UseVisualStyleBackColor = false;
            // 
            // pnlMenuBox
            // 
            this.pnlMenuBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMenuBox.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenuBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlMenuBox.Controls.Add(this.lblVersion);
            this.pnlMenuBox.Controls.Add(this.lbltitlemenu);
            this.pnlMenuBox.Controls.Add(this.btniconbratislava);
            this.pnlMenuBox.Controls.Add(this.MultiplayerBtn);
            this.pnlMenuBox.Location = new System.Drawing.Point(204, 107);
            this.pnlMenuBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlMenuBox.Name = "pnlMenuBox";
            this.pnlMenuBox.Size = new System.Drawing.Size(712, 394);
            this.pnlMenuBox.TabIndex = 4;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(21, 81);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(0, 20);
            this.lblVersion.TabIndex = 5;
            // 
            // ChoosePlayMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1143, 658);
            this.Controls.Add(this.pnlMenuBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1093, 653);
            this.Name = "ChoosePlayMode";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose Play Mode";
            this.Load += new System.EventHandler(this.ChoosePlayMode_Load);
            this.pnlMenuBox.ResumeLayout(false);
            this.pnlMenuBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button MultiplayerBtn;
        private System.Windows.Forms.Label lbltitlemenu;
        private System.Windows.Forms.Button btniconbratislava;
        private System.Windows.Forms.Panel pnlMenuBox;
        private System.Windows.Forms.Label lblVersion;
    }
}

