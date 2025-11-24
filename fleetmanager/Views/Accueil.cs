using fleetmanager.Controllers;
using fleetmanager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LiveCharts; // Nécessaire pour SeriesCollection et ChartValues

namespace fleetmanager.Views
{
    public partial class Accueil : Form
    {
        private User utilisateurActuel;
        private Controller appController;

        // CORRECTION : On écrit le chemin complet pour éviter toute confusion
        private LiveCharts.WinForms.CartesianChart monGraphique;

        public Accueil(User user)
        {
            InitializeComponent();

            this.utilisateurActuel = user;
            this.appController = new Controller();
            this.Text = "FleetManager - Tableau de Bord - " + utilisateurActuel.Username;

            // Vos boutons de navigation
            this.ajoutUtilisationButton.Click += (s, e) => NaviguerVers(new AjoutUtilisation(this.utilisateurActuel));
            this.vehiculeButton.Click += (s, e) => NaviguerVers(new DisplayVehicule(this.utilisateurActuel));
            this.manageUsersButton.Click += (s, e) => NaviguerVers(new ManageUsers(this.utilisateurActuel));

            InitialiserGraphique();

            this.cbChoixGraphique.SelectedIndexChanged += CbChoixGraphique_SelectedIndexChanged;
            if (this.cbChoixGraphique.Items.Count > 0) this.cbChoixGraphique.SelectedIndex = 0;
        }

        private void InitialiserGraphique()
        {
            // CORRECTION : Instanciation explicite du contrôle WinForms
            monGraphique = new LiveCharts.WinForms.CartesianChart();

            // Maintenant, .Dock doit fonctionner car c'est un UserControl
            monGraphique.Dock = DockStyle.Fill;

            // Configuration visuelle de base
            monGraphique.LegendLocation = LegendLocation.Bottom;
            monGraphique.BackColor = System.Drawing.Color.White;

            // Ajout au Panel
            this.panelGraphique.Controls.Add(monGraphique);
        }

        private void CbChoixGraphique_SelectedIndexChanged(object sender, EventArgs e)
        {
            MettreAJourGraphique();
        }

        private void MettreAJourGraphique()
        {
            // Nettoyage
            monGraphique.Series.Clear();
            monGraphique.AxisX.Clear();
            monGraphique.AxisY.Clear();

            Dictionary<string, double> donnees = new Dictionary<string, double>();
            string titreSerie = "";

            // Récupération des données
            if (cbChoixGraphique.Text.Contains("Distance") || cbChoixGraphique.SelectedIndex == 0)
            {
                donnees = appController.GetStatistiquesDistance();
                titreSerie = "Distance (km)";
            }
            else
            {
                donnees = appController.GetStatistiquesTrajets();
                titreSerie = "Nb Trajets";
            }

            if (donnees.Count == 0) return;

            // CORRECTION : Utilisation explicite de LiveCharts.Wpf.ColumnSeries
            // (C'est normal d'utiliser Wpf.ColumnSeries DANS un graphique WinForms)
            var colSeries = new LiveCharts.Wpf.ColumnSeries
            {
                Title = titreSerie,
                Values = new ChartValues<double>(donnees.Values),
                DataLabels = true,
                LabelPoint = point => point.Y.ToString("N0")
            };

            // Ajout de la série (Si ça souligne encore, vérifiez le using LiveCharts tout en haut)
            monGraphique.Series.Add(colSeries);

            // Axes
            monGraphique.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Conducteurs",
                Labels = donnees.Keys.ToList(),
                Separator = new LiveCharts.Wpf.Separator { Step = 1 }
            });

            monGraphique.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                LabelFormatter = value => value.ToString("N0")
            });
        }

        private void NaviguerVers(Form form)
        {
            form.FormClosed += (s, args) =>
            {
                this.Show();
                MettreAJourGraphique();
            };
            form.Show();
            this.Hide();
        }
    }
}