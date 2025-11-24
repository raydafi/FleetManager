using fleetmanager.Controllers;
using fleetmanager.Models;
using fleetmanager.Views;
using fleetmanager.Services;
using System;
using System.Windows.Forms;

namespace fleetmanager.Views
{
    public partial class Accueil : Form
    {
        private User utilisateurActuel;

        private Controller appController;

        public Accueil(User user)
        {
            InitializeComponent();

            this.utilisateurActuel = user;
            this.appController = new Controller();

            this.Text = "FleetManager - Menu Principal - Connecté : " + utilisateurActuel.Username;

            // Abonnement aux événements des nouveaux boutons
            this.ajoutUtilisationButton.Click += new EventHandler(ajoutUtilisationButton_Click);
            this.vehiculeButton.Click += new EventHandler(vehiculeButton_Click);
            this.manageUsersButton.Click += new EventHandler(manageUsersButton_Click);
        }

        // --- Navigation vers AjoutUtilisation ---
        private void ajoutUtilisationButton_Click(object sender, EventArgs e)
        {
            // On passe l'utilisateur actuel au nouveau formulaire pour garder la session
            AjoutUtilisation form = new AjoutUtilisation(this.utilisateurActuel);

            // Astuce : Quand on ferme la fenêtre enfant, on ré-affiche l'accueil
            form.FormClosed += (s, args) => this.Show();

            form.Show();
            this.Hide(); // On cache le menu principal
        }

        // --- Navigation vers DisplayVehicule ---
        private void vehiculeButton_Click(object sender, EventArgs e)
        {
            DisplayVehicule form = new DisplayVehicule(this.utilisateurActuel);

            form.FormClosed += (s, args) => this.Show();

            form.Show();
            this.Hide();
        }

        // --- Navigation vers ManageUsers ---
        private void manageUsersButton_Click(object sender, EventArgs e)
        {
            // Ici, tu pourrais ajouter une sécurité (ex: if (!user.IsAdmin) return;)
            ManageUsers form = new ManageUsers(this.utilisateurActuel);

            form.FormClosed += (s, args) => this.Show();

            form.Show();
            this.Hide();
        }
    }
}