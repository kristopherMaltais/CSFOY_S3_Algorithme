﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreNAire_LibrairieClasses
{
    class NoeudOperateur : INoeudExpression
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public string Operateur { get; private set; }
        public INoeudExpression NoeudGauche { get; private set; }
        public INoeudExpression NoeudDroite { get; private set; }

        // ** Constructeurs ** //
        public NoeudOperateur(string p_operateur, INoeudExpression p_noeudGauche, INoeudExpression p_noeudDroite)
        {
            this.Operateur = p_operateur;
            this.NoeudGauche = p_noeudGauche;
            this.NoeudDroite = p_noeudDroite;
        }

        // ** Méthodes ** //
        public int Calculer()
        {
            switch (this.Operateur)
            {
                case "+":
                    return NoeudGauche.Calculer() + NoeudDroite.Calculer();
                case "-":
                    return NoeudGauche.Calculer() - NoeudDroite.Calculer();
                case "*":
                    return NoeudGauche.Calculer() * NoeudDroite.Calculer();
                case "/":
                    return NoeudGauche.Calculer() / NoeudDroite.Calculer();
                default:
                    return default;
            }

        }

        public bool EstNoeudOperateur()
        {
            return true;
        }
    }
}