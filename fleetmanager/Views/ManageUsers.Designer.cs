namespace fleetmanager.Views
{
    partial class ManageUsers
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
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            usersDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)usersDataGridView).BeginInit();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(12, 300);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(308, 48);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Supprimer la ligne séléctionnée";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(255, 128, 0);
            btnEdit.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(12, 246);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(308, 48);
            btnEdit.TabIndex = 6;
            btnEdit.Text = "Modifier la ligne séléctionnée";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += BtnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.DodgerBlue;
            btnAdd.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(326, 588);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(944, 50);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "+ Ajouter un utilisateur";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;
            // 
            // usersDataGridView
            // 
            usersDataGridView.BackgroundColor = Color.White;
            usersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            usersDataGridView.Location = new Point(326, 15);
            usersDataGridView.Name = "usersDataGridView";
            usersDataGridView.RowHeadersWidth = 51;
            usersDataGridView.Size = new Size(944, 567);
            usersDataGridView.TabIndex = 4;
            // 
            // ManageUsers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 653);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(usersDataGridView);
            Name = "ManageUsers";
            Text = "ManageUsers";
            ((System.ComponentModel.ISupportInitialize)usersDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnDelete;
        private Button btnEdit;
        private Button btnAdd;
        private DataGridView usersDataGridView;
    }
}