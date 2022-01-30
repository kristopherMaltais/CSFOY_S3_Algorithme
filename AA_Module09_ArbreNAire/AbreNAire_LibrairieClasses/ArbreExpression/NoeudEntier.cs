using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreNAire_LibrairieClasses
{
    class NoeudEntier<TypeElement> : INoeudExpression<TypeElement>
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public TypeElement Valeur { get; set; }
        public INoeudExpression<TypeElement> NoeudGauche { get; private set; }
        public INoeudExpression<TypeElement> NoeudDroite { get; private set; }
        // ** Constructeurs ** //
        public NoeudEntier(TypeElement p_valeur)
        {
            this.Valeur = p_valeur;
        }

        public TypeElement Calculer()
        {
            return this.Valeur;
        }

        public bool EstNoeudOperateur()
        {
            return false;
        }

        // ** Méthodes ** //

    }
}
