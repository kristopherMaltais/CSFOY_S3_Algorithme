using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreNAire_LibrairieClasses
{
    class NoeudEntier : INoeudExpression
    {
        // ** Champs ** //
        private int m_valeur;

        // ** Propriétés ** //
        public string ValeurNoeud
        {
            get => m_valeur.ToString();
            set
            {
                m_valeur = int.Parse(value);
            }
        }
        public INoeudExpression NoeudGauche { get; set; }
        public INoeudExpression NoeudDroite { get; set; }

        // ** Constructeurs ** //
        public NoeudEntier()
        {
            this.NoeudGauche = null;
            this.NoeudDroite = null;
        }
        public NoeudEntier(int p_valeur)
        {
            this.m_valeur = p_valeur;
        }

        // ** Méthodes ** //
        public int Calculer()
        {
            return this.m_valeur;
        }
    }
}
