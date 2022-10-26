using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationGestionGarage_FAUCHERY
{
    class Moteur
    {
        public static int id { get; set; }
        public string nom { get; set; }
        public int puissance { get; set; }
        public TypeMoteur typeMoteur { get; set; }

        public Moteur(string nom, int puissance, TypeMoteur typeMoteur)
        {
            id++;
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
