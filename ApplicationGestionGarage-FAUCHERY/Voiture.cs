using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationGestionGarage_FAUCHERY
{
    [Serializable]
    class Voiture : Vehicule
    {
        public int chevauxFiscaux { get; set; }
        public int nbPorte { get; set; }
        public int nbSiege { get; set; }
        public int tailleCoffre { get; set; }

        public Voiture(string nom, float prixHT, Marque marque, Moteur moteur, int chevauxFiscaux, int nbPorte, int nbSiege, int tailleCoffre) : base(nom, prixHT, marque, moteur)
        {
            this.chevauxFiscaux = chevauxFiscaux;
            this.nbPorte = nbPorte;
            this.nbSiege = nbSiege;
            this.tailleCoffre = tailleCoffre;
            this.nom = nom;
            this.prixHT = prixHT;
            this.marque = marque;
            this.moteur = moteur;
        }
        public override void Afficher()
        {
            Console.WriteLine("Véhicule n°" + id +" : Voiture\n");
            Console.WriteLine("Nom : " + nom);
            Console.WriteLine("Marque : " + marque);
            Console.WriteLine("Prix hors taxe : " + prixHT +" €");
            Console.WriteLine("Taille du coffre : " + tailleCoffre +" L");
            Console.WriteLine("Nombre de sièges : " + nbSiege);
            Console.WriteLine("Nombre de portes : " + nbPorte);
            Console.WriteLine("Chevaux fiscaux : " + chevauxFiscaux + " CV");
            Console.WriteLine("\n");
        }

        public override float CalculerTaxe()
        {
            return chevauxFiscaux * 10;
        }
    }
}
