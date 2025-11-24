using fleetmanager.Controllers;
using fleetmanager.Models;
using fleetmanager.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace fleetmanager.Views
{
    public partial class ManageUsers : Form
    {
        private User utilisateurActuel; // L'admin qui est connecté
        private Controller controller;

        public ManageUsers(User user)
        {
            InitializeComponent();
            this.utilisateurActuel = user;
            this.controller = new Controller();

            this.Text = "Gestion des Utilisateurs";
            this.StartPosition = FormStartPosition.CenterScreen;

            ConfigureGrid();

            this.Load += (s, e) => ChargerUtilisateurs();
            this.btnAdd.Click += BtnAdd_Click;
            this.btnEdit.Click += BtnEdit_Click;
            this.btnDelete.Click += BtnDelete_Click;
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

                // Optionnel : Masquer le mot de passe dans la grille pour la sécurité
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // Ouvre le formulaire en mode AJOUT (null)
            UserForm form = new UserForm(null);

            form.FormClosed += (s, args) =>
            {
                this.Show();
                ChargerUtilisateurs(); // Rafraichir après fermeture
            };

            form.ShowDialog(); // ShowDialog bloque la fenêtre parent tant que l'enfant est ouvert
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            User selectedUser = GetSelectedUser();
            if (selectedUser != null)
            {
                // Ouvre le formulaire en mode EDITION
                UserForm form = new UserForm(selectedUser);

                form.FormClosed += (s, args) =>
                {
                    this.Show();
                    ChargerUtilisateurs();
                };

                form.ShowDialog();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            User selectedUser = GetSelectedUser();
            if (selectedUser != null)
            {
                // Sécurité : On empêche de se supprimer soi-même !
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