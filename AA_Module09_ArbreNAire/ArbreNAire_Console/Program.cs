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
            arbre.AjouterMot("ami");
            arbre.AjouterMot("amicale");
            arbre.AjouterMot("amicalement");
            arbre.AjouterMot("amour");
            arbre.AjouterMot("crier");
            arbre.AjouterMot("critere");
            arbre.AjouterMot("cribler");
            arbre.AjouterMot("carton");
            arbre.AjouterMot("canton");

            List<string> listeMot = arbre.CompleterPrefixe("am");

            listeMot.ForEach(mot => Console.WriteLine(mot));


        }
    }
}
