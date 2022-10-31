using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationGestionGarage_FAUCHERY
{
    class Camion : Vehicule
    {
        public int nbEssieu { get; set; }
        public int poids { get; set; }
        public int volume { get; set; }

        public Camion(string nom, float prixHT, Marque marque, Moteur moteur, int nbEssieu, int poids, int volume) : base(nom, prixHT, marque, moteur)
        {
            this.nbEssieu = nbEssieu;
            this.poids = poids;
            this.volume = volume;
            this.nom = nom;
            this.prixHT = prixHT;
            this.marque = marque;
            this.moteur = moteur;
        }
        public override void Afficher()
        {
            Console.WriteLine("Véhicule n°" + id + " : Camion\n");
            Console.WriteLine("Nom : " + nom);
            Console.WriteLine("Marque : " + marque);
            Console.WriteLine("Prix hors taxe : " + prixHT +" €");
            Console.WriteLine("Poids : " + poids + " T");
            Console.WriteLine("Volume : " + volume + " L");
            Console.WriteLine("Nombre d'essieux : " + nbEssieu);
            Console.WriteLine("\n");
        }

        public override float CalculerTaxe()
        {
            return nbEssieu * 50;
        }
    }
}
