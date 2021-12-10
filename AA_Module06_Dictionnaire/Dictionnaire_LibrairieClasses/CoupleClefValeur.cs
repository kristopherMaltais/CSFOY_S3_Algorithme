using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionnaire_LibrairieClasses
{
    public class CoupleClefValeur<TypeClef, TypeValeur>
    {
        // Champs
        private TypeClef m_clef;
        private TypeValeur m_valeur;
        private int m_valeurHachage;

        // Propriétés
        public TypeClef Clef
        {
            get
            {
                return this.m_clef;
            }
            private set
            {
                this.m_clef = value;
            }
        }
        public TypeValeur Valeur
        {
            get
            {
                return this.m_valeur;
            }
            private set
            {
                this.m_valeur = value;
            }
        }
        public int ValeurHachage
        {
            get
            {
                return m_valeurHachage;
            }
            private set
            {
                this.m_valeurHachage = value;
            }
        }

        // Constructeurs
        public CoupleClefValeur(TypeClef p_clef, TypeValeur p_valeur)
        {
            this.Clef = p_clef;
            this.Valeur = p_valeur;
            this.ValeurHachage = p_clef.GetHashCode();
        }
       
        // Méthodes
    }
}
