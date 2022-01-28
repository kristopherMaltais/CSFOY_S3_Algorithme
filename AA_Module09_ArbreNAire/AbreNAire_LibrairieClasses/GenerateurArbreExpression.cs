using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreNAire_LibrairieClasses
{
    public class GenerateurArbreExpression
    {
        public static ArbreExpression ExempleExpression1()
        {
            NoeudEntier noeud5 = new NoeudEntier(5);
            NoeudEntier noeud2 = new NoeudEntier(2);
            NoeudEntier noeud3 = new NoeudEntier(3);
            NoeudEntier noeud4 = new NoeudEntier(4);

            NoeudOperateur noeudOperateur1 = new NoeudOperateur("*", noeud3, noeud4);
            NoeudOperateur noeudOperateur2 = new NoeudOperateur("+", noeud2, noeudOperateur1);
            NoeudOperateur noeudOperateur3 = new NoeudOperateur("+", noeudOperateur2, noeud5);
            ArbreExpression arbre = new ArbreExpression(noeudOperateur3);

            return arbre;
        }

        public static ExempleExpression2()
        {

        }

    }
}
