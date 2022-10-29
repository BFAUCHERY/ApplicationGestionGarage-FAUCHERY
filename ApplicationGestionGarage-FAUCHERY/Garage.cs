using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationGestionGarage_FAUCHERY
{
    class Garage
    {
        public List<Vehicule> vehicules = new List<Vehicule>();
        public List<Moteur> moteurs = new List<Moteur>();
        public List<Option> options = new List<Option>();
        private List<Marque> marques = new List<Marque>();
        public string nom;

        public Garage(string nom)
        {
            this.nom = nom.ToUpper();
        }

        public void AjouterVehicule(Vehicule vehicule)
        {
            vehicules.Add(vehicule);

            if (!marques.Contains(vehicule.marque))
            {
                marques.Add(vehicule.marque);
            }
        }

        public void AjouterMoteur(Moteur moteur)
        {
            moteurs.Add(moteur);
        }

        public void AjouterOption(Option option)
        {
            options.Add(option);
        }

        public void SupprimerVehicule(Vehicule vehicule)
        {
            vehicules.Remove(vehicule);
        }

        public void AfficherVehicule(Vehicule vehicule)
        {
            vehicule.Afficher();
        }

        public void AfficherVehicules()
        {
            if(vehicules.Count > 0)
            {
                foreach (var vehicule in vehicules)
                {
                    vehicule.Afficher();
                }
            }
            else
            {
                Console.WriteLine("Pas de véhicule enregisté dans ce garage\n\n");
            }
        }

        public void AfficherVoitures()
        {
            Console.WriteLine("Garage " + nom);
            Console.WriteLine("Voitures :\n");
            foreach (var vehicule in vehicules)
            {
                if(vehicule is Voiture)
                {
                    vehicule.Afficher();
                }
            }
        }

        public void AfficherCamions()
        {
            Console.WriteLine("Garage " + nom);
            Console.WriteLine("Camions :\n");
            foreach (var vehicule in vehicules)
            {
                if (vehicule is Camion)
                {
                    vehicule.Afficher();
                }
            }
        }

        public void AfficherMotos()
        {
            Console.WriteLine("Garage " + nom);
            Console.WriteLine("Motos :\n");
            foreach (var vehicule in vehicules)
            {
                if (vehicule is Moto)
                {
                    vehicule.Afficher();
                }
            }
        }

        public void AfficherMoteurs()
        {
            Console.WriteLine("Garage " + nom);
            Console.WriteLine("Moteurs :\n");
            foreach (var moteur in moteurs)
            {
                moteur.Afficher();
            }
        }

        public void AfficherOptions()
        {
            Console.WriteLine("Garage " + nom);
            Console.WriteLine("Options :\n");
            foreach (var option in options)
            {
                option.Afficher();
            }
        }

        public void AfficherMarques()
        {
            foreach (var marque in marques)
            {
                Console.WriteLine(marque);
            }
        }

        public void AfficherTypesMoteurs()
        {
            foreach (var moteur in moteurs)
            {
                Console.WriteLine(moteur);
            }
        }

        public void TrierVehicule()
        {
            vehicules.Sort();
        }
    }
}
