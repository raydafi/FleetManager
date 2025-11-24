using fleetmanager.Controllers;
using fleetmanager.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace fleetmanager.Views
{
    public partial class AjoutUtilisation : Form
    {
        private User utilisateurActuel;
        private Controller controller;

        public AjoutUtilisation(User user)
        {
            InitializeComponent();
            this.utilisateurActuel = user;
            this.controller = new Controller();

            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "Nouvelle déclaration d'utilisation";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Configuration des dates (Format français avec heures)
            dtpDebut.Format = DateTimePickerFormat.Custom;
            dtpDebut.CustomFormat = "dd/MM/yyyy HH:mm";

            dtpFin.Format = DateTimePickerFormat.Custom;
            dtpFin.CustomFormat = "dd/MM/yyyy HH:mm";

            // Par défaut, fin = maintenant, début = il y a 1 heure
            dtpFin.Value = DateTime.Now;
            dtpDebut.Value = DateTime.Now.AddHours(-1);

            // Charger les véhicules dans la liste déroulante
            ChargerVehicules();

            this.btnValider.Click += BtnValider_Click;
            this.btnAnnuler.Click += (s, e) => this.Close();
        }

        private void ChargerVehicules()
        {
            try
            {
                List<Vehicule> vehicules = controller.GetTousLesVehicules();

                // On lie la liste d'objets directement à la ComboBox
                cbVehicules.DataSource = vehicules;

                // Ce qu'on affiche à l'utilisateur
                cbVehicules.DisplayMember = "Immatriculation"; // Ou "Immatriculation" selon ta préférence

                // La valeur cachée qu'on récupérera (la clé primaire)
                cbVehicules.ValueMember = "Immatriculation";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de charger la liste des véhicules : " + ex.Message);
            }
        }

        private void BtnValider_Click(object sender, EventArgs e)
        {
            // 1. Vérifier qu'un véhicule est choisi
            if (cbVehicules.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un véhicule.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Récupérer les données
            string immatriculation = cbVehicules.SelectedValue.ToString();
            DateTime debut = dtpDebut.Value;
            DateTime fin = dtpFin.Value;
            int distance = (int)numDistance.Value;
            string commentaire = txtCommentaire.Text.Trim();

            // 3. Appel au contrôleur
            try
            {
                bool success = controller.EnregistrerUtilisation(
                    this.utilisateurActuel.UserId, // On utilise l'ID de celui qui est connecté
                    immatriculation,
                    debut,
                    fin,
                    distance,
                    commentaire
                );

                if (success)
                {
                    MessageBox.Show("Utilisation enregistrée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Retour au menu principal
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'enregistrement.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ArgumentException argEx)
            {
                // Erreur de logique (ex: date fin < date début)
                MessageBox.Show(argEx.Message, "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Erreur technique (ex: base de données)
                MessageBox.Show("Erreur technique : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}