using System;
using ArbreBinaire_LibrairieClasses;

namespace ArbreBinaire_console
{
    class Program
    {
        static void Main(string[] args)
        {
            NoeudArbreBinaire<int> noeud1 = new NoeudArbreBinaire<int>(8);
            ArbreBinaireRecherche<int> arbre = new ArbreBinaireRecherche<int>(noeud1);
            arbre.AjouterNoeud(7);
            arbre.AjouterNoeud(5);
            arbre.AjouterNoeud(2);
            arbre.AjouterNoeud(3);
            arbre.AjouterNoeud(2);
            arbre.AjouterNoeud(20);


            Console.WriteLine(arbre.RechercherValeur(1));

        }
    }
}
