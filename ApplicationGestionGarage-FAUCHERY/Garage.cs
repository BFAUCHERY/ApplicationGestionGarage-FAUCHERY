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

                    int choix = Int16.Parse(Console.ReadLine());
                    if(choix < 1 || choix > 3)
                    {
                        throw new FormatException();
                    }

                    switch (choix)
                    {
                        case 1:
                            return CreerVoiture();
                            break;
                        case 2:
                            return CreerCamion();
                            break;
                        case 3:
                            return CreerMoto();
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

        public Voiture CreerVoiture()
        {
            Console.WriteLine("Nom du véhicule :");
            string nomVoiture = Console.ReadLine();
            Console.WriteLine("Prix hors taxes :");
            float prixHTVoiture = float.Parse(Console.ReadLine());
            Console.WriteLine("Nombre de chevaux fiscaux :");
            int chevauxFiscaux = Int16.Parse(Console.ReadLine());
            Console.WriteLine("Nombre de portes :");
            int nbPortes = Int16.Parse(Console.ReadLine());
            Console.WriteLine("Nombre de sièges :");
            int nbSieges = Int16.Parse(Console.ReadLine());
            Console.WriteLine("Taille du coffre :");
            int tailleCoffre = Int16.Parse(Console.ReadLine());

            return new Voiture(nomVoiture, prixHTVoiture, GetMarque(), SelectMoteur(), chevauxFiscaux, nbPortes, nbSieges, tailleCoffre);         
        }

        public Camion CreerCamion()
        {
            Console.WriteLine("Nom du véhicule :");
            string nomCamion = Console.ReadLine();
            Console.WriteLine("Prix hors taxes :");
            float prixHTCamion = float.Parse(Console.ReadLine());
            Console.WriteLine("Nombre d'essieux :");
            int nbEssieux = Int16.Parse(Console.ReadLine());
            Console.WriteLine("Poids :");
            int poids = Int16.Parse(Console.ReadLine());
            Console.WriteLine("Volume :");
            int volume = Int16.Parse(Console.ReadLine());

            return new Camion(nomCamion, prixHTCamion, GetMarque(), SelectMoteur(), nbEssieux, poids, volume);
        }

        public Moto CreerMoto()
        {
            Console.WriteLine("Nom du véhicule :");
            string nomMoto = Console.ReadLine();
            Console.WriteLine("Prix hors taxes :");
            float prixMoto = float.Parse(Console.ReadLine());
            Console.WriteLine("Cylindrée :");
            int cylindree = Int16.Parse(Console.ReadLine());

            return new Moto(nomMoto, prixMoto, GetMarque(), SelectMoteur(), cylindree);
        }

        public Moteur SelectMoteur()
        {
            Console.WriteLine("Sélectionner un moteur :\n");
            Console.WriteLine("1. Sélectionner un moteur existant");
            Console.WriteLine("2. Créer un moteur\n");

            switch (Int16.Parse(Console.ReadLine()))
            {
                case 1:
                    GetMoteur();
                    break;
                case 2:
                    CreerMoteur();
                    break;
                default:
                    break;
            }
            return null;
        }//Exception à gérer

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
                    Console.WriteLine("2. Recherche par nom");
                    Console.WriteLine("3. Annuler\n");

                    int choix = Int16.Parse(Console.ReadLine());
                    if (choix < 1 || choix > 3)
                    {
                        throw new FormatException();
                    }

                    switch (Int16.Parse(Console.ReadLine()))
                    {
                        case 1:
                            Console.WriteLine("Identifiant du moteur :");
                            string id = Console.ReadLine();
                            return moteurs.Find(x => x.id == Int16.Parse(id));
                            break;
                        case 2:
                            Console.WriteLine("Nom du véhicule :");
                            string nom = Console.ReadLine();
                            return moteurs.Find(x => x.nom == nom);
                            break;
                        default:
                            return null;
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

        private Moteur CreerMoteur()
        {
            Console.WriteLine("Nom du moteur :");
            string nom = Console.ReadLine();
            Console.WriteLine("Puissance du moteur :");
            int puissance = Int16.Parse(Console.ReadLine());
            Console.WriteLine("Type de moteur :\n");
            Console.WriteLine("1. DIESEL");
            Console.WriteLine("2. ELECTRIQUE");
            Console.WriteLine("3. ESSENCE");
            Console.WriteLine("4. HYBRIDE\n");
            TypeMoteur typeMoteur = new TypeMoteur();
            switch (Int16.Parse(Console.ReadLine()))
            {
                case 1:
                    typeMoteur = TypeMoteur.DIESEL;
                    break;
                case 2:
                    typeMoteur = TypeMoteur.ELECTRIQUE;
                    break;
                case 3:
                    typeMoteur = TypeMoteur.ESSENCE;
                    break;
                case 4:
                    typeMoteur = TypeMoteur.HYBRIDE;
                    break;
                default:
                    break;
            }
            return new Moteur(nom, puissance, typeMoteur);
        }//Exception à gérer

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
                    Console.WriteLine("2. Recherche par nom");
                    Console.WriteLine("3. Annuler\n");

                    int choix = Int16.Parse(Console.ReadLine());
                    if (choix < 1 || choix > 3)
                    {
                        throw new FormatException();
                    }

                    switch (choix)
                    {
                        case 1:
                            Console.WriteLine("Identifiant du véhicule :");
                            string id = Console.ReadLine();
                            return vehicules.Find(x => x.id == Int16.Parse(id));
                            break;
                        case 2:
                            Console.WriteLine("Nom du véhicule :");
                            string name = Console.ReadLine();
                            return vehicules.Find(x => x.nom == name);
                            break;
                        case 3:
                            break;
                    }
                }
                catch(FormatException)
                {
                    Console.Clear();
                    Console.WriteLine(@"/!\ Veuillez rentrer des valeurs correctes pour chaque champs. /!\");
                    Console.WriteLine("******************************************************************");
                    restart = true;
                }
            } while (restart);
            return null;
        }

        public Option SelectOption()
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

                    int choix = Int16.Parse(Console.ReadLine());
                    if (choix < 1 || choix > 3)
                    {
                        throw new FormatException();
                    }

                    switch (choix)
                    {
                        case 1:
                            return GetOption();
                            break;
                        case 2:
                            return CreerOption();
                            break;
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
                    Console.WriteLine("2. Recherche par nom");
                    Console.WriteLine("3. Annuler\n");

                    int choix = Int16.Parse(Console.ReadLine());
                    if (choix < 1 || choix > 3)
                    {
                        throw new FormatException();
                    }

                    switch (choix)
                    {
                        case 1:
                            Console.WriteLine("Identifiant de l'option :");
                            string id = Console.ReadLine();
                            return options.Find(x => x.id == Int16.Parse(id));
                            break;
                        case 2:
                            Console.WriteLine("Nom de l'option :");
                            string name = Console.ReadLine();
                            return options.Find(x => x.nom == name);
                            break;
                        default:
                            break;
                    }
                }
                catch(FormatException)
                {
                    Console.Clear();
                    Console.WriteLine(@"/!\ Veuillez rentrer des valeurs correctes pour chaque champs. /!\");
                    Console.WriteLine("******************************************************************");
                    restart = true;
                }
            } while (restart);
            return null;
        }

        private Marque GetMarque()
        {
            Console.WriteLine("Marque du véhicule :\n");
            Console.WriteLine("1. AUDI");
            Console.WriteLine("2. CITROEN");
            Console.WriteLine("3. FERRARI");
            Console.WriteLine("4. PEUGEOT");
            Console.WriteLine("5. RENAULT\n");

            switch (Int16.Parse(Console.ReadLine()))
            {
                case 1:
                    return Marque.AUDI;
                    break;
                case 2:
                    return Marque.CITROEN;
                    break;
                case 3:
                    return Marque.FERRARI;
                    break;
                case 4:
                    return Marque.PEUGEOT;
                    break;
                case 5:
                    return Marque.RENAULT;
                    break;
                default:
                    return Marque.CITROEN;
                    break;
            }
        }//Exception à gérer
    }
}
