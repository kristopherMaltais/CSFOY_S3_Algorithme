using AbreNAire_LibrairieClasses;
using System;
using System.Collections.Generic;

namespace ArbreNAire_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ArbreAutoCompletion arbre = new ArbreAutoCompletion();

            arbre.AjouterMot("na");
            arbre.AjouterMot("nslle");
            arbre.AjouterMot("nalles");
            arbre.AjouterMot("nallesdsadqw");
            arbre.AjouterMot("bus");

            List<string> liste = arbre.CompleterPrefixe("na");

            foreach (string mot in liste)
            {
                Console.WriteLine(mot);
            }
        }
    }
}
