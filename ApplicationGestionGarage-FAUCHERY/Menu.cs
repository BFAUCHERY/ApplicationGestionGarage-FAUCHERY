using System;
using System.Runtime.Serialization;

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
                    garage.AjouterVehicule(garage.CreerVehicule());
                    break;
                case 3:
                    garage.SupprimerVehicule(garage.GetVehicule());
                    break;
                case 4:
                    garage.AfficherVehicule(garage.GetVehicule());
                    break;
                case 5:
                    try
                    {
                        garage.GetVehicule().AfficherOptions();
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("Aucun véhicule ne correspond à la valeur indiquée.\n");
                    }
                    break;
                case 6:
                    try
                    {
                        garage.GetVehicule().AjouterOption(garage.SelectOption());//Select option se montre quand meme si annuler
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("Aucun véhicule ne correspond à la valeur indiquée.\n");
                    }
                    break;
                case 7:
                    try
                    {
                        garage.GetVehicule().SupprimerOption(garage.GetOption());//Select option se montre quand meme si annuler
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("Aucun véhicule ne correspond à la valeur indiquée.\n");
                    }
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

        private int GetChoix(string choix)
        {
            try
            {
                if(Int16.Parse(choix) <= 13 && Int16.Parse(choix) >= 1)
                {
                    return Int16.Parse(choix);
                }
                else
                {
                    throw new MenuException();
                }
            }
            catch(Exception e)
            {
                if(e is FormatException)
                {
                    Console.WriteLine(@"/!\ Le choix saisie n'est pas un nombre /!\" + "\n");
                }
                else if(e is MenuException)
                {
                    Console.WriteLine(@"/!\ Le choix n'est pas compris entre 1 et 12. /!\" + "\n");
                }
                return 0;
            }
        }
    }

    [Serializable]
    internal class MenuException : Exception
    {
        public MenuException()
        {
        }

        public MenuException(string message) : base(message)
        {
        }

        public MenuException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MenuException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
