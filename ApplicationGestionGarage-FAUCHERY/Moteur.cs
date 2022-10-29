using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationGestionGarage_FAUCHERY
{
    class Moteur
    {
        private static int idIncrement { get; set; }
        public int id { get; }
        public string nom { get; set; }
        public int puissance { get; set; }
        public TypeMoteur typeMoteur { get; set; }

        public Moteur(string nom, int puissance, TypeMoteur typeMoteur)
        {
            idIncrement++;
            id = idIncrement;
            this.nom = nom;
            this.puissance = puissance;
            this.typeMoteur = typeMoteur;
        }

        public void Afficher()
        {
            Console.WriteLine("Moteur n°" + id + " :\n");
            Console.WriteLine("Nom : " + nom);
            Console.WriteLine("Puissance : " + puissance +"CH");
            Console.WriteLine("Type de moteur : " + typeMoteur);
            Console.WriteLine("\n");
        }
    }
}
