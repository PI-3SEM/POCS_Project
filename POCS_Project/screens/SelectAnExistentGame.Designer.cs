namespace POCS_Project
{
    partial class SelectAnExistentGame
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
            this.CreateNewGame_Btn = new System.Windows.Forms.Button();
            this.GamesTable = new System.Windows.Forms.TableLayoutPanel();
            this.BackToMenuBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateNewGame_Btn
            // 
            this.CreateNewGame_Btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateNewGame_Btn.Location = new System.Drawing.Point(855, 548);
            this.CreateNewGame_Btn.Name = "CreateNewGame_Btn";
            this.CreateNewGame_Btn.Size = new System.Drawing.Size(139, 33);
            this.CreateNewGame_Btn.TabIndex = 0;
            this.CreateNewGame_Btn.Text = "Criar Nova Partida";
            this.CreateNewGame_Btn.UseVisualStyleBackColor = true;
            this.CreateNewGame_Btn.Click += new System.EventHandler(this.CreateNewGame_Btn_Click);
            // 
            // GamesTable
            // 
            this.GamesTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GamesTable.AutoScroll = true;
            this.GamesTable.ColumnCount = 3;
            this.GamesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.GamesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.GamesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.GamesTable.Location = new System.Drawing.Point(12, 12);
            this.GamesTable.Name = "GamesTable";
            this.GamesTable.RowCount = 1;
            this.GamesTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 530F));
            this.GamesTable.Size = new System.Drawing.Size(982, 530);
            this.GamesTable.TabIndex = 1;
            // 
            // BackToMenuBtn
            // 
            this.BackToMenuBtn.Location = new System.Drawing.Point(12, 555);
            this.BackToMenuBtn.Name = "BackToMenuBtn";
            this.BackToMenuBtn.Size = new System.Drawing.Size(97, 26);
            this.BackToMenuBtn.TabIndex = 2;
            this.BackToMenuBtn.Text = "Menu";
            this.BackToMenuBtn.UseVisualStyleBackColor = true;
            this.BackToMenuBtn.Click += new System.EventHandler(this.BackToMenuBtn_Click);
            // 
            // SelectAnExistentGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 593);
            this.Controls.Add(this.BackToMenuBtn);
            this.Controls.Add(this.GamesTable);
            this.Controls.Add(this.CreateNewGame_Btn);
            this.MinimumSize = new System.Drawing.Size(1024, 640);
            this.Name = "SelectAnExistentGame";
            this.Text = "Selecionar uma partida existente";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateNewGame_Btn;
        private System.Windows.Forms.TableLayoutPanel GamesTable;
        private System.Windows.Forms.Button BackToMenuBtn;
    }
}