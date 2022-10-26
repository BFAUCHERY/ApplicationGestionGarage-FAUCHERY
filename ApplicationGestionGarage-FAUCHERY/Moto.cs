using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationGestionGarage_FAUCHERY
{
    class Moto : Vehicule
    {
        public int cylindree { get; set; }

        public Moto(string nom, float prixHT, Marque marque, Moteur moteur, int cylindree) : base(nom, prixHT, marque, moteur)
        {
            this.cylindree = cylindree;
            this.nom = nom;
            this.prixHT = prixHT;
            this.marque = marque;
            this.moteur = moteur;
        }
        public override void Afficher()
        {
            Console.WriteLine("Véhicule n°" + id + " : Moto\n");
            Console.WriteLine("Nom : " + nom);
            Console.WriteLine("Marque : " + marque);
            Console.WriteLine("Prix hors taxe : " + prixHT +" €");
            Console.WriteLine("Cylindrée : " + cylindree);
            Console.WriteLine("\n");
        }

        public override void AfficherOption(Option option)
        {
            if (options.Find(i => i.nom == option.nom) != null)
            {
                option.Afficher();
            }
        }

        public override void AfficherOptions()
        {
            foreach (var option in options)
            {
                option.Afficher();
            }
        }

        public override float CalculerTaxe()
        {
            return (float)Math.Truncate(cylindree * 0.3f);
        }

        public override float PrixTotal()
        {
            float prixCumuleOptions = 0;
            foreach (var option in options)
            {
                prixCumuleOptions += option.prix;
            }
            return prixHT + CalculerTaxe() + prixCumuleOptions;
        }
    }
}
