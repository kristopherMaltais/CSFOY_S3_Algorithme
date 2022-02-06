using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreNAire_LibrairieClasses
{
    public interface INoeudExpression
    {
        public INoeudExpression NoeudGauche { get; set; }
        public INoeudExpression NoeudDroite { get; set; }
        public string ValeurNoeud { get; set; }
        public int Calculer();
    }
}
