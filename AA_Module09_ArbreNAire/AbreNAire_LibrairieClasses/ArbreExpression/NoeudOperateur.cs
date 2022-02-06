using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreNAire_LibrairieClasses
{
    class NoeudOperateur : INoeudExpression
    {
        // ** Champs ** //
        private char m_operateur;

        // ** Propriétés ** //
        public INoeudExpression NoeudGauche { get; set; }
        public INoeudExpression NoeudDroite { get; set; }
        public string ValeurNoeud
        {
            get => this.m_operateur.ToString();
            set
            {
                this.m_operateur = Char.Parse(value);
            }
        }

        // ** Constructeurs ** //
        public NoeudOperateur()
        {
            this.m_operateur = ' ';
        }
        public NoeudOperateur(char p_operateur, INoeudExpression p_noeudGauche, INoeudExpression p_noeudDroite)
        {
            this.m_operateur = p_operateur;
            this.NoeudGauche = p_noeudGauche;
            this.NoeudDroite = p_noeudDroite;
        }

        // ** Méthodes ** //
        public int Calculer()
        {
            switch (this.m_operateur)
            {
                case '+':
                    return NoeudGauche.Calculer() + NoeudDroite.Calculer();
                case '-':
                    return NoeudGauche.Calculer() - NoeudDroite.Calculer();
                case '*':
                    return NoeudGauche.Calculer() * NoeudDroite.Calculer();
                case '/':
                    return NoeudGauche.Calculer() / NoeudDroite.Calculer();
                default:
                    return default;
            }

        }
    }
}
