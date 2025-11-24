namespace fleetmanager.Views
{
    partial class UserForm
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
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            cbRole = new ComboBox();
            btnValider = new Button();
            btnAnnuler = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Arial", 10.2F);
            txtUsername.Location = new Point(212, 50);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(173, 27);
            txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Arial", 10.2F);
            txtPassword.Location = new Point(212, 100);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(173, 27);
            txtPassword.TabIndex = 1;
            // 
            // cbRole
            // 
            cbRole.Font = new Font("Arial", 10.2F);
            cbRole.FormattingEnabled = true;
            cbRole.Items.AddRange(new object[] { "admin", "user", "manager" });
            cbRole.Location = new Point(212, 150);
            cbRole.Name = "cbRole";
            cbRole.Size = new Size(173, 27);
            cbRole.TabIndex = 2;
            // 
            // btnValider
            // 
            btnValider.BackColor = Color.DodgerBlue;
            btnValider.Font = new Font("Arial", 10.2F, FontStyle.Bold);
            btnValider.ForeColor = Color.White;
            btnValider.Location = new Point(12, 216);
            btnValider.Name = "btnValider";
            btnValider.Size = new Size(215, 29);
            btnValider.TabIndex = 3;
            btnValider.Text = "Valider";
            btnValider.UseVisualStyleBackColor = false;
            btnValider.Click += btnValider_Click;
            // 
            // btnAnnuler
            // 
            btnAnnuler.Font = new Font("Arial", 10.2F, FontStyle.Bold);
            btnAnnuler.Location = new Point(255, 216);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(215, 29);
            btnAnnuler.TabIndex = 4;
            btnAnnuler.Text = "Annuler";
            btnAnnuler.UseVisualStyleBackColor = true;
            btnAnnuler.Click += btnAnnuler_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 10.2F);
            label1.Location = new Point(68, 54);
            label1.Name = "label1";
            label1.Size = new Size(138, 19);
            label1.TabIndex = 5;
            label1.Text = "Nom d'utilisateur :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10.2F);
            label2.Location = new Point(90, 100);
            label2.Name = "label2";
            label2.Size = new Size(116, 19);
            label2.TabIndex = 6;
            label2.Text = "Mot de passe :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10.2F);
            label3.Location = new Point(155, 150);
            label3.Name = "label3";
            label3.Size = new Size(51, 19);
            label3.TabIndex = 7;
            label3.Text = "Rôle :";
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 257);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAnnuler);
            Controls.Add(btnValider);
            Controls.Add(cbRole);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Name = "UserForm";
            Text = "UserForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsername;
        private TextBox txtPassword;
        private ComboBox cbRole;
        private Button btnValider;
        private Button btnAnnuler;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}