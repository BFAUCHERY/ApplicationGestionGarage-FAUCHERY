using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationGestionGarage_FAUCHERY
{
    abstract class Vehicule : IComparable<Vehicule>
    {
        private static int idIncrement { get; set; }
        public int id { get; }
        public string nom { get; set; }
        public float prixHT { get; set; }
        public Marque marque { get; set; }
        public Moteur moteur { get; set; }

        public List<Option> options = new List<Option>();


        public Vehicule(string nom, float prixHT, Marque marque, Moteur moteur)
        {
            idIncrement++;
            id = idIncrement;
            this.nom = nom;
            this.prixHT = prixHT;
            this.marque = marque;
            this.moteur = moteur;
        }

        public abstract void Afficher();
        public abstract float CalculerTaxe();

        public float PrixTotal()
        {
            float prixCumuleOptions = 0;
            foreach (var option in options)
            {
                prixCumuleOptions += option.prix;
            }
            return prixHT + CalculerTaxe() + prixCumuleOptions;
        }
        public void AfficherOptions()
        {
            foreach (var option in options)
            {
                option.Afficher();
            }
        }
        public void AfficherOption(Option option)
        {
            if (options.Find(i => i.nom == option.nom) != null)
            {
                option.Afficher();
            }
        }
        public void AjouterOption(Option option)
        {
            options.Add(option);
        }
        public void SupprimerOption(Option option)
        {
            options.Remove(option);
        }
        public int CompareTo(Vehicule other)
        {
            if (other == null)
            {
                return 1;
            }

            return Comparer<float>.Default.Compare(this.PrixTotal(), other.PrixTotal());
        }
    }
}
