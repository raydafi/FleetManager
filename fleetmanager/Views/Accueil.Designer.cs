namespace fleetmanager.Views
{
    partial class Accueil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Accueil));
            manageUsersButton = new Button();
            vehiculeButton = new Button();
            ajoutUtilisationButton = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // manageUsersButton
            // 
            manageUsersButton.Location = new Point(12, 381);
            manageUsersButton.Name = "manageUsersButton";
            manageUsersButton.Size = new Size(260, 50);
            manageUsersButton.TabIndex = 0;
            manageUsersButton.Text = "Administration des utilisateurs";
            manageUsersButton.UseVisualStyleBackColor = true;
            manageUsersButton.Click += manageUsersButton_Click;
            // 
            // vehiculeButton
            // 
            vehiculeButton.Location = new Point(12, 325);
            vehiculeButton.Name = "vehiculeButton";
            vehiculeButton.Size = new Size(260, 50);
            vehiculeButton.TabIndex = 1;
            vehiculeButton.Text = "Afficher les véhicules";
            vehiculeButton.UseVisualStyleBackColor = true;
            vehiculeButton.Click += vehiculeButton_Click;
            // 
            // ajoutUtilisationButton
            // 
            ajoutUtilisationButton.Location = new Point(12, 269);
            ajoutUtilisationButton.Name = "ajoutUtilisationButton";
            ajoutUtilisationButton.Size = new Size(260, 50);
            ajoutUtilisationButton.TabIndex = 2;
            ajoutUtilisationButton.Text = "Ajouter une utilisation de véhicule";
            ajoutUtilisationButton.UseVisualStyleBackColor = true;
            ajoutUtilisationButton.Click += ajoutUtilisationButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-171, -87);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(543, 285);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // Accueil
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1282, 653);
            Controls.Add(pictureBox1);
            Controls.Add(ajoutUtilisationButton);
            Controls.Add(vehiculeButton);
            Controls.Add(manageUsersButton);
            Name = "Accueil";
            Text = "Accueil";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button manageUsersButton;
        private Button vehiculeButton;
        private Button ajoutUtilisationButton;
        private PictureBox pictureBox1;
    }
}