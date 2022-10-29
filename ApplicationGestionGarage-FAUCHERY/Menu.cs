using System;

namespace ApplicationGestionGarage_FAUCHERY
{
    class Menu
    {
        public Garage garage { get; set; }
        private bool quit = false;

        public Menu(Garage garage)
        {
            this.garage = garage;
        }

        public void Start()
        {
            Console.Clear();
            while (!quit)
            {
                Console.WriteLine("*******************************************");
                Console.WriteLine("Garage " + garage.nom + "\n");
                Console.WriteLine("Veuillez sélectionner une option :\n");
                Console.WriteLine("1. Afficher les véhicules");
                Console.WriteLine("2. Ajouter un véhicule");
                Console.WriteLine("3. Supprimer un véhicule");
                Console.WriteLine("4. Sélectionner un véhicule");
                Console.WriteLine("5. Afficher les options d'un véhicule");
                Console.WriteLine("6. Ajouter des options à un véhicule");
                Console.WriteLine("7. Supprimer des options à un véhicule");
                Console.WriteLine("8. Afficher les options");
                Console.WriteLine("9. Afficher les marques");
                Console.WriteLine("10. Afficher les types de moteurs");
                Console.WriteLine("11. Charger le garage");
                Console.WriteLine("12. Sauvegarder le garage");
                Console.WriteLine("13. Quitter l'application");

                ChoixMenu();
            }
        }

        private void ChoixMenu()
        {
            string choix = Console.ReadLine();
            Console.Clear();
            switch (GetChoix(choix))
            {
                case 1:
                    garage.AfficherVehicules();
                    break;
                case 2:
                    garage.AjouterVehicule(CreerVehicule());
                    break;
                case 3:
                    garage.SupprimerVehicule(SelectVehicule());
                    break;
                case 4:
                    garage.AfficherVehicule(SelectVehicule());
                    break;
                case 5:
                    SelectVehicule().AfficherOptions();
                    break;
                case 6:
                    SelectVehicule().AjouterOption(CreerOption());
                    break;
                case 7:
                    SelectVehicule().SupprimerOption(SelectOption());
                    break;
                case 8:
                    garage.AfficherOptions();
                    break;
                case 9:
                    garage.AfficherMarques();
                    break;
                case 10:
                    garage.AfficherTypesMoteurs();
                    break;
                case 11:
                    //TODO : Charger un garage
                    break;
                case 12:
                    //TODO : Sauvegarder un garage
                    break;
                case 13:
                    quit = true;
                    break;
            }
        }

        private Option CreerOption()
        {
            Console.WriteLine("Créer une option :\n");
            Console.WriteLine("1. Ajouter une option existante");
            Console.WriteLine("2. Créer une option\n");

            switch (Int16.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Créer un option :\n");
                    Console.WriteLine("Nom de l'option :");
                    string nom = Console.ReadLine();
                    Console.WriteLine("Nom de l'option :");
                    float prix = float.Parse(Console.ReadLine());
                    return new Option(nom,prix);
                    break;
                case 2:
                    Console.WriteLine("Ajouter une option existante :\n");
                    Console.WriteLine("1. Recherche par identifiant");
                    Console.WriteLine("2. Recherche par nom\n");
                    switch (Int16.Parse(Console.ReadLine()))
                    {
                        case 1:
                            Console.WriteLine("Identifiant de l'option :");
                            return garage.options.Find(x => x.id == Int16.Parse(Console.ReadLine()));
                            break;
                        case 2:
                            Console.WriteLine("Nom de l'option :");
                            return garage.options.Find(x => x.nom == Console.ReadLine());
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
                    
            }
            return null;
        }

        private Vehicule CreerVehicule()
        {
            Console.WriteLine("Créer un véhicule :\n");
            Console.WriteLine("Type de véhicule :");
            Console.WriteLine("\t1. Voiture");
            Console.WriteLine("\t2. Camion");
            Console.WriteLine("\t3. Moto\n");
            switch (Int16.Parse(Console.ReadLine()))
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
                default:
                    break;
            }
            return null;
        }

        private Voiture CreerVoiture()
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

        private Camion CreerCamion()
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

        private Moto CreerMoto()
        {
            Console.WriteLine("Nom du véhicule :");
            string nomMoto = Console.ReadLine();
            Console.WriteLine("Prix hors taxes :");
            float prixMoto = float.Parse(Console.ReadLine());
            Console.WriteLine("Cylindrée :");
            int cylindree = Int16.Parse(Console.ReadLine());
            
            return new Moto(nomMoto, prixMoto, GetMarque(), SelectMoteur(), cylindree);
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
        }

        private Moteur SelectMoteur()
        {
            Console.WriteLine("Sélectionner un moteur :\n");
            Console.WriteLine("1. Sélectionner un moteur existant");
            Console.WriteLine("2. Créer un moteur\n");

            switch (Int16.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Sélectionner un moteur : \n");
                    Console.WriteLine("1. Recherche par identifiant");
                    Console.WriteLine("2. Recherche par nom\n");
                    switch (Int16.Parse(Console.ReadLine()))
                    {
                        case 1:
                            Console.WriteLine("Identifiant du moteur :");
                            return garage.moteurs.Find(x => x.id == Int16.Parse(Console.ReadLine()));
                            break;
                        case 2:
                            Console.WriteLine("Nom du véhicule :");
                            return garage.moteurs.Find(x => x.nom == Console.ReadLine());
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
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
                    return new Moteur(nom,puissance,typeMoteur);
                    break;
                default:
                    break;
            }
            return null;
        }

        private Option SelectOption()
        {
            Console.WriteLine("Sélectionner une option :\n");
            Console.WriteLine("Nom de l'option :");
            return garage.options.Find(x => x.nom == Console.ReadLine());
        }

        private Vehicule SelectVehicule()
        {
            Console.WriteLine("Sélectionner un véhicule : \n");
            Console.WriteLine("1. Recherche par identifiant");
            Console.WriteLine("2. Recherche par nom\n");
            switch (Int16.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Identifiant du véhicule :");
                    return garage.vehicules.Find(x => x.id == Int16.Parse(Console.ReadLine()));
                    break;
                case 2:
                    Console.WriteLine("Nom du véhicule :");
                    return garage.vehicules.Find(x => x.nom == Console.ReadLine());
                    break;
                default:
                    break;
            }
            return null;
        }

        private int GetChoix(string choix)
        {

            return Int16.Parse(choix);
        }
    }
}
