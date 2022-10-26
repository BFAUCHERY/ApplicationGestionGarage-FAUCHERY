using System;

namespace ApplicationGestionGarage_FAUCHERY
{
    public class Option
    {
        public static int id { get; set; }
        public string nom { get; set; }
        public float prix { get; set; }

        public Option(string nom, float prix)
        {
            id++;
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