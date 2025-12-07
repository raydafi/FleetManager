using fleetmanager.Controllers;
using fleetmanager.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace fleetmanager.Views
{
    public partial class ManageUsers : Form
    {
        private User utilisateurActuel;
        private Controller controller;

        public ManageUsers(User user)
        {
            InitializeComponent();

            this.utilisateurActuel = user;
            this.controller = new Controller();

            this.Text = "Gestion des Utilisateurs";
            this.StartPosition = FormStartPosition.CenterScreen;

            ConfigureGrid();

            // On charge les utilisateurs au démarrage
            this.Load += (s, e) => ChargerUtilisateurs();
        }

        private void ConfigureGrid()
        {
            usersDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            usersDataGridView.MultiSelect = false;
            usersDataGridView.ReadOnly = true;
            usersDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            usersDataGridView.AllowUserToAddRows = false;
        }

        private void ChargerUtilisateurs()
        {
            try
            {
                List<User> users = controller.GetTousLesUtilisateurs();
                usersDataGridView.DataSource = users;

                // Masquer le mot de passe (Important car maintenant ce sont des hashs longs)
                if (usersDataGridView.Columns["Password"] != null)
                {
                    usersDataGridView.Columns["Password"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement : " + ex.Message);
            }
        }

        // --- GESTION DES BOUTONS ---

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // Mode AJOUT (null)
            // IMPORTANT : Dans UserForm.cs, au moment de sauvegarder, 
            // assurez-vous d'utiliser BCrypt.HashPassword(txtPassword.Text)
            // avant d'appeler controller.CreerNouvelUtilisateur
            UserForm form = new UserForm(null);

            form.ShowDialog();

            // Une fois fermée, on recharge la liste
            ChargerUtilisateurs();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            User selectedUser = GetSelectedUser();
            if (selectedUser != null)
            {
                // Mode ÉDITION
                UserForm form = new UserForm(selectedUser);

                form.ShowDialog();

                ChargerUtilisateurs();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            User selectedUser = GetSelectedUser();
            if (selectedUser != null)
            {
                // Sécurité : Empêcher l'auto-suppression
                if (selectedUser.UserId == utilisateurActuel.UserId)
                {
                    MessageBox.Show("Vous ne pouvez pas supprimer votre propre compte !", "Action interdite", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var res = MessageBox.Show($"Voulez-vous vraiment supprimer {selectedUser.Username} ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (res == DialogResult.Yes)
                {
                    bool success = controller.SupprimerUtilisateur(selectedUser.UserId);
                    if (success)
                    {
                        MessageBox.Show("Utilisateur supprimé.");
                        ChargerUtilisateurs();
                    }
                    else
                    {
                        MessageBox.Show("Impossible de supprimer cet utilisateur.");
                    }
                }
            }
        }

        private User GetSelectedUser()
        {
            if (usersDataGridView.SelectedRows.Count > 0)
            {
                return usersDataGridView.SelectedRows[0].DataBoundItem as User;
            }
            MessageBox.Show("Veuillez sélectionner une ligne.");
            return null;
        }
    }
}