using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationGestionGarage_FAUCHERY
{
    [Serializable]
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
            AjouterMarque(vehicule.marque);
            AjouterMoteur(vehicule.moteur);
        }

        public void AjouterMoteur(Moteur moteur)
        {
            if (!moteurs.Contains(moteur))
            {
                moteurs.Add(moteur);
            }
        }

        public void AjouterOption(Option option)
        {
            if (!options.Contains(option))
            {
                options.Add(option);
            }
        }

        public void AjouterMarque(Marque marque)
        {
            if (!marques.Contains(marque))
            {
                marques.Add(marque);
            }
        }

        public void SupprimerVehicule(Vehicule vehicule)
        {
            if (vehicules.Remove(vehicule))
            {
                Console.WriteLine("Véhicule \"" + vehicule.nom + "\" supprimé.");
            }
            else
            {
                Console.WriteLine("Aucun véhicule ne correspond à la valeur indiquée.");
            }
        }

        public void AfficherVehicule(Vehicule vehicule)
        {
            try
            {
                vehicule.Afficher();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Aucun véhicule ne correspond à la valeur indiquée.\n");
            }
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
                Console.WriteLine("Pas de véhicule enregisté dans ce garage\n");
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
            if (marques.Count() > 0)
            {
                Console.WriteLine("Garage " + nom);
                Console.WriteLine("Moteurs :\n");
                foreach (var moteur in moteurs)
                {
                    moteur.Afficher();
                }
            }
            else
            {
                Console.WriteLine("Aucun moteur enregistré pour le garage " + nom + "\n");
            }
        }

        public void AfficherOptions()
        {
            if(options.Count() > 0)
            {
                Console.WriteLine("Garage " + nom);
                Console.WriteLine("Options :\n");
                foreach (var option in options)
                {
                    option.Afficher();
                }
            }
            else
            {
                Console.WriteLine("Aucune option enregistrée pour le garage " + nom +"\n");
            }
            
        }

        public void AfficherMarques()
        {
            if (marques.Count() > 0)
            {
                Console.WriteLine("Garage " + nom);
                Console.WriteLine("Marques :\n");
                foreach (var marque in marques)
                {
                    Console.WriteLine(marque);
                }
            }
            else
            {
                Console.WriteLine("Aucune marque enregistrée pour le garage " + nom + "\n");
            }
        }

        public void AfficherTypesMoteurs()
        {
            if (moteurs.Count() > 0)
            {
                Console.WriteLine("Garage " + nom);
                Console.WriteLine("Type de moteurs :\n");
                foreach (var moteur in moteurs)
                {
                    Console.WriteLine(moteur.typeMoteur);
                }
            }
            else
            {
                Console.WriteLine("Aucun moteur enregistré pour le garage " + nom + "\n");
            }
        }

        public void TrierVehicule()
        {
            vehicules.Sort();
        }

        public Vehicule CreerVehicule()
        {
            bool restart;
            do
            {
                try
                {
                    restart = false;
                    Console.WriteLine("Créer un véhicule :\n");
                    Console.WriteLine("Type de véhicule :");
                    Console.WriteLine("\t1. Voiture");
                    Console.WriteLine("\t2. Camion");
                    Console.WriteLine("\t3. Moto\n");

                    int choix = Int32.Parse(Console.ReadLine());
                    if(choix < 1 || choix > 3)
                    {
                        throw new FormatException();
                    }

                    switch (choix)
                    {
                        case 1:
                            return CreerVoiture();
                        case 2:
                            return CreerCamion();
                        case 3:
                            return CreerMoto();
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
            return null;
        }

        public Voiture CreerVoiture()
        {
            Console.WriteLine("Nom du véhicule :");
            string nomVoiture = Console.ReadLine();
            Console.WriteLine("Prix hors taxes :");
            float prixHTVoiture = float.Parse(Console.ReadLine());
            Console.WriteLine("Nombre de chevaux fiscaux :");
            int chevauxFiscaux = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Nombre de portes :");
            int nbPortes = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Nombre de sièges :");
            int nbSieges = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Taille du coffre :");
            int tailleCoffre = Int32.Parse(Console.ReadLine());

            return new Voiture(nomVoiture, prixHTVoiture, GetMarque(), SelectMoteur(), chevauxFiscaux, nbPortes, nbSieges, tailleCoffre);         
        }

        public Camion CreerCamion()
        {
            Console.WriteLine("Nom du véhicule :");
            string nomCamion = Console.ReadLine();
            Console.WriteLine("Prix hors taxes :");
            float prixHTCamion = float.Parse(Console.ReadLine());
            Console.WriteLine("Nombre d'essieux :");
            int nbEssieux = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Poids :");
            int poids = int.Parse(Console.ReadLine());
            Console.WriteLine("Volume :");
            int volume = Int32.Parse(Console.ReadLine());

            return new Camion(nomCamion, prixHTCamion, GetMarque(), SelectMoteur(), nbEssieux, poids, volume);
        }

        public Moto CreerMoto()
        {
            Console.WriteLine("Nom du véhicule :");
            string nomMoto = Console.ReadLine();
            Console.WriteLine("Prix hors taxes :");
            float prixMoto = float.Parse(Console.ReadLine());
            Console.WriteLine("Cylindrée :");
            int cylindree = Int32.Parse(Console.ReadLine());

            return new Moto(nomMoto, prixMoto, GetMarque(), SelectMoteur(), cylindree);
        }

        public Moteur SelectMoteur()
        {
            if (moteurs.Count > 0)
            {
                bool restart;
                do
                {
                    restart = false;
                    try
                    {
                        Console.WriteLine("Sélectionner un moteur :\n");
                        Console.WriteLine("1. Sélectionner un moteur existant");
                        Console.WriteLine("2. Créer un moteur\n");

                        int choix = Int32.Parse(Console.ReadLine());
                        if (choix < 1 || choix > 2)
                        {
                            throw new FormatException();
                        }

                        switch (choix)
                        {
                            case 1:
                                return GetMoteur();
                            case 2:
                                return CreerMoteur();
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
                return null;
            }
            else
            {
                Console.WriteLine("Aucun moteur enregistré, création d'un moteur :\n");
                return CreerMoteur();
            }
            
        }

        public Option SelectOption()
        {
            if(options.Count > 0)
            {
                bool restart;
                do
                {
                    restart = false;
                    try
                    {
                        Console.WriteLine("Créer une option :\n");
                        Console.WriteLine("1. Ajouter une option existante");
                        Console.WriteLine("2. Créer une option");
                        Console.WriteLine("3. Annuler\n");

                        int choix = Int32.Parse(Console.ReadLine());
                        if (choix < 1 || choix > 3)
                        {
                            throw new FormatException();
                        }

                        switch (choix)
                        {
                            case 1:
                                return GetOption();
                            case 2:
                                return CreerOption();
                            case 3:
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
                return null;
            }
            else
            {
                Console.WriteLine("Aucune option enregistrée, création d'une option :\n");
                return CreerOption();
            }
            
        }

        private Moteur CreerMoteur()
        {
            bool restart;
            do
            {
                restart = false;
                try
                {
                    Console.WriteLine("Nom du moteur :");
                    string nom = Console.ReadLine();
                    Console.WriteLine("Puissance du moteur :");
                    int puissance = Int32.Parse(Console.ReadLine());

                    return new Moteur(nom, puissance, GetTypeMoteur());

                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine(@"/!\ Veuillez rentrer des valeurs correctes pour chaque champs. /!\");
                    Console.WriteLine("******************************************************************");
                    restart = true;
                }
            } while (restart);
            return null;
        }

        private Option CreerOption()
        {
            Console.WriteLine("Créer un option :\n");
            Console.WriteLine("Nom de l'option :");
            string nom = Console.ReadLine();
            Console.WriteLine("Prix de l'option :");
            float prix = float.Parse(Console.ReadLine());

            Option option = new Option(nom, prix);
            AjouterOption(option);
            return option;
        }

        private Moteur GetMoteur()
        {
            bool restart;
            do
            {
                restart = false;
                try
                {
                    Console.WriteLine("Sélectionner un moteur : \n");
                    Console.WriteLine("1. Recherche par identifiant");
                    Console.WriteLine("2. Recherche par nom\n");

                    int choix = Int32.Parse(Console.ReadLine());
                    if (choix < 1 || choix > 2)
                    {
                        throw new FormatException();
                    }

                    switch (choix)
                    {
                        case 1:
                            Console.WriteLine("Identifiant du moteur :");
                            string id = Console.ReadLine();
                            if (moteurs.Any(x => x.id == Int32.Parse(id)))
                            {
                                return moteurs.Find(x => x.id == Int32.Parse(id));
                            }
                            else
                            {
                                throw new ItemNotFoundException();
                            }
                        case 2:
                            Console.WriteLine("Nom du véhicule :");
                            string nom = Console.ReadLine();
                            if (moteurs.Any(x => x.nom == nom))
                            {
                                return moteurs.Find(x => x.nom == nom);
                            }
                            else
                            {
                                throw new ItemNotFoundException();
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    if (e is FormatException)
                    {
                        Console.WriteLine(@"/!\ Veuillez rentrer des valeurs correctes pour chaque champs. /!\");
                    }
                    else if (e is ItemNotFoundException)
                    {
                        Console.WriteLine(@"/!\ Moteur introuvable, veuillez réitérer la recherche. /!\");
                    }
                    Console.WriteLine("******************************************************************");
                    restart = true;
                }
            } while (restart);
            return null;
        }

        public Vehicule GetVehicule()
        {
            bool restart;
            do
            {
                restart = false;
                try
                {
                    Console.WriteLine("Sélectionner un véhicule : \n");
                    Console.WriteLine("1. Recherche par identifiant");
                    Console.WriteLine("2. Recherche par nom\n");

                    int choix = Int32.Parse(Console.ReadLine());
                    if (choix < 1 || choix > 2)
                    {
                        throw new FormatException();
                    }

                    switch (choix)
                    {
                        case 1:
                            Console.WriteLine("Identifiant du véhicule :");
                            string id = Console.ReadLine();
                            if (vehicules.Any(x => x.id == Int32.Parse(id)))
                            {
                                return vehicules.Find(x => x.id == Int32.Parse(id));
                            }
                            else
                            {
                                throw new ItemNotFoundException();
                            }
                        case 2:
                            Console.WriteLine("Nom du véhicule :");
                            string nom = Console.ReadLine();
                            if (vehicules.Any(x => x.nom == nom))
                            {
                                return vehicules.Find(x => x.nom == nom);
                            }
                            else
                            {
                                throw new ItemNotFoundException();
                            }
                    }
                }
                catch(Exception e)
                {
                    Console.Clear();
                    if (e is FormatException)
                    {
                        Console.WriteLine(@"/!\ Veuillez rentrer des valeurs correctes pour chaque champs. /!\");
                    }
                    else if (e is ItemNotFoundException)
                    {
                        Console.WriteLine(@"/!\ Véhicule introuvable, veuillez réitérer la recherche. /!\");
                    }
                    Console.WriteLine("******************************************************************");
                    restart = true;
                }
            } while (restart);
            return null;
        }

        public Option GetOption()
        {
            bool restart;
            do
            {
                restart = false;
                try
                {
                    Console.WriteLine("Sélectionner une option :\n");
                    Console.WriteLine("1. Recherche par identifiant");
                    Console.WriteLine("2. Recherche par nom\n");

                    int choix = Int32.Parse(Console.ReadLine());
                    if (choix < 1 || choix > 2)
                    {
                        throw new FormatException();
                    }

                    switch (choix)
                    {
                        case 1:
                            Console.WriteLine("Identifiant de l'option :");
                            string id = Console.ReadLine();
                            if (options.Any(x => x.id == Int32.Parse(id)))
                            {
                                return options.Find(x => x.id == Int32.Parse(id));
                            }
                            else
                            {
                                throw new ItemNotFoundException();
                            }
                        case 2:
                            Console.WriteLine("Nom de l'option :");
                            string nom = Console.ReadLine();
                            if (options.Any(x => x.nom == nom))
                            {
                                return options.Find(x => x.nom == nom);
                            }
                            else
                            {
                                throw new ItemNotFoundException();
                            }
                    }
                }
                catch(Exception e)
                {
                    Console.Clear();
                    if(e is FormatException)
                    {
                        Console.WriteLine(@"/!\ Veuillez rentrer des valeurs correctes pour chaque champs. /!\");
                    }
                    else if(e is ItemNotFoundException)
                    {
                        Console.WriteLine(@"/!\ Option introuvable, veuillez réitérer la recherche. /!\");
                    }
                    Console.WriteLine("******************************************************************");
                    restart = true;
                }
            } while (restart);
            return null;
        }

        private TypeMoteur GetTypeMoteur()
        {
            bool restart;
            do
            {
                restart = false;
                try
                {
                    Console.WriteLine("Type de moteur :\n");
                    Console.WriteLine("1. DIESEL");
                    Console.WriteLine("2. ELECTRIQUE");
                    Console.WriteLine("3. ESSENCE");
                    Console.WriteLine("4. HYBRIDE\n");

                    int choix = Int32.Parse(Console.ReadLine());
                    if (choix < 1 || choix > 4)
                    {
                        throw new FormatException();
                    }

                    switch (choix)
                    {
                        case 1:
                            return TypeMoteur.DIESEL;
                        case 2:
                            return TypeMoteur.ELECTRIQUE;
                        case 3:
                            return TypeMoteur.ESSENCE;
                        case 4:
                            return TypeMoteur.HYBRIDE;
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

            //Return impossible à atteindre, créé pour ne pas avoir d'erreurs
            return TypeMoteur.DIESEL;
        }

        private Marque GetMarque()
        {
            bool restart;
            do
            {
                restart = false;
                try
                {
                    Console.WriteLine("Marque du véhicule :\n");
                    Console.WriteLine("1. AUDI");
                    Console.WriteLine("2. CITROEN");
                    Console.WriteLine("3. FERRARI");
                    Console.WriteLine("4. PEUGEOT");
                    Console.WriteLine("5. RENAULT\n");

                    int choix = Int32.Parse(Console.ReadLine());
                    if (choix < 1 || choix > 5)
                    {
                        throw new FormatException();
                    }

                    switch (choix)
                    {
                        case 1:
                            return Marque.AUDI;
                        case 2:
                            return Marque.CITROEN;
                        case 3:
                            return Marque.FERRARI;
                        case 4:
                            return Marque.PEUGEOT;
                        case 5:
                            return Marque.RENAULT;
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

            //Return impossible à atteindre, créé pour ne pas avoir d'erreurs
            return Marque.AUDI;
        }
    }

    [Serializable]
    internal class ItemNotFoundException : Exception
    {
        public ItemNotFoundException()
        {
        }

        public ItemNotFoundException(string message) : base(message)
        {
        }

        public ItemNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ItemNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
