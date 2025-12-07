using fleetmanager.Controllers;
using fleetmanager.Models;
using System;
using System.Windows.Forms;
using BCrypt.Net; // Assurez-vous d'avoir ce using (ou BCrypt.Net-Next)

namespace fleetmanager.Views
{
    public partial class UserForm : Form
    {
        private Controller controller;
        private User userEdite;
        private bool estEnModeEdition;

        public UserForm(User userToEdit)
        {
            InitializeComponent();
            this.controller = new Controller();
            this.userEdite = userToEdit;
            this.estEnModeEdition = (userToEdit != null);

            SetupForm();
        }

        private void SetupForm()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Remplissage de la ComboBox des rôles
            if (cbRole.Items.Count == 0)
            {
                cbRole.Items.Add("admin");
                cbRole.Items.Add("user");
                cbRole.Items.Add("manager");
            }
            cbRole.DropDownStyle = ComboBoxStyle.DropDownList;

            // Nettoyage des événements pour éviter les doublons
            this.btnValider.Click -= btnValider_Click;
            this.btnValider.Click += btnValider_Click;

            this.btnAnnuler.Click -= (s, e) => this.Close(); // Nettoyage au cas où
            this.btnAnnuler.Click += (s, e) => this.Close();

            if (estEnModeEdition)
            {
                this.Text = "Modifier un utilisateur";
                txtUsername.Text = userEdite.Username;

                // --- CORRECTION IMPORTANTE ---
                // On n'affiche PAS le mot de passe actuel car c'est un hash ($2a$11$...).
                // On laisse le champ vide. Si l'utilisateur tape dedans, c'est qu'il veut changer.
                txtPassword.Text = "";
                txtPassword.PlaceholderText = "Laisser vide pour ne pas changer"; // (Si .NET 5+ sinon utiliser un label)

                cbRole.SelectedItem = userEdite.Role;
            }
            else
            {
                this.Text = "Créer un utilisateur";
                cbRole.SelectedIndex = 1; // "user" par défaut
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string rawPassword = txtPassword.Text.Trim(); // Le mot de passe en clair tapé
            string role = cbRole.SelectedItem?.ToString();
            string passwordToSend = "";

            // 1. Validation de base
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Le nom d'utilisateur et le rôle sont obligatoires.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Gestion du Hachage du mot de passe
            if (estEnModeEdition)
            {
                if (string.IsNullOrEmpty(rawPassword))
                {
                    // L'utilisateur a laissé le champ vide => On garde l'ancien hash
                    passwordToSend = userEdite.Password;
                }
                else
                {
                    // L'utilisateur a tapé un nouveau mot de passe => On le hash
                    passwordToSend = BCrypt.Net.BCrypt.HashPassword(rawPassword);
                }
            }
            else // Mode Création
            {
                if (string.IsNullOrEmpty(rawPassword))
                {
                    MessageBox.Show("Le mot de passe est obligatoire pour un nouvel utilisateur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // On hash le nouveau mot de passe
                passwordToSend = BCrypt.Net.BCrypt.HashPassword(rawPassword);
            }

            // 3. Envoi au contrôleur
            bool succes;

            try
            {
                if (estEnModeEdition)
                {
                    // Update
                    succes = controller.ModifierUtilisateur(userEdite.UserId, username, passwordToSend, role);
                }
                else
                {
                    // Insert
                    succes = controller.CreerNouvelUtilisateur(username, passwordToSend, role);
                }

                if (succes)
                {
                    MessageBox.Show("Opération réussie !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Indique au parent (ManageUsers) que tout s'est bien passé
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'enregistrement en base.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur technique : " + ex.Message);
            }
        }
    }
}