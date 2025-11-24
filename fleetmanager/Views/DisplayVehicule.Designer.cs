namespace fleetmanager.Views
{
    partial class DisplayVehicule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayVehicule));
            vehiculesDataGridView = new DataGridView();
            ajouterButton = new Button();
            modifierButton = new Button();
            supprimerButton = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)vehiculesDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // vehiculesDataGridView
            // 
            vehiculesDataGridView.BackgroundColor = Color.White;
            vehiculesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            vehiculesDataGridView.GridColor = Color.DodgerBlue;
            vehiculesDataGridView.Location = new Point(326, 12);
            vehiculesDataGridView.Name = "vehiculesDataGridView";
            vehiculesDataGridView.RowHeadersWidth = 51;
            vehiculesDataGridView.Size = new Size(944, 567);
            vehiculesDataGridView.TabIndex = 0;
            // 
            // ajouterButton
            // 
            ajouterButton.BackColor = Color.DodgerBlue;
            ajouterButton.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ajouterButton.ForeColor = Color.White;
            ajouterButton.Location = new Point(326, 585);
            ajouterButton.Name = "ajouterButton";
            ajouterButton.Size = new Size(944, 50);
            ajouterButton.TabIndex = 1;
            ajouterButton.Text = "+ Ajouter un véhicule";
            ajouterButton.UseVisualStyleBackColor = false;
            ajouterButton.Click += ajouterButton_Click;
            // 
            // modifierButton
            // 
            modifierButton.BackColor = Color.FromArgb(255, 128, 0);
            modifierButton.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            modifierButton.ForeColor = Color.White;
            modifierButton.Location = new Point(12, 243);
            modifierButton.Name = "modifierButton";
            modifierButton.Size = new Size(308, 48);
            modifierButton.TabIndex = 2;
            modifierButton.Text = "Modifier la ligne séléctionnée";
            modifierButton.UseVisualStyleBackColor = false;
            modifierButton.Click += modifierButton_Click;
            // 
            // supprimerButton
            // 
            supprimerButton.BackColor = Color.Red;
            supprimerButton.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            supprimerButton.ForeColor = Color.White;
            supprimerButton.Location = new Point(12, 297);
            supprimerButton.Name = "supprimerButton";
            supprimerButton.Size = new Size(308, 48);
            supprimerButton.TabIndex = 3;
            supprimerButton.Text = "Supprimer la ligne séléctionnée";
            supprimerButton.UseVisualStyleBackColor = false;
            supprimerButton.Click += supprimerButton_Click;
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
            // DisplayVehicule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 653);
            Controls.Add(vehiculesDataGridView);
            Controls.Add(pictureBox1);
            Controls.Add(supprimerButton);
            Controls.Add(modifierButton);
            Controls.Add(ajouterButton);
            Name = "DisplayVehicule";
            Text = "DisplayVehicule";
            ((System.ComponentModel.ISupportInitialize)vehiculesDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView vehiculesDataGridView;
        private Button ajouterButton;
        private Button modifierButton;
        private Button supprimerButton;
        private PictureBox pictureBox1;
    }
}