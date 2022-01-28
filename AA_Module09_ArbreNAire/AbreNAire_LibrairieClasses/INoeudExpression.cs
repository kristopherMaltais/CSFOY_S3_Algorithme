using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreNAire_LibrairieClasses
{
    public interface INoeudExpression<TypeElement>
    {
        public INoeudExpression<TypeElement> NoeudGauche { get; }
        public INoeudExpression<TypeElement> NoeudDroite { get; }
        public bool EstNoeudOperateur();
        public TypeElement Calculer();
    }
}
