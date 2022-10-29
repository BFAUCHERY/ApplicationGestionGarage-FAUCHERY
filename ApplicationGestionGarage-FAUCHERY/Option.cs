using System;

namespace ApplicationGestionGarage_FAUCHERY
{
    public class Option
    {
        private static int idIncrement { get; set; }
        public int id { get; }
        public string nom { get; set; }
        public float prix { get; set; }

        public Option(string nom, float prix)
        {
            idIncrement++;
            id = idIncrement;
            this.nom = nom;
            this.prix = prix;
        }

        public void Afficher()
        {
            Console.WriteLine("Option n°" + id +":\n");
            Console.WriteLine(nom);
            Console.WriteLine(prix +"\n");
        }
    }
}