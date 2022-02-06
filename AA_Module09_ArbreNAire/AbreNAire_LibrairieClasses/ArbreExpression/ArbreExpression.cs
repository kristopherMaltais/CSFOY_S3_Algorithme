using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreNAire_LibrairieClasses
{
    public class ArbreExpression
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public INoeudExpression NoeudRacine;

        // ** Constructeurs ** //
        public ArbreExpression(INoeudExpression p_noeudRacine)
        {
            this.NoeudRacine = p_noeudRacine;
        }

        // ** Méthodes ** //
        public int Calculer()
        {
            return this.NoeudRacine.Calculer();
        }
    }
}
