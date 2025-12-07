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

        // Dans Controller.cs
        public User TenterConnexion(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) return null;

            // 1. Récupérer l'utilisateur par son pseudo
            User user = dataService.GetUserByUsername(username);

            if (user == null) return null;

            // --- CORRECTION DU BUG ---

            // Étape A : On essaie de vérifier si c'est un Hash valide
            try
            {
                if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    return user; // C'est un bon hash, connexion réussie !
                }
            }
            catch (BCrypt.Net.SaltParseException)
            {
                // Si on arrive ici, c'est que user.Password (ex: "1234") n'est PAS un hash.
                // On ignore l'erreur et on continue vers l'étape B pour voir si c'est du texte clair.
            }

            // Étape B : Migration (Texte clair -> Hash)
            // On vérifie si le mot de passe correspond au texte clair
            if (user.Password == password)
            {
                // C'est le bon mot de passe, mais il n'était pas crypté.
                // 1. On le crypte
                string passwordHashed = BCrypt.Net.BCrypt.HashPassword(password);

                // 2. On met à jour la base de données pour la prochaine fois
                dataService.UpdatePassword(user.UserId, passwordHashed);

                // 3. On met à jour l'objet en mémoire
                user.Password = passwordHashed;

                return user;
            }

            // Si ni le hash ni le texte clair ne correspondent
            return null;
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
        // Dans fleetmanager.Controllers.Controller

        public DataTable GetStatistiquesVehiculesDetallees()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Immatriculation", typeof(string));
            table.Columns.Add("Modèle", typeof(string));
            table.Columns.Add("Distance Totale (km)", typeof(double));
            table.Columns.Add("Nb Trajets", typeof(int));
            table.Columns.Add("Coût Estimé (€)", typeof(double));

            using (var conn = dataService.GetConnection())
            {
                // --- MODIFICATION ICI : Table 'utilisations' ---
                string query = @"
            SELECT 
                v.immatriculation, 
                v.modele, 
                v.prix_litre,
                COUNT(u.id) as nb_trajets, 
                SUM(u.distance) as total_distance
            FROM vehicules v
            LEFT JOIN utilisations u ON v.immatriculation = u.immatriculation
            GROUP BY v.immatriculation, v.modele, v.prix_litre";

                using (var cmd = new MySqlConnector.MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string immat = reader.GetString("immatriculation");
                        string modele = reader.GetString("modele");

                        // On gère les NULL si le véhicule n'a jamais été utilisé
                        double dist = reader.IsDBNull(reader.GetOrdinal("total_distance")) ? 0 : reader.GetDouble("total_distance");
                        int nb = reader.IsDBNull(reader.GetOrdinal("nb_trajets")) ? 0 : reader.GetInt32("nb_trajets");
                        double prixLitre = reader.GetDouble("prix_litre");

                        // Calcul du coût (Moyenne 7L/100km * PrixLitre * Distance)
                        double consommationMoyenne = 7.0;
                        double cout = (dist / 100.0) * consommationMoyenne * prixLitre;

                        table.Rows.Add(immat, modele, dist, nb, Math.Round(cout, 2));
                    }
                }
            }
            return table;
        }
    }
}