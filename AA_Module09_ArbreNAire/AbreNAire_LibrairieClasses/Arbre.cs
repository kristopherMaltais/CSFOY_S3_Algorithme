using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreNAire_LibrairieClasses
{
    public class Arbre<TypeElement>
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public NoeudArbre<TypeElement> NoeudRacine;

        // ** Constructeurs ** //
        public Arbre(NoeudArbre<TypeElement> p_noeudRacine)
        {
            this.NoeudRacine = p_noeudRacine;
        }

        // ** Méthodes ** //
    }
}
