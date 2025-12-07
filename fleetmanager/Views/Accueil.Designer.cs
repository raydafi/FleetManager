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
            pictureBox1 = new PictureBox();
            ajoutUtilisationButton = new Button();
            vehiculeButton = new Button();
            userButton = new Button();
            dgvResume = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvResume).BeginInit();
            SuspendLayout();
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
            // ajoutUtilisationButton
            // 
            ajoutUtilisationButton.Location = new Point(69, 221);
            ajoutUtilisationButton.Name = "ajoutUtilisationButton";
            ajoutUtilisationButton.Size = new Size(214, 47);
            ajoutUtilisationButton.TabIndex = 8;
            ajoutUtilisationButton.Text = "Ajouter une utilisation";
            ajoutUtilisationButton.UseVisualStyleBackColor = true;
            // 
            // vehiculeButton
            // 
            vehiculeButton.Location = new Point(69, 274);
            vehiculeButton.Name = "vehiculeButton";
            vehiculeButton.Size = new Size(214, 47);
            vehiculeButton.TabIndex = 9;
            vehiculeButton.Text = "Gérer les véhicules";
            vehiculeButton.UseVisualStyleBackColor = true;
            // 
            // userButton
            // 
            userButton.Location = new Point(69, 327);
            userButton.Name = "userButton";
            userButton.Size = new Size(214, 47);
            userButton.TabIndex = 10;
            userButton.Text = "Gérer les utilisateurs";
            userButton.UseVisualStyleBackColor = true;
            // 
            // dgvResume
            // 
            dgvResume.AllowUserToAddRows = false;
            dgvResume.BackgroundColor = Color.White;
            dgvResume.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResume.GridColor = Color.DodgerBlue;
            dgvResume.Location = new Point(338, 35);
            dgvResume.Name = "dgvResume";
            dgvResume.ReadOnly = true;
            dgvResume.RowHeadersVisible = false;
            dgvResume.RowHeadersWidth = 51;
            dgvResume.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResume.Size = new Size(944, 618);
            dgvResume.TabIndex = 11;
            // 
            // Accueil
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 653);
            Controls.Add(dgvResume);
            Controls.Add(userButton);
            Controls.Add(vehiculeButton);
            Controls.Add(ajoutUtilisationButton);
            Controls.Add(pictureBox1);
            Name = "Accueil";
            Text = "Accueil";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvResume).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button ajoutUtilisationButton;
        private Button vehiculeButton;
        private Button userButton;
        private DataGridView dgvResume;
    }
}