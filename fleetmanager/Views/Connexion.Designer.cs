namespace fleetmanager.Views
{
    partial class Connexion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connexion));
            label1 = new Label();
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            connexionButton = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Black", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DodgerBlue;
            label1.Location = new Point(475, 131);
            label1.Name = "label1";
            label1.Size = new Size(350, 67);
            label1.TabIndex = 0;
            label1.Text = "CONNEXION";
            // 
            // usernameTextBox
            // 
            usernameTextBox.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usernameTextBox.Location = new Point(500, 290);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(300, 34);
            usernameTextBox.TabIndex = 1;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Font = new Font("Arial", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordTextBox.Location = new Point(500, 412);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(300, 34);
            passwordTextBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DodgerBlue;
            label2.Location = new Point(500, 259);
            label2.Name = "label2";
            label2.Size = new Size(125, 28);
            label2.TabIndex = 3;
            label2.Text = "Identifiant";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DodgerBlue;
            label3.Location = new Point(500, 381);
            label3.Name = "label3";
            label3.Size = new Size(156, 28);
            label3.TabIndex = 4;
            label3.Text = "Mot de passe";
            // 
            // connexionButton
            // 
            connexionButton.BackColor = Color.DodgerBlue;
            connexionButton.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            connexionButton.ForeColor = Color.White;
            connexionButton.Location = new Point(615, 500);
            connexionButton.Name = "connexionButton";
            connexionButton.Size = new Size(185, 39);
            connexionButton.TabIndex = 5;
            connexionButton.Text = "Se connecter";
            connexionButton.UseVisualStyleBackColor = false;
            connexionButton.Click += connexionButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-171, -87);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(543, 285);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // Connexion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 653);
            Controls.Add(pictureBox1);
            Controls.Add(connexionButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(label1);
            Name = "Connexion";
            Text = "Connexion";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Label label2;
        private Label label3;
        private Button connexionButton;
        private PictureBox pictureBox1;
    }
}