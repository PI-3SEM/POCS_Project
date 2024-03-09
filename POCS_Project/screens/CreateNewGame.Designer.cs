namespace POCS_Project.screens
{
    partial class CreateNewGame
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
            this.NameGameInput = new System.Windows.Forms.TextBox();
            this.GroupNameInput = new System.Windows.Forms.TextBox();
            this.PasswordInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CreateNewGameBtn = new System.Windows.Forms.Button();
            this.BackToMenuBtn = new System.Windows.Forms.Button();
            this.pnlFormCreateGame = new System.Windows.Forms.Panel();
            this.tbxNameGroup = new System.Windows.Forms.TextBox();
            this.tbxNameGame = new System.Windows.Forms.TextBox();
            this.tbxPasswordGame = new System.Windows.Forms.TextBox();
            this.pnlFormCreateGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameGameInput
            // 
            this.NameGameInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NameGameInput.Location = new System.Drawing.Point(183, 88);
            this.NameGameInput.Margin = new System.Windows.Forms.Padding(2);
            this.NameGameInput.Name = "NameGameInput";
            this.NameGameInput.Size = new System.Drawing.Size(188, 20);
            this.NameGameInput.TabIndex = 2;
            this.NameGameInput.TextChanged += new System.EventHandler(this.CheckInput);
            // 
            // GroupNameInput
            // 
            this.GroupNameInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GroupNameInput.Location = new System.Drawing.Point(183, 147);
            this.GroupNameInput.Margin = new System.Windows.Forms.Padding(2);
            this.GroupNameInput.Name = "GroupNameInput";
            this.GroupNameInput.Size = new System.Drawing.Size(188, 20);
            this.GroupNameInput.TabIndex = 3;
            this.GroupNameInput.TextChanged += new System.EventHandler(this.CheckInput);
            // 
            // PasswordInput
            // 
            this.PasswordInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordInput.Location = new System.Drawing.Point(183, 200);
            this.PasswordInput.Margin = new System.Windows.Forms.Padding(2);
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.Size = new System.Drawing.Size(188, 20);
            this.PasswordInput.TabIndex = 4;
            this.PasswordInput.TextChanged += new System.EventHandler(this.CheckInput);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(183, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nome da Partida";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(183, 132);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nome do Grupo";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(183, 185);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Senha";
            // 
            // CreateNewGameBtn
            // 
            this.CreateNewGameBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CreateNewGameBtn.Enabled = false;
            this.CreateNewGameBtn.Location = new System.Drawing.Point(218, 261);
            this.CreateNewGameBtn.Margin = new System.Windows.Forms.Padding(2);
            this.CreateNewGameBtn.Name = "CreateNewGameBtn";
            this.CreateNewGameBtn.Size = new System.Drawing.Size(104, 19);
            this.CreateNewGameBtn.TabIndex = 8;
            this.CreateNewGameBtn.Text = "Criar Nova Partida";
            this.CreateNewGameBtn.UseVisualStyleBackColor = true;
            this.CreateNewGameBtn.Click += new System.EventHandler(this.CreateNewGameBtn_Click);
            // 
            // BackToMenuBtn
            // 
            this.BackToMenuBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BackToMenuBtn.Location = new System.Drawing.Point(687, 11);
            this.BackToMenuBtn.Margin = new System.Windows.Forms.Padding(2);
            this.BackToMenuBtn.Name = "BackToMenuBtn";
            this.BackToMenuBtn.Size = new System.Drawing.Size(56, 19);
            this.BackToMenuBtn.TabIndex = 9;
            this.BackToMenuBtn.Text = "Menu";
            this.BackToMenuBtn.UseVisualStyleBackColor = true;
            this.BackToMenuBtn.Click += new System.EventHandler(this.BackToMenuBtn_Click);
            // 
            // pnlFormCreateGame
            // 
            this.pnlFormCreateGame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFormCreateGame.BackColor = System.Drawing.Color.Transparent;
            this.pnlFormCreateGame.Controls.Add(this.CreateNewGameBtn);
            this.pnlFormCreateGame.Controls.Add(this.tbxNameGroup);
            this.pnlFormCreateGame.Controls.Add(this.GroupNameInput);
            this.pnlFormCreateGame.Controls.Add(this.tbxNameGame);
            this.pnlFormCreateGame.Controls.Add(this.NameGameInput);
            this.pnlFormCreateGame.Controls.Add(this.tbxPasswordGame);
            this.pnlFormCreateGame.Controls.Add(this.PasswordInput);
            this.pnlFormCreateGame.Controls.Add(this.label3);
            this.pnlFormCreateGame.Controls.Add(this.label1);
            this.pnlFormCreateGame.Controls.Add(this.label2);
            this.pnlFormCreateGame.Location = new System.Drawing.Point(93, 50);
            this.pnlFormCreateGame.Name = "pnlFormCreateGame";
            this.pnlFormCreateGame.Size = new System.Drawing.Size(537, 364);
            this.pnlFormCreateGame.TabIndex = 10;
            // 
            // tbxNameGroup
            // 
            this.tbxNameGroup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbxNameGroup.Location = new System.Drawing.Point(183, 150);
            this.tbxNameGroup.Margin = new System.Windows.Forms.Padding(2);
            this.tbxNameGroup.Name = "tbxNameGroup";
            this.tbxNameGroup.Size = new System.Drawing.Size(188, 20);
            this.tbxNameGroup.TabIndex = 3;
            this.tbxNameGroup.TextChanged += new System.EventHandler(this.CheckInput);
            // 
            // tbxNameGame
            // 
            this.tbxNameGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbxNameGame.Location = new System.Drawing.Point(183, 91);
            this.tbxNameGame.Margin = new System.Windows.Forms.Padding(2);
            this.tbxNameGame.Name = "tbxNameGame";
            this.tbxNameGame.Size = new System.Drawing.Size(188, 20);
            this.tbxNameGame.TabIndex = 2;
            this.tbxNameGame.TextChanged += new System.EventHandler(this.CheckInput);
            // 
            // tbxPasswordGame
            // 
            this.tbxPasswordGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbxPasswordGame.Location = new System.Drawing.Point(183, 203);
            this.tbxPasswordGame.Margin = new System.Windows.Forms.Padding(2);
            this.tbxPasswordGame.Name = "tbxPasswordGame";
            this.tbxPasswordGame.Size = new System.Drawing.Size(188, 20);
            this.tbxPasswordGame.TabIndex = 4;
            this.tbxPasswordGame.TextChanged += new System.EventHandler(this.CheckInput);
            // 
            // CreateNewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 491);
            this.Controls.Add(this.pnlFormCreateGame);
            this.Controls.Add(this.BackToMenuBtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(770, 530);
            this.Name = "CreateNewGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Criar nova partida";
            this.pnlFormCreateGame.ResumeLayout(false);
            this.pnlFormCreateGame.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox NameGameInput;
        private System.Windows.Forms.TextBox GroupNameInput;
        private System.Windows.Forms.TextBox PasswordInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CreateNewGameBtn;
        private System.Windows.Forms.Button BackToMenuBtn;
        private System.Windows.Forms.Panel pnlFormCreateGame;
        private System.Windows.Forms.TextBox tbxNameGroup;
        private System.Windows.Forms.TextBox tbxNameGame;
        private System.Windows.Forms.TextBox tbxPasswordGame;
    }
}