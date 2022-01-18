using System;
using System.Collections.Generic;

namespace AbreNAire_LibrairieClasses
{
    public class NoeudArbre<TypeElement>
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public TypeElement Valeur { get; set; }
        public List<NoeudArbre<TypeElement>> NoeudsEnfants { get; set; } 

        // ** Constructeurs ** //
        public NoeudArbre(TypeElement p_valeur)
        {
            this.Valeur = p_valeur;
            this.NoeudsEnfants = new List<NoeudArbre<TypeElement>>();
        }

        // ** Méthodes ** //
    }
}
