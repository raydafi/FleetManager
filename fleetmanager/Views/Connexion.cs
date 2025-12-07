using System;
using System.Windows.Forms;
using fleetmanager.Controllers;
using fleetmanager.Models;

namespace fleetmanager.Views
{
    public partial class Connexion : Form
    {
        private Controller appController;

        public Connexion()
        {
            InitializeComponent();
            appController = new Controller();

            // Petit bonus : appuyer sur "Entrée" dans le champ mot de passe déclenche la connexion
            this.passwordTextBox.KeyPress += (s, e) => { if (e.KeyChar == (char)Keys.Enter) connexionButton.PerformClick(); };
        }

        private void connexionButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            // Appel au contrôleur qui gère désormais :
            // 1. La vérification BCrypt
            // 2. La mise à jour automatique si le mot de passe était en clair
            User userConnecte = appController.TenterConnexion(username, password);

            if (userConnecte != null)
            {
                MessageBox.Show($"Bienvenue, {userConnecte.Username} (Rôle : {userConnecte.Role})");

                Accueil accueilForm = new Accueil(userConnecte);
                accueilForm.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.",
                                "Erreur de connexion",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}