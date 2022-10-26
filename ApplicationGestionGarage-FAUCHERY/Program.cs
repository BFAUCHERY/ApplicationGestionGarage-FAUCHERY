using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationGestionGarage_FAUCHERY
{
    class Program
    {
        static void Main(string[] args)
        {
            TestsEtape1();
            Console.Read();
        }

        static void TestsEtape1()
        {
            Garage garage = new Garage("SANCHEZ");

            Moteur moteurCamion = new Moteur("MoteurCamion", 390, TypeMoteur.ESSENCE);
            Moteur moteurVoiture1 = new Moteur("MoteurV8", 250, TypeMoteur.ESSENCE);
            Moteur moteurVoiture2 = new Moteur("MoteurV12", 770, TypeMoteur.HYBRIDE);
            Moteur moteurMoto = new Moteur("MoteurCylindre", 190, TypeMoteur.ELECTRIQUE);

            Camion camion = new Camion("Camion Renault Premium 370", 21000, Marque.RENAULT, moteurCamion,4,30,20);
            Voiture voiture1 = new Voiture("PEUGEOT 3008 (2E GENERATION)", 21000, Marque.PEUGEOT, moteurVoiture1, 7,5,5,600);
            Voiture voiture2 = new Voiture("Ferrari F8 Tributo", 300000, Marque.FERRARI, moteurVoiture2, 70, 3, 2, 200);
            Moto moto = new Moto("Hayabusa",19199,Marque.FERRARI,moteurMoto,4);


            garage.AjouterVehicule(camion);
            garage.AjouterVehicule(voiture1);
            garage.AjouterVehicule(voiture2);
            garage.AjouterVehicule(moto);

            Console.WriteLine("\n****************************************\n");
            Console.WriteLine("Affichage des véhicules");
            Console.WriteLine("\n****************************************\n");
            garage.AfficherCamion();
            garage.AfficherVoiture();
            garage.AfficherMoto();

            Console.WriteLine("****************************************\n");
            Console.WriteLine("Trie des véhicules");
            Console.WriteLine("\n****************************************\n");
            garage.TrierVehicule();

            Console.WriteLine("****************************************\n");
            Console.WriteLine("Affichage des véhicules triés");
            Console.WriteLine("\n****************************************\n");
            garage.Afficher();
        }
    }
}
