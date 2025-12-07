using fleetmanager.Controllers;
using fleetmanager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace fleetmanager.Views
{
    public partial class Accueil : Form
    {
        private User utilisateurActuel;
        private Controller appController;

        // Contrôles créés dynamiquement
        private TabControl tabControlPrincipal;
        private Label lblGlobalStats;

        public Accueil(User user)
        {
            InitializeComponent();

            this.utilisateurActuel = user;
            this.appController = new Controller();

            this.Text = "FleetManager - Tableau de Bord - " + utilisateurActuel.Username;

            // 1. Initialisation de l'interface (Onglets positionnés selon votre design)
            InitialiserInterfaceAvancee();

            // 2. Gestion des droits (boutons)
            GererDroitsAcces();

            // 3. Navigation
            this.ajoutUtilisationButton.Click += (s, e) => NaviguerVers(new AjoutUtilisation(this.utilisateurActuel));
            this.vehiculeButton.Click += (s, e) => NaviguerVers(new DisplayVehicule(this.utilisateurActuel));
            this.userButton.Click += (s, e) => NaviguerVers(new ManageUsers(this.utilisateurActuel));

            // 4. Chargement des données
            ChargerToutesLesDonnees();
        }

        private void InitialiserInterfaceAvancee()
        {
            // --- ÉTAPE A : Capturer la position définie dans le Designer ---
            // On récupère les coordonnées que vous avez mises (338, 35) et la taille (944, 618)
            Point locationGrille = dgvResume.Location;
            Size tailleGrille = dgvResume.Size;
            AnchorStyles ancrageGrille = dgvResume.Anchor; // Pour que ça suive si on redimensionne la fenêtre

            // --- ÉTAPE B : Création du TabControl à la place de la grille ---
            tabControlPrincipal = new TabControl
            {
                Location = locationGrille, // On le place exactement au même endroit (338, 35)
                Size = tailleGrille,       // On lui donne la même taille (944, 618)
                Anchor = ancrageGrille,    // On garde le comportement d'ancrage
                Padding = new Point(10, 5)
            };

            // Onglet 1 : Conducteurs
            TabPage tabConducteurs = new TabPage("Par Conducteur");
            tabControlPrincipal.TabPages.Add(tabConducteurs);

            // On déplace votre dgvResume DANS l'onglet
            // À l'intérieur de l'onglet, on veut qu'il remplisse tout l'espace
            dgvResume.Parent = tabConducteurs;
            dgvResume.Dock = DockStyle.Fill;
            // Note : dgvResume perd ses coordonnées (338,35) car il est maintenant relatif à l'onglet,
            // c'est le TabControl qui a pris ses coordonnées sur la fenêtre.
            ConfigurerDesignTableau(dgvResume);

            // Onglet 2 : Véhicules
            TabPage tabVehicules = new TabPage("Par Véhicule");
            DataGridView dgvVehicules = new DataGridView { Name = "dgvVehicules", Dock = DockStyle.Fill };
            ConfigurerDesignTableau(dgvVehicules);
            tabVehicules.Controls.Add(dgvVehicules);
            tabControlPrincipal.TabPages.Add(tabVehicules);

            // Ajout du TabControl au formulaire
            this.Controls.Add(tabControlPrincipal);
            tabControlPrincipal.BringToFront();

            // --- ÉTAPE C : Label des stats globales ---
            // On le place juste au-dessus du tableau (Y - 25 pixels) pour faire propre
            lblGlobalStats = new Label
            {
                Location = new Point(locationGrille.X, Math.Max(0, locationGrille.Y - 25)),
                Size = new Size(tailleGrille.Width, 20),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.DarkSlateBlue,
                Text = "Chargement des statistiques..."
            };
            this.Controls.Add(lblGlobalStats);
            lblGlobalStats.BringToFront();
        }

        private void GererDroitsAcces()
        {
            bool estAdmin = string.Equals(this.utilisateurActuel.Role, "admin", StringComparison.OrdinalIgnoreCase);
            this.ajoutUtilisationButton.Visible = true;
            this.vehiculeButton.Visible = estAdmin;
            this.userButton.Visible = estAdmin;
        }

        private void ConfigurerDesignTableau(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            // On retire les bordures pour un look plus "onglet"
            dgv.BorderStyle = BorderStyle.None;
        }

        private void ChargerToutesLesDonnees()
        {
            // --- 1. CHARGEMENT ONGLET CONDUCTEURS ---
            var statsDistance = appController.GetStatistiquesDistance();
            var statsTrajets = appController.GetStatistiquesTrajets();

            DataTable tableConducteurs = new DataTable();
            tableConducteurs.Columns.Add("Conducteur", typeof(string));
            tableConducteurs.Columns.Add("Trajets", typeof(int));
            tableConducteurs.Columns.Add("Distance (km)", typeof(double));
            tableConducteurs.Columns.Add("Moyenne (km/trajet)", typeof(double));

            var tousLesConducteurs = statsDistance.Keys.Union(statsTrajets.Keys).ToList();

            foreach (var c in tousLesConducteurs)
            {
                double dist = statsDistance.ContainsKey(c) ? statsDistance[c] : 0;
                double nb = statsTrajets.ContainsKey(c) ? statsTrajets[c] : 0;
                double moy = nb > 0 ? Math.Round(dist / nb, 2) : 0;
                tableConducteurs.Rows.Add(c, (int)nb, dist, moy);
            }
            dgvResume.DataSource = tableConducteurs;
            FormaterColonnes(dgvResume);


            // --- 2. CHARGEMENT ONGLET VÉHICULES ---
            DataTable tableVehicules = appController.GetStatistiquesVehiculesDetallees();

            if (tabControlPrincipal.TabPages.Count > 1)
            {
                DataGridView dgvV = tabControlPrincipal.TabPages[1].Controls["dgvVehicules"] as DataGridView;
                if (dgvV != null)
                {
                    dgvV.DataSource = tableVehicules;
                    if (dgvV.Columns["Coût Estimé (€)"] != null)
                    {
                        dgvV.Columns["Coût Estimé (€)"].DefaultCellStyle.Format = "C2";
                        dgvV.Columns["Coût Estimé (€)"].DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                    FormaterColonnes(dgvV);
                }
            }

            // --- 3. STATS GLOBALES ---
            double totalKmFlotte = 0;
            double totalCoutFlotte = 0;

            foreach (DataRow row in tableVehicules.Rows)
            {
                if (row["Distance Totale (km)"] != DBNull.Value)
                    totalKmFlotte += Convert.ToDouble(row["Distance Totale (km)"]);

                if (row["Coût Estimé (€)"] != DBNull.Value)
                    totalCoutFlotte += Convert.ToDouble(row["Coût Estimé (€)"]);
            }

            lblGlobalStats.Text = $"📊 VUE D'ENSEMBLE :   Distance Totale : {totalKmFlotte:N0} km    |    Budget Carburant Est. : {totalCoutFlotte:C2}";
        }

        private void FormaterColonnes(DataGridView dgv)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Name.Contains("km") || col.Name.Contains("Distance"))
                    col.DefaultCellStyle.Format = "N2";
            }
        }

        private void NaviguerVers(Form formCible)
        {
            formCible.FormClosed += (s, args) =>
            {
                this.Show();
                ChargerToutesLesDonnees();
            };
            formCible.Show();
            this.Hide();
        }
    }
}