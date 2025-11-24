namespace fleetmanager.Views
{
    partial class AjoutUtilisation
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
            cbVehicules = new ComboBox();
            dtpDebut = new DateTimePicker();
            dtpFin = new DateTimePicker();
            numDistance = new NumericUpDown();
            txtCommentaire = new TextBox();
            btnValider = new Button();
            btnAnnuler = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)numDistance).BeginInit();
            SuspendLayout();
            // 
            // cbVehicules
            // 
            cbVehicules.Font = new Font("Arial", 10.2F);
            cbVehicules.FormattingEnabled = true;
            cbVehicules.Location = new Point(188, 50);
            cbVehicules.Name = "cbVehicules";
            cbVehicules.Size = new Size(250, 27);
            cbVehicules.TabIndex = 0;
            // 
            // dtpDebut
            // 
            dtpDebut.Font = new Font("Arial", 10.2F);
            dtpDebut.Location = new Point(188, 100);
            dtpDebut.Name = "dtpDebut";
            dtpDebut.Size = new Size(250, 27);
            dtpDebut.TabIndex = 1;
            // 
            // dtpFin
            // 
            dtpFin.Font = new Font("Arial", 10.2F);
            dtpFin.Location = new Point(188, 150);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(250, 27);
            dtpFin.TabIndex = 2;
            // 
            // numDistance
            // 
            numDistance.Font = new Font("Arial", 10.2F);
            numDistance.Location = new Point(188, 200);
            numDistance.Name = "numDistance";
            numDistance.Size = new Size(250, 27);
            numDistance.TabIndex = 3;
            // 
            // txtCommentaire
            // 
            txtCommentaire.Font = new Font("Arial", 10.2F);
            txtCommentaire.Location = new Point(188, 250);
            txtCommentaire.Multiline = true;
            txtCommentaire.Name = "txtCommentaire";
            txtCommentaire.Size = new Size(250, 34);
            txtCommentaire.TabIndex = 4;
            // 
            // btnValider
            // 
            btnValider.BackColor = Color.DodgerBlue;
            btnValider.Font = new Font("Arial", 10.2F, FontStyle.Bold);
            btnValider.ForeColor = Color.White;
            btnValider.Location = new Point(12, 378);
            btnValider.Name = "btnValider";
            btnValider.Size = new Size(215, 29);
            btnValider.TabIndex = 5;
            btnValider.Text = "Valider";
            btnValider.UseVisualStyleBackColor = false;
            // 
            // btnAnnuler
            // 
            btnAnnuler.Font = new Font("Arial", 10.2F, FontStyle.Bold);
            btnAnnuler.Location = new Point(255, 378);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(215, 29);
            btnAnnuler.TabIndex = 6;
            btnAnnuler.Text = "Annuler";
            btnAnnuler.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 10.2F);
            label1.Location = new Point(58, 50);
            label1.Name = "label1";
            label1.Size = new Size(124, 19);
            label1.TabIndex = 7;
            label1.Text = "Choix véhicule :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10.2F);
            label2.Location = new Point(61, 100);
            label2.Name = "label2";
            label2.Size = new Size(121, 19);
            label2.TabIndex = 8;
            label2.Text = "Date de début :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10.2F);
            label3.Location = new Point(83, 150);
            label3.Name = "label3";
            label3.Size = new Size(99, 19);
            label3.TabIndex = 9;
            label3.Text = "Date de fin :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10.2F);
            label4.Location = new Point(19, 200);
            label4.Name = "label4";
            label4.Size = new Size(163, 19);
            label4.TabIndex = 10;
            label4.Text = "Distance parcourue :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 10.2F);
            label5.Location = new Point(77, 250);
            label5.Name = "label5";
            label5.Size = new Size(105, 19);
            label5.TabIndex = 11;
            label5.Text = "Observation :";
            // 
            // AjoutUtilisation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 419);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAnnuler);
            Controls.Add(btnValider);
            Controls.Add(txtCommentaire);
            Controls.Add(numDistance);
            Controls.Add(dtpFin);
            Controls.Add(dtpDebut);
            Controls.Add(cbVehicules);
            Name = "AjoutUtilisation";
            Text = "AjoutUtilisation";
            ((System.ComponentModel.ISupportInitialize)numDistance).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbVehicules;
        private DateTimePicker dtpDebut;
        private DateTimePicker dtpFin;
        private NumericUpDown numDistance;
        private TextBox txtCommentaire;
        private Button btnValider;
        private Button btnAnnuler;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}