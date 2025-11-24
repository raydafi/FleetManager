using fleetmanager.Controllers;
using fleetmanager.Models;
using fleetmanager.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace fleetmanager.Views
{
    public partial class DisplayVehicule : Form
    {
        private User utilisateurActuel;
        private Controller controller;

        public DisplayVehicule(User user)
        {
            InitializeComponent();

            this.utilisateurActuel = user;
            this.controller = new Controller();

            // Configuration de la fenêtre
            this.Text = "Gestion de la Flotte - Liste des véhicules";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Configuration du DataGridView pour une meilleure ergonomie
            ConfigureDataGridView();

            // Abonnement aux événements
            this.Load += DisplayVehicule_Load;
            this.ajouterButton.Click += ajouterButton_Click;
            this.modifierButton.Click += modifierButton_Click;
            this.supprimerButton.Click += supprimerButton_Click;
        }

        private void ConfigureDataGridView()
        {
            // Permet de sélectionner toute la ligne d'un coup
            vehiculesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            vehiculesDataGridView.MultiSelect = false; // Une seule ligne à la fois
            vehiculesDataGridView.ReadOnly = true; // Pas d'édition directe dans le tableau
            vehiculesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Remplit la largeur
            vehiculesDataGridView.AllowUserToAddRows = false; // Enlève la ligne vide en bas
        }

        private void DisplayVehicule_Load(object sender, EventArgs e)
        {
            ChargerLesVehicules();
        }

        private void ChargerLesVehicules()
        {
            try
            {
                List<Vehicule> vehicules = controller.GetTousLesVehicules();
                vehiculesDataGridView.DataSource = vehicules;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des véhicules : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ajouterButton_Click(object sender, EventArgs e)
        {
            // On ouvre ManageVehicule en mode AJOUT (on passe null pour le véhicule)
            // Note: Assurez-vous que le constructeur de ManageVehicule accepte (User, Vehicule)
            ManageVehicule manageForm = new ManageVehicule(this.utilisateurActuel, null);

            manageForm.FormClosed += (s, args) =>
            {
                this.Show();
                ChargerLesVehicules(); // Rafraichir la liste au retour
            };

            manageForm.Show();
            this.Hide();
        }

        private void modifierButton_Click(object sender, EventArgs e)
        {
            Vehicule vehiculeSelectionne = GetSelectedVehicule();

            if (vehiculeSelectionne != null)
            {
                // On ouvre ManageVehicule en mode EDITION (on passe le véhicule sélectionné)
                ManageVehicule manageForm = new ManageVehicule(this.utilisateurActuel, vehiculeSelectionne);

                manageForm.FormClosed += (s, args) =>
                {
                    this.Show();
                    ChargerLesVehicules(); // Rafraichir la liste au retour pour voir les modifs
                };

                manageForm.Show();
                this.Hide();
            }
        }

        private void supprimerButton_Click(object sender, EventArgs e)
        {
            Vehicule vehiculeSelectionne = GetSelectedVehicule();

            if (vehiculeSelectionne != null)
            {
                // Demande de confirmation
                var resultat = MessageBox.Show(
                    $"Êtes-vous sûr de vouloir supprimer le véhicule {vehiculeSelectionne.Modele} ({vehiculeSelectionne.Immatriculation}) ?",
                    "Confirmer la suppression",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resultat == DialogResult.Yes)
                {
                    try
                    {
                        bool succes = controller.SupprimerVehicule(vehiculeSelectionne.Immatriculation);
                        if (succes)
                        {
                            MessageBox.Show("Véhicule supprimé avec succès.");
                            ChargerLesVehicules(); // Mise à jour du tableau
                        }
                        else
                        {
                            MessageBox.Show("Impossible de supprimer le véhicule. Vérifiez qu'il n'est pas utilisé ailleurs.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur lors de la suppression : " + ex.Message);
                    }
                }
            }
        }

        // Méthode utilitaire pour récupérer l'objet Vehicule de la ligne sélectionnée
        private Vehicule GetSelectedVehicule()
        {
            if (vehiculesDataGridView.SelectedRows.Count > 0)
            {
                // On récupère l'objet lié à la ligne
                return vehiculesDataGridView.SelectedRows[0].DataBoundItem as Vehicule;
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne dans le tableau.", "Aucune sélection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }
    }
}