using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbreBinaire_LibrairieClasses
{
    public class GenerateurArbreBinaire
    {
        public static ArbreBinaire<int> ExempleArbre1()
        {
           
            NoeudArbreBinaire<int> noeud1 = new NoeudArbreBinaire<int>(1);
            NoeudArbreBinaire<int> noeud2 = new NoeudArbreBinaire<int>(3);
            NoeudArbreBinaire<int> noeud3 = new NoeudArbreBinaire<int>(6);
            NoeudArbreBinaire<int> noeud4 = new NoeudArbreBinaire<int>(2, noeud1, noeud2);
            NoeudArbreBinaire<int> noeud5 = new NoeudArbreBinaire<int>(5, null, noeud3);
            NoeudArbreBinaire<int> noeud6 = new NoeudArbreBinaire<int>(4, noeud4, noeud5);

            ArbreBinaire<int> arbreBinaire = new ArbreBinaire<int>(noeud6);

            return arbreBinaire;
        }
        public static ArbreBinaireRecherche<int> ExempleArbre2()
        {

            ArbreBinaireRecherche<int> arbreBinaireRecherche = new ArbreBinaireRecherche<int>(new NoeudArbreBinaire<int>(13));
            arbreBinaireRecherche.AjouterNoeud(35);
            arbreBinaireRecherche.AjouterNoeud(40);
            arbreBinaireRecherche.AjouterNoeud(56);
            arbreBinaireRecherche.AjouterNoeud(24);
            arbreBinaireRecherche.AjouterNoeud(42);
            arbreBinaireRecherche.AjouterNoeud(39);
            arbreBinaireRecherche.AjouterNoeud(18);
            arbreBinaireRecherche.AjouterNoeud(-4);

            return arbreBinaireRecherche;
        }
    }
}
