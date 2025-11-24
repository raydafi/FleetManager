using fleetmanager.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;

namespace fleetmanager.Services
{
    public class DataService
    {
        private static string cnxString = "Server=localhost;Database=fleetmanager;Uid=root;Pwd=;";


        // ---------------------------- USERS ----------------------------
        // Méthode sélection users
        public List<User> SelectUsers()
        {
            var userList = new List<User>();
            string req = "SELECT user_id, username, password, role FROM users";

            using (var msc = new MySqlConnection(cnxString))
            {
                try
                {
                    msc.Open();
                    using (var cmd = new MySqlCommand(req, msc))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new User
                            {
                                UserId = reader.GetInt32("user_id"),
                                Username = reader.GetString("username"),
                                Password = reader.GetString("password"),
                                Role = reader.GetString("role")
                            };
                            userList.Add(user);
                        }
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("Erreur SQL (SelectUsers): " + e.Message);
                }
            }
            return userList;
        }

        // Méthode insertion users
        public bool InsertUser(string username, string password, string role)
        {
            string req = "INSERT INTO users (username, password, role) VALUES (@username, @password, @role)";

            using (var msc = new MySqlConnection(cnxString))
            {
                try
                {
                    msc.Open();
                    using (var insert = new MySqlCommand(req, msc))
                    {
                        insert.Parameters.AddWithValue("@username", username);
                        insert.Parameters.AddWithValue("@password", password);
                        insert.Parameters.AddWithValue("@role", role);

                        int rowsAffected = insert.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("Erreur SQL (InsertUser): " + e.Message);
                    return false;
                }
            }
        }
        public bool DeleteUser(int userId)
        {
            string req = "DELETE FROM users WHERE user_id = @user_id";
            using (var msc = new MySqlConnection(cnxString))
            {
                try
                {
                    msc.Open();
                    using (var delete = new MySqlCommand(req, msc))
                    {
                        delete.Parameters.AddWithValue("@user_id", userId);
                        int rowsAffected = delete.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("Erreur SQL (DeleteUser): " + e.Message);
                    return false;
                }
            }
        }

        // Méthode mise à jour users
        public bool UpdateUser(int userId, string username, string password, string role)
        {
            string req = "UPDATE users SET username = @username, password = @password, role = @role WHERE user_id = @user_id";
            using (var msc = new MySqlConnection(cnxString))
            {
                try
                {
                    msc.Open();
                    using (var update = new MySqlCommand(req, msc))
                    {
                        update.Parameters.AddWithValue("@user_id", userId);
                        update.Parameters.AddWithValue("@username", username);
                        update.Parameters.AddWithValue("@password", password);
                        update.Parameters.AddWithValue("@role", role);
                        int rowsAffected = update.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("Erreur SQL (UpdateUser): " + e.Message);
                    return false;
                }
            }
        }


        public User ValiderUtilisateur(string username, string password)
        {
            string req = "SELECT user_id, username, role FROM users WHERE username = @username AND password = @password";

            using (var msc = new MySqlConnection(cnxString))
            {
                try
                {
                    msc.Open();
                    using (var cmd = new MySqlCommand(req, msc))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User
                                {
                                    UserId = reader.GetInt32("user_id"),
                                    Username = reader.GetString("username"),
                                    Role = reader.GetString("role")
                                };
                            }
                        }
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("Erreur SQL (ValiderUtilisateur): " + e.Message);
                }
            }
            return null;
        }

        // ---------------------------- VEHICULES ----------------------------
        // Méthode sélection véhicules
        public List<Vehicule> SelectVehicules()
        {
            var vehiculeList = new List<Vehicule>();
            string req = "SELECT immatriculation, modele, description, kilometrage_total, prix_litre FROM vehicules";

            using (var msc = new MySqlConnection(cnxString))
            {
                try
                {
                    msc.Open();
                    using (var cmd = new MySqlCommand(req, msc))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var vehicule = new Vehicule
                            {
                                Immatriculation = reader.GetString("immatriculation"),
                                Modele = reader.GetString("modele"),
                                Description = reader.GetString("description"),
                                KilometrageTotal = reader.GetInt32("kilometrage_total"),
                                PrixLitre = reader.GetDecimal("prix_litre")
                            };
                            vehiculeList.Add(vehicule);
                        }
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("Erreur SQL (SelectVehicule): " + e.Message);
                }
            }
            return vehiculeList;
        }

        // Méthode insertion véhicules
        public bool InsertVehicule(string immatriculation, string modele, string description, int kilometrageTotal, decimal prixLitre)
        {
            string req = "INSERT INTO vehicules (immatriculation, modele, description, kilometrage_total, prix_litre) " +
                         "VALUES (@immatriculation, @modele, @description, @kilometrage_total, @prix_litre)";
            using (var msc = new MySqlConnection(cnxString))
            {
                try
                {
                    msc.Open();
                    using (var insert = new MySqlCommand(req, msc))
                    {
                        insert.Parameters.AddWithValue("@immatriculation", immatriculation);
                        insert.Parameters.AddWithValue("@modele", modele);
                        insert.Parameters.AddWithValue("@description", description);
                        insert.Parameters.AddWithValue("@kilometrage_total", kilometrageTotal);
                        insert.Parameters.AddWithValue("@prix_litre", prixLitre);
                        int rowsAffected = insert.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("Erreur SQL (InsertVehicule): " + e.Message);
                    return false;
                }
            }
        }

        // Méthode suppression véhicules
        public bool DeleteVehicule(string immatriculation)
        {
            string req = "DELETE FROM vehicules WHERE immatriculation = @immatriculation";
            using (var msc = new MySqlConnection(cnxString))
            {
                try
                {
                    msc.Open();
                    using (var delete = new MySqlCommand(req, msc))
                    {
                        delete.Parameters.AddWithValue("@immatriculation", immatriculation);
                        int rowsAffected = delete.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("Erreur SQL (DeleteVehicule): " + e.Message);
                    return false;
                }
            }
        }
        // Méthode mise à jour véhicules
        public bool UpdateVehicule(string immatriculation, string modele, string description, int kilometrageTotal, decimal prixLitre)
        {
            string req = "UPDATE vehicules SET modele = @modele, description = @description, " +
                         "kilometrage_total = @kilometrage_total, prix_litre = @prix_litre WHERE immatriculation = @immatriculation";
            using (var msc = new MySqlConnection(cnxString))
            {
                try
                {
                    msc.Open();
                    using (var update = new MySqlCommand(req, msc))
                    {
                        update.Parameters.AddWithValue("@immatriculation", immatriculation);
                        update.Parameters.AddWithValue("@modele", modele);
                        update.Parameters.AddWithValue("@description", description);
                        update.Parameters.AddWithValue("@kilometrage_total", kilometrageTotal);
                        update.Parameters.AddWithValue("@prix_litre", prixLitre);
                        int rowsAffected = update.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("Erreur SQL (UpdateVehicule): " + e.Message);
                    return false;
                }
            }
        }
        public MySqlConnection GetConnection()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(cnxString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                // Relance l'exception pour que le formulaire puisse l'attraper
                throw new Exception($"Erreur de connexion (DataService.GetConnection) : {ex.Message}", ex);
            }
        }
        // --- GESTION DES UTILISATIONS ---
        public bool InsertUtilisation(int userId, string immatriculation, DateTime debut, DateTime fin, int distance, string commentaire)
        {
            string req = "INSERT INTO utilisations (user_id, immatriculation, date_debut, date_fin, distance, commentaire) " +
                         "VALUES (@userId, @immat, @debut, @fin, @distance, @com)";

            using (var msc = new MySqlConnection(cnxString))
            {
                try
                {
                    msc.Open();
                    using (var cmd = new MySqlCommand(req, msc))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@immat", immatriculation);
                        cmd.Parameters.AddWithValue("@debut", debut);
                        cmd.Parameters.AddWithValue("@fin", fin);
                        cmd.Parameters.AddWithValue("@distance", distance);
                        cmd.Parameters.AddWithValue("@com", commentaire);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("Erreur SQL (InsertUtilisation): " + e.Message);
                    return false;
                }
            }
        }
        // --- STATISTIQUES POUR LE GRAPHIQUE ---

        // 1. Distance totale par utilisateur
        public Dictionary<string, double> GetDistanceParUser()
        {
            var stats = new Dictionary<string, double>();
            // On joint la table 'utilisations' avec 'users' pour avoir le nom
            string req = "SELECT u.username, SUM(ut.distance) as total " +
                         "FROM utilisations ut " +
                         "JOIN users u ON ut.user_id = u.user_id " +
                         "GROUP BY u.username";

            using (var msc = new MySqlConnection(cnxString))
            {
                try
                {
                    msc.Open();
                    using (var cmd = new MySqlCommand(req, msc))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string user = reader.GetString("username");
                            // On gère le cas où total est null
                            double val = reader.IsDBNull(reader.GetOrdinal("total")) ? 0 : reader.GetDouble("total");
                            stats.Add(user, val);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erreur Stat Distance: " + e.Message);
                }
            }
            return stats;
        }

        // 2. Nombre de trajets par utilisateur
        public Dictionary<string, double> GetTrajetsParUser()
        {
            var stats = new Dictionary<string, double>();
            string req = "SELECT u.username, COUNT(ut.id) as total " +
                         "FROM utilisations ut " +
                         "JOIN users u ON ut.user_id = u.user_id " +
                         "GROUP BY u.username";

            using (var msc = new MySqlConnection(cnxString))
            {
                try
                {
                    msc.Open();
                    using (var cmd = new MySqlCommand(req, msc))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            stats.Add(reader.GetString("username"), reader.GetInt32("total"));
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erreur Stat Trajets: " + e.Message);
                }
            }
            return stats;
        }
    }
}