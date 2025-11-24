using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace fleetmanager.Models
{
    public class Vehicule
    {
        public string Immatriculation { get; set; }
        public string Modele { get; set; }
        public string Description { get; set; }
        public int KilometrageTotal { get; set; }
        public decimal PrixLitre { get; set; }
    }
}
