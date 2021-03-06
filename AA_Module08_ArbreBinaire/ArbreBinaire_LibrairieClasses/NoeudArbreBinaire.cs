using System;

namespace ArbreBinaire_LibrairieClasses
{
    public class NoeudArbreBinaire<TypeElement>
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public NoeudArbreBinaire<TypeElement> NoeudGauche { get; set; }
        public NoeudArbreBinaire<TypeElement> NoeudDroite { get; set; }
        public TypeElement ValeurNoeud { get; set; }

        // ** Constructeurs ** //
        public NoeudArbreBinaire(TypeElement p_valeur, NoeudArbreBinaire<TypeElement> p_noeudGauche = null, NoeudArbreBinaire<TypeElement> p_noeudDroite = null)
        {
            this.ValeurNoeud = p_valeur;
            this.NoeudGauche = p_noeudGauche;
            this.NoeudDroite = p_noeudDroite;
        }
        internal int CompareTo<TypeElement>(NoeudArbreBinaire<TypeElement> p_noeudCourant) where TypeElement : IComparable<TypeElement>
        {
            throw new NotImplementedException();
        }

        // ** Méthodes ** //

    }
}
