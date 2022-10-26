using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationGestionGarage_FAUCHERY
{
    class Garage
    {
        private List<Vehicule> vehicules = new List<Vehicule>();
        public string nom;

        public Garage(string nom)
        {
            this.nom = nom.ToUpper();
        }

        public void AjouterVehicule(Vehicule vehicule)
        {
            vehicules.Add(vehicule);
        }

        public void Afficher()
        {
            Console.WriteLine("Garage " + nom + "\n");
            foreach (var vehicule in vehicules)
            {
                vehicule.Afficher();
            }
        }

        public void AfficherVoiture()
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

        public void AfficherCamion()
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

        public void AfficherMoto()
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

        public void TrierVehicule()
        {
            vehicules.Sort();
        }
    }
}
