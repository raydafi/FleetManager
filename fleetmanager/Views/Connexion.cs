using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        }

        private void connexionButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            User userConnecte = appController.TenterConnexion(username, password);

            if (userConnecte != null)
            {
                MessageBox.Show($"Bienvenue, {userConnecte.Username} (Rôle : {userConnecte.Role})");

                Accueil Accueil = new Accueil(userConnecte);
                Accueil.Show();

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
