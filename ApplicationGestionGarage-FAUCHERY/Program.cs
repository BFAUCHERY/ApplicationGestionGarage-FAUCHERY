using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ApplicationGestionGarage_FAUCHERY
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application gestion garage FAUCHERY Benoît\n");
            bool restart = true;
            do
            {
                Console.WriteLine("Veuillez sélectionner une option :\n");
                Console.WriteLine("1. Afficher les résultats de l'étape 1");
                Console.WriteLine("2. Accéder au menu de l'étape 2 & 3");
                Console.WriteLine("3. Quitter l'application");
                try
                {
                    int choix = Int16.Parse(Console.ReadLine());
                    if (choix < 1 || choix > 3)
                    {
                        throw new FormatException();
                    }

                    switch (choix)
                    {
                        case 1:
                            Console.Clear();
                            TestsEtape1();
                            break;
                        case 2:
                            Console.Clear();
                            Etape2();
                            break;
                        case 3:
                            restart = false;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine(@"/!\ Veuillez rentrer des valeurs correctes pour chaque champs. /!\");
                    Console.WriteLine("******************************************************************");
                }
            } while (restart);
        }

        private static void TestsEtape1()
        {
            Garage garage = new Garage("GARAGE");

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
            garage.AfficherCamions();
            garage.AfficherVoitures();
            garage.AfficherMotos();

            Console.WriteLine("****************************************\n");
            Console.WriteLine("Trie des véhicules");
            Console.WriteLine("\n****************************************\n");
            garage.TrierVehicule();

            Console.WriteLine("****************************************\n");
            Console.WriteLine("Affichage des véhicules triés");
            Console.WriteLine("\n****************************************\n");
            garage.AfficherVehicules();
        }

        private static void Etape2()
        {
            string root = @"..\..\SerializedObjects\Garages\";
            string[] fileEntries = Directory.GetFiles(root);

            if (fileEntries.Length > 0)
            {
                Console.WriteLine("Des garages ont été créé précedemment.\n");
                bool restart;
                do
                {
                    restart = false;
                    Console.WriteLine("Veuillez saisir un choix:\n");
                    Console.WriteLine("1. Sélectionner un garage");
                    Console.WriteLine("2. Créer un garage");
                    try
                    {
                        int choix = Int16.Parse(Console.ReadLine());
                        if (choix < 1 || choix > 2)
                        {
                            throw new FormatException();
                        }

                        switch (choix)
                        {
                            case 1:
                                SelectionnerGarage();
                                break;
                            case 2:
                                CreerGarage();
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.Clear();
                        Console.WriteLine(@"/!\ Veuillez rentrer des valeurs correctes pour chaque champs. /!\");
                        Console.WriteLine("******************************************************************");
                        restart = true;
                    }
                } while (restart);
            }
            else
            {
                CreerGarage();
            }
        }

        private static void CreerGarage()
        {
            Console.WriteLine("Nom du garage à créer:\n");
            Menu menu = new Menu(new Garage(Console.ReadLine()));
            menu.Start();
        }

        private static void SelectionnerGarage()
        {
            bool restart;
            do
            {
                restart = false;
                try
                {
                    Console.WriteLine("Nom du garage à sélectionner:\n");
                    string nom = Console.ReadLine();
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream($@"..\..\SerializedObjects\Garages\{nom}.txt", FileMode.Open, FileAccess.Read);
                    Garage garage = (Garage)formatter.Deserialize(stream);
                    stream.Close();

                    Menu menu = new Menu(garage);
                    menu.Start();
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine($@"/!\ Aucun garage situé dans {Path.GetFullPath(@"..\..\SerializedObjects\Garages\")} ne correspond à la valeur indiquée. /!\");
                    Console.WriteLine("********************************************************");
                    restart = true;
                }
            } while (restart);
        }

        public int GetVehiculesIdIncrementStart()
        {
            List<Vehicule> vehicules = new List<Vehicule>();

            IFormatter formatter = new BinaryFormatter();
            string[] fileEntries = Directory.GetFiles(@"..\..\SerializedObjects\Vehicules");
            foreach (string fileName in fileEntries)
            {
                Stream stream = new FileStream($@"..\..\SerializedObjects\Vehicules\{fileName}", FileMode.Open, FileAccess.Read);
                Vehicule vehicule = (Vehicule)formatter.Deserialize(stream);
                stream.Close();
                vehicules.Add(vehicule);
            }

            return vehicules.Count;
        }
        public int GetOptionsIdIncrementStart()
        {
            List<Option> options = new List<Option>();

            IFormatter formatter = new BinaryFormatter();
            string[] fileEntries = Directory.GetFiles(@"..\..\SerializedObjects\Options");
            foreach (string fileName in fileEntries)
            {
                Stream stream = new FileStream($@"..\..\SerializedObjects\Options\{fileName}", FileMode.Open, FileAccess.Read);
                Option option = (Option)formatter.Deserialize(stream);
                stream.Close();
                options.Add(option);
            }

            return options.Count;
        }
        public int GetMoteursIdIncrementStart()
        {
            List<Moteur> moteurs = new List<Moteur>();

            IFormatter formatter = new BinaryFormatter();
            string[] fileEntries = Directory.GetFiles(@"..\..\SerializedObjects\Moteurs");
            foreach (string fileName in fileEntries)
            {
                Stream stream = new FileStream($@"..\..\SerializedObjects\Moteurs\{fileName}", FileMode.Open, FileAccess.Read);
                Moteur moteur = (Moteur)formatter.Deserialize(stream);
                stream.Close();
                moteurs.Add(moteur);
            }

            return moteurs.Count;
        }
    }
}
