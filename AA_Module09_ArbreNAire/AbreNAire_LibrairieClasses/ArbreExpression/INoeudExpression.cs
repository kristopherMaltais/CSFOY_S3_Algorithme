using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreNAire_LibrairieClasses
{
    public interface INoeudExpression
    {
        public INoeudExpression NoeudGauche { get; }
        public INoeudExpression NoeudDroite { get; }
        public bool EstNoeudOperateur();
        public int Calculer();
    }
}
