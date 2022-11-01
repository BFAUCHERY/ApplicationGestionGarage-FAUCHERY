using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ApplicationGestionGarage_FAUCHERY
{
    [Serializable]
    public class Option
    {
        private static int idIncrement = SetIdIncrementStart();
        public int id { get; }
        public string nom { get; set; }
        public float prix { get; set; }

        public Option(string nom, float prix)
        {
            idIncrement++;
            id = idIncrement;
            this.nom = nom;
            this.prix = prix;
            SauvegarderOption();
        }
        private void SauvegarderOption()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream($@"..\..\SerializedObjects\Options\{id+nom}.txt", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, this);
            stream.Close();
        }

        public void Afficher()
        {
            Console.WriteLine("Option n°" + id +":\n");
            Console.WriteLine(nom);
            Console.WriteLine(prix +"\n");
        }

        private static int SetIdIncrementStart()
        {
            Program program = new Program();
            return program.GetOptionsIdIncrementStart();
        }
    }
}