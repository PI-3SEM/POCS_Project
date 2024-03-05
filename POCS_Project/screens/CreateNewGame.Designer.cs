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
            this.SuspendLayout();
            // 
            // NameGameInput
            // 
            this.NameGameInput.Location = new System.Drawing.Point(12, 109);
            this.NameGameInput.Name = "NameGameInput";
            this.NameGameInput.Size = new System.Drawing.Size(250, 22);
            this.NameGameInput.TabIndex = 2;
            this.NameGameInput.TextChanged += new System.EventHandler(this.CheckInput);
            // 
            // GroupNameInput
            // 
            this.GroupNameInput.Location = new System.Drawing.Point(12, 190);
            this.GroupNameInput.Name = "GroupNameInput";
            this.GroupNameInput.Size = new System.Drawing.Size(250, 22);
            this.GroupNameInput.TabIndex = 3;
            this.GroupNameInput.TextChanged += new System.EventHandler(this.CheckInput);
            // 
            // PasswordInput
            // 
            this.PasswordInput.Location = new System.Drawing.Point(12, 255);
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.Size = new System.Drawing.Size(250, 22);
            this.PasswordInput.TabIndex = 4;
            this.PasswordInput.TextChanged += new System.EventHandler(this.CheckInput);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nome da Partida";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nome do Grupo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Senha";
            // 
            // CreateNewGameBtn
            // 
            this.CreateNewGameBtn.Enabled = false;
            this.CreateNewGameBtn.Location = new System.Drawing.Point(52, 324);
            this.CreateNewGameBtn.Name = "CreateNewGameBtn";
            this.CreateNewGameBtn.Size = new System.Drawing.Size(138, 23);
            this.CreateNewGameBtn.TabIndex = 8;
            this.CreateNewGameBtn.Text = "Criar Nova Partida";
            this.CreateNewGameBtn.UseVisualStyleBackColor = true;
            this.CreateNewGameBtn.Click += new System.EventHandler(this.CreateNewGameBtn_Click);
            // 
            // BackToMenuBtn
            // 
            this.BackToMenuBtn.Location = new System.Drawing.Point(713, 12);
            this.BackToMenuBtn.Name = "BackToMenuBtn";
            this.BackToMenuBtn.Size = new System.Drawing.Size(75, 23);
            this.BackToMenuBtn.TabIndex = 9;
            this.BackToMenuBtn.Text = "Menu";
            this.BackToMenuBtn.UseVisualStyleBackColor = true;
            this.BackToMenuBtn.Click += new System.EventHandler(this.BackToMenuBtn_Click);
            // 
            // CreateNewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BackToMenuBtn);
            this.Controls.Add(this.CreateNewGameBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordInput);
            this.Controls.Add(this.GroupNameInput);
            this.Controls.Add(this.NameGameInput);
            this.Name = "CreateNewGame";
            this.Text = "Criar nova partida";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}