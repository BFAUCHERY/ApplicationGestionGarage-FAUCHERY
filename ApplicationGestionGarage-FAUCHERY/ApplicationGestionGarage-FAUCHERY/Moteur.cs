using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ApplicationGestionGarage_FAUCHERY
{
    [Serializable]
    class Moteur
    {
        private static int idIncrement = SetIdIncrementStart();
        public int id { get; }
        public string nom { get; set; }
        public int puissance { get; set; }
        public TypeMoteur typeMoteur { get; set; }

        public Moteur(string nom, int puissance, TypeMoteur typeMoteur)
        {
            idIncrement++;
            id = idIncrement;
            this.nom = nom;
            this.puissance = puissance;
            this.typeMoteur = typeMoteur;
            SauvegarderMoteur();
        }

        private void SauvegarderMoteur()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream($@"..\..\SerializedObjects\Moteurs\{id + nom}.txt", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, this);
            stream.Close();
        }

        public void Afficher()
        {
            Console.WriteLine("Moteur n°" + id + " :\n");
            Console.WriteLine("Nom : " + nom);
            Console.WriteLine("Puissance : " + puissance +"CH");
            Console.WriteLine("Type de moteur : " + typeMoteur);
            Console.WriteLine("\n");
        }

        private static int SetIdIncrementStart()
        {
            Program program = new Program();
            return program.GetMoteursIdIncrementStart();
        }
    }
}
