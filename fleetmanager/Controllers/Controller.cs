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
using fleetmanager.Models;
using fleetmanager.Services;
using MySqlConnector;

namespace fleetmanager.Controllers
{
    // Doit être 'public' pour être vu par vos formulaires (Views)
    public class Controller
    {
        private DataService dataService;

        public Controller()
        {
            this.dataService = new DataService();
        }

        // --- Vos méthodes User (inchangées) ---

        public List<User> GetTousLesUtilisateurs()
        {
            return dataService.SelectUsers();
        }

        public bool CreerNouvelUtilisateur(string username, string password, string role)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }
            return dataService.InsertUser(username, password, role);
        }
        public bool ModifierUtilisateur(int id, string username, string password, string role)
        {
            return dataService.UpdateUser(id, username, password, role);
        }

        public bool SupprimerUtilisateur(int id)
        {
            return dataService.DeleteUser(id);
        }

        public User TenterConnexion(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }
            return dataService.ValiderUtilisateur(username, password);
        }

        // --- NOUVELLES MÉTHODES AJOUTÉES ---

        /// <summary>
        /// Récupère la liste des noms de tables de la base de données.
        /// </summary>
        public List<string> GetTableNames()
        {
            var tableList = new List<string>();
            // Le contrôleur gère la connexion
            // (il utilise la méthode GetConnection() que nous avons ajoutée à DataService)
            using (var conn = dataService.GetConnection())
            {
                string query = "SELECT table_name FROM information_schema.tables WHERE table_schema = DATABASE() ORDER BY table_name";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tableList.Add(reader.GetString(0));
                    }
                }
            }
            return tableList;
        }

        /// <summary>
        /// Récupère toutes les données d'une table spécifique.
        /// </summary>
        public DataTable GetTableData(string tableName)
        {
            var dataTable = new DataTable();
            using (var conn = dataService.GetConnection())
            {
                string query = $"SELECT * FROM `{tableName}`";
                using (var adapter = new MySqlDataAdapter(query, conn))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        // --- MÉTHODES VÉHICULES (À ajouter dans Controller.cs) ---
        public List<Vehicule> GetTousLesVehicules()
        {
            return dataService.SelectVehicules();
        }

        public bool SupprimerVehicule(string immatriculation)
        {
            return dataService.DeleteVehicule(immatriculation);
        }

        public bool AjouterVehicule(string immatriculation, string modele, string description, int km, decimal prix)
        {
            return dataService.InsertVehicule(immatriculation, modele, description, km, prix);
        }

        public bool ModifierVehicule(string immatriculation, string modele, string description, int km, decimal prix)
        {
            return dataService.UpdateVehicule(immatriculation, modele, description, km, prix);
        }
        // --- MÉTHODE AJOUT UTILISATION ---
        public bool EnregistrerUtilisation(int userId, string immatriculation, DateTime debut, DateTime fin, int distance, string commentaire)
        {
            // Vérification logique : la fin ne peut pas être avant le début
            if (fin < debut)
            {
                throw new ArgumentException("La date de fin ne peut pas être antérieure à la date de début.");
            }

            if (distance < 0)
            {
                throw new ArgumentException("La distance ne peut pas être négative.");
            }

            return dataService.InsertUtilisation(userId, immatriculation, debut, fin, distance, commentaire);
        }
        // --- MÉTHODES STATISTIQUES ---
        public Dictionary<string, double> GetStatistiquesDistance()
        {
            return dataService.GetDistanceParUser();
        }

        public Dictionary<string, double> GetStatistiquesTrajets()
        {
            return dataService.GetTrajetsParUser();
        }
    }
}