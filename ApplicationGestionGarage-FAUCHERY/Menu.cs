using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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
                Console.WriteLine("11. Sauvegarder le garage");
                Console.WriteLine("12. Charger un garage");
                Console.WriteLine("13. Revenir au menu principal");

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
                        garage.GetVehicule().AjouterOption(garage.SelectOption());
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("Aucun véhicule ne correspond à la valeur indiquée.\n");
                    }
                    break;
                case 7:
                    try
                    {
                        garage.GetVehicule().SupprimerOption(garage.GetOption());
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
                    SauvegarderGarage();
                    break;
                case 12:
                    ChargerGarage();
                    break;
                case 13:
                    quit = true;
                    break;
            }
        }

        private void SauvegarderGarage()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream($@"..\..\SerializedObjects\Garages\{garage.nom}.txt", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, garage);
            stream.Close();
        }

        private void ChargerGarage()
        {
            bool restart;
            do
            {
                restart = false;
                try
                {
                    Console.WriteLine("Nom du garage :");
                    string nom = Console.ReadLine();
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream($@"..\..\SerializedObjects\Garages\{nom}.txt", FileMode.Open, FileAccess.Read);
                    garage = (Garage)formatter.Deserialize(stream);
                    stream.Close();
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine($@"/!\ Aucun garage situé dans {Path.GetFullPath(@"..\..\SerializedObjects\Garages\")} ne correspond à la valeur indiquée. /!\");
                    Console.WriteLine("********************************************************");
                    Console.WriteLine("Réitérer une recherche ?(O/N)");
                    if (Console.ReadLine().ToUpper() == "O")
                    {
                        restart = true;
                    }
                }
            } while (restart);
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
                    Console.WriteLine(@"/!\ Le choix n'est pas compris entre 1 et 13. /!\" + "\n");
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
