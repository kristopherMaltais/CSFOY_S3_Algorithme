using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreNAire_LibrairieClasses
{
    public class GenerateurArbreExpression
    {
        // 2 + 3 * 4 + 5
        public static ArbreExpression ExempleExpression1()
        {
            NoeudEntier noeud5 = new NoeudEntier(5);
            NoeudEntier noeud2 = new NoeudEntier(2);
            NoeudEntier noeud3 = new NoeudEntier(3);
            NoeudEntier noeud4 = new NoeudEntier(4);

            NoeudOperateur noeudOperateur1 = new NoeudOperateur('*', noeud3, noeud4);
            NoeudOperateur noeudOperateur2 = new NoeudOperateur('+', noeud2, noeudOperateur1);
            NoeudOperateur noeudOperateur3 = new NoeudOperateur('+', noeudOperateur2, noeud5);
            ArbreExpression arbre = new ArbreExpression(noeudOperateur3);
            return arbre;
        }

        // 42 * 3 + 17 - 23 /7
        public static ArbreExpression ExempleExpression2()
        {
            NoeudEntier noeud42 = new NoeudEntier(42);
            NoeudEntier noeud3 = new NoeudEntier(3);
            NoeudEntier noeud17 = new NoeudEntier(17);
            NoeudEntier noeud23 = new NoeudEntier(23);
            NoeudEntier noeud7 = new NoeudEntier(7);

            NoeudOperateur noeudOperateur1 = new NoeudOperateur('*', noeud42, noeud3);
            NoeudOperateur noeudOperateur2 = new NoeudOperateur('+', noeudOperateur1, noeud17);
            NoeudOperateur noeudOperateur3 = new NoeudOperateur('/', noeud23, noeud7);
            NoeudOperateur noeudOperateur4 = new NoeudOperateur('-', noeudOperateur2, noeudOperateur3);
            ArbreExpression arbre = new ArbreExpression(noeudOperateur4);
            return arbre;
        }

        // Dernière question
        public static ArbreExpression FormatPrefixeVersArbreExpression(string p_string)
        {
            // Précondition
            if(p_string is null)
            {
                throw new ArgumentNullException(nameof(p_string), "La string ne peut pas etre null");
            }

            List<String> elementsExpression = p_string.Split(' ').ToList();

            ArbreExpression arbre = new ArbreExpression(new NoeudOperateur());
            FormatPrefixeVersArbreExpression_rec(arbre.NoeudRacine, elementsExpression);

            return arbre;
        }
        private static List<string> FormatPrefixeVersArbreExpression_rec(INoeudExpression p_noeudCourant, List<String> p_elementExpression)
        {
            List<string> operateurs = new List<string>() { "+", "-", "*", "/" };
            p_noeudCourant.ValeurNoeud = p_elementExpression[0];
            p_elementExpression.RemoveAt(0);

            if (operateurs.Contains(p_noeudCourant.ValeurNoeud))
            {
                p_noeudCourant.NoeudGauche = operateurs.Contains(p_elementExpression[0]) ? new NoeudOperateur() : new NoeudEntier();
                p_elementExpression = FormatPrefixeVersArbreExpression_rec(p_noeudCourant.NoeudGauche, p_elementExpression);

                p_noeudCourant.NoeudDroite = operateurs.Contains(p_elementExpression[0]) ? new NoeudOperateur() : new NoeudEntier();
                p_elementExpression = FormatPrefixeVersArbreExpression_rec(p_noeudCourant.NoeudDroite, p_elementExpression);
            }
            return p_elementExpression;
        }
    }
}
