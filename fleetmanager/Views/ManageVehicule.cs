using fleetmanager.Controllers;
using fleetmanager.Models;
using System;
using System.Windows.Forms;

namespace fleetmanager.Views
{
    public partial class ManageVehicule : Form
    {
        private User utilisateurActuel;
        private Controller controller;

        // Ce champ stockera le véhicule si on est en modification (sera null si ajout)
        private Vehicule vehiculeEdite;
        private bool estEnModeEdition;

        public ManageVehicule(User user, Vehicule vehicule)
        {
            InitializeComponent();

            this.utilisateurActuel = user;
            this.vehiculeEdite = vehicule;
            this.controller = new Controller();

            // Détermine si on ajoute ou on modifie
            this.estEnModeEdition = (vehicule != null);

            SetupForm();
        }

        private void SetupForm()
        {
            // Configuration visuelle
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Abonnement aux boutons
            this.btnValider.Click += BtnValider_Click;
            this.btnAnnuler.Click += BtnAnnuler_Click;

            if (estEnModeEdition)
            {
                this.Text = "Modifier un véhicule";
                RemplirChamps();

                // On interdit la modification de l'ID (Immatriculation) en mode édition
                // car c'est la clé primaire dans la base de données
                txtImmatriculation.Enabled = false;
            }
            else
            {
                this.Text = "Ajouter un nouveau véhicule";
                txtImmatriculation.Enabled = true;
            }
        }

        private void RemplirChamps()
        {
            txtImmatriculation.Text = vehiculeEdite.Immatriculation;
            txtModele.Text = vehiculeEdite.Modele;
            txtDescription.Text = vehiculeEdite.Description;
            numKilometrage.Value = vehiculeEdite.KilometrageTotal;
            numPrix.Value = vehiculeEdite.PrixLitre;
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            // 1. Récupération des valeurs
            string immat = txtImmatriculation.Text.Trim();
            string modele = txtModele.Text.Trim();
            string desc = txtDescription.Text.Trim();
            int km = (int)numKilometrage.Value;
            decimal prix = numPrix.Value;

            // 2. Validation basique
            if (string.IsNullOrEmpty(immat) || string.IsNullOrEmpty(modele))
            {
                MessageBox.Show("L'immatriculation et le modèle sont obligatoires.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool succes = false;

            try
            {
                // 3. Appel au contrôleur
                if (estEnModeEdition)
                {
                    // MODE MODIFICATION
                    succes = controller.ModifierVehicule(immat, modele, desc, km, prix);
                }
                else
                {
                    // MODE AJOUT
                    succes = controller.AjouterVehicule(immat, modele, desc, km, prix);
                }

                // 4. Gestion du résultat
                if (succes)
                {
                    string action = estEnModeEdition ? "modifié" : "ajouté";
                    MessageBox.Show($"Véhicule {action} avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Ferme le formulaire et revient au tableau
                }
                else
                {
                    MessageBox.Show("Une erreur est survenue lors de l'enregistrement en base de données.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur technique : " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close(); // Ferme simplement la fenêtre
        }
    }
}