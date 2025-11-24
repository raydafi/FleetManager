using System;

namespace fleetmanager.Models
{
    public class Utilisation
    {
        public int Id { get; set; }
        public int UserId { get; set; } // L'ID du conducteur
        public string Immatriculation { get; set; } // Le lien vers le véhicule
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int DistanceParcourue { get; set; }
        public string Commentaire { get; set; }
    }
}