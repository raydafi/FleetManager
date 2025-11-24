namespace fleetmanager.Views
{
    partial class ManageVehicule
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
            txtImmatriculation = new TextBox();
            txtDescription = new TextBox();
            txtModele = new TextBox();
            numKilometrage = new NumericUpDown();
            numPrix = new NumericUpDown();
            btnValider = new Button();
            btnAnnuler = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)numKilometrage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrix).BeginInit();
            SuspendLayout();
            // 
            // txtImmatriculation
            // 
            txtImmatriculation.Font = new Font("Arial", 10.2F);
            txtImmatriculation.Location = new Point(194, 48);
            txtImmatriculation.Name = "txtImmatriculation";
            txtImmatriculation.Size = new Size(178, 27);
            txtImmatriculation.TabIndex = 0;
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Arial", 10.2F);
            txtDescription.Location = new Point(194, 146);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(178, 27);
            txtDescription.TabIndex = 1;
            // 
            // txtModele
            // 
            txtModele.Font = new Font("Arial", 10.2F);
            txtModele.Location = new Point(194, 97);
            txtModele.Name = "txtModele";
            txtModele.Size = new Size(178, 27);
            txtModele.TabIndex = 2;
            // 
            // numKilometrage
            // 
            numKilometrage.Font = new Font("Arial", 10.2F);
            numKilometrage.Location = new Point(194, 197);
            numKilometrage.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numKilometrage.Name = "numKilometrage";
            numKilometrage.Size = new Size(178, 27);
            numKilometrage.TabIndex = 3;
            // 
            // numPrix
            // 
            numPrix.DecimalPlaces = 2;
            numPrix.Font = new Font("Arial", 10.2F);
            numPrix.Location = new Point(194, 248);
            numPrix.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numPrix.Name = "numPrix";
            numPrix.Size = new Size(178, 27);
            numPrix.TabIndex = 4;
            // 
            // btnValider
            // 
            btnValider.BackColor = Color.DodgerBlue;
            btnValider.Font = new Font("Arial", 10.2F, FontStyle.Bold);
            btnValider.ForeColor = Color.White;
            btnValider.Location = new Point(12, 303);
            btnValider.Name = "btnValider";
            btnValider.Size = new Size(221, 36);
            btnValider.TabIndex = 5;
            btnValider.Text = "Valider";
            btnValider.UseVisualStyleBackColor = false;
            // 
            // btnAnnuler
            // 
            btnAnnuler.BackColor = Color.White;
            btnAnnuler.Font = new Font("Arial", 10.2F, FontStyle.Bold);
            btnAnnuler.Location = new Point(249, 303);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(221, 36);
            btnAnnuler.TabIndex = 6;
            btnAnnuler.Text = "Annuler";
            btnAnnuler.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 10.2F);
            label1.Location = new Point(55, 51);
            label1.Name = "label1";
            label1.Size = new Size(129, 19);
            label1.TabIndex = 7;
            label1.Text = "Immatriculation :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10.2F);
            label2.Location = new Point(113, 100);
            label2.Name = "label2";
            label2.Size = new Size(71, 19);
            label2.TabIndex = 8;
            label2.Text = "Modèle :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 10.2F);
            label3.Location = new Point(88, 150);
            label3.Name = "label3";
            label3.Size = new Size(102, 19);
            label3.TabIndex = 9;
            label3.Text = "Description :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10.2F);
            label4.Location = new Point(82, 200);
            label4.Name = "label4";
            label4.Size = new Size(105, 19);
            label4.TabIndex = 10;
            label4.Text = "Kilométrage :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 10.2F);
            label5.Location = new Point(83, 250);
            label5.Name = "label5";
            label5.Size = new Size(101, 19);
            label5.TabIndex = 11;
            label5.Text = "Prix au litre :";
            // 
            // ManageVehicule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 351);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAnnuler);
            Controls.Add(btnValider);
            Controls.Add(numPrix);
            Controls.Add(numKilometrage);
            Controls.Add(txtModele);
            Controls.Add(txtDescription);
            Controls.Add(txtImmatriculation);
            Name = "ManageVehicule";
            Text = "ManageVehicule";
            ((System.ComponentModel.ISupportInitialize)numKilometrage).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrix).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtImmatriculation;
        private TextBox txtDescription;
        private TextBox txtModele;
        private NumericUpDown numKilometrage;
        private NumericUpDown numPrix;
        private Button btnValider;
        private Button btnAnnuler;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}