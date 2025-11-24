using fleetmanager.Controllers;
using fleetmanager.Models;
using System;
using System.Windows.Forms;

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
            cbRole.DropDownStyle = ComboBoxStyle.DropDownList; // Force la sélection

            this.btnValider.Click += btnValider_Click;
            this.btnAnnuler.Click += (s, e) => this.Close();

            if (estEnModeEdition)
            {
                this.Text = "Modifier un utilisateur";
                txtUsername.Text = userEdite.Username;
                txtPassword.Text = userEdite.Password;
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
            string password = txtPassword.Text.Trim();
            string role = cbRole.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Tous les champs sont obligatoires.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool succes;

            try
            {
                if (estEnModeEdition)
                {
                    // Update
                    succes = controller.ModifierUtilisateur(userEdite.UserId, username, password, role);
                }
                else
                {
                    // Insert
                    succes = controller.CreerNouvelUtilisateur(username, password, role);
                }

                if (succes)
                {
                    MessageBox.Show("Opération réussie !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btnAnnuler_Click(object sender, EventArgs e)
        {

        }
    }
}