using System;
using System.Collections.Generic;
using System.Linq;

namespace PileEtFile_LibrairieClasses
{
    public class Pile<TypeElement>
    {
        // ** Champs ** //
        private TableauCapaciteVariable<TypeElement> m_donnees;

        // ** Propriétés ** //
        public bool EstPileVide
        {
            get
            {
                bool estVide = this.Count != 0 ? false : true;
                return estVide;
            }
        }
        public int Count { get; private set; }

        // ** Constructeurs ** //
        public Pile(IEnumerable<TypeElement> p_elements)
        {
            // Preconditions
            if (p_elements == null)
            {
                throw new ArgumentNullException("Le conteneur passé en paramètre ne peut pas être null", "p_elements");
            }

            this.m_donnees = new TableauCapaciteVariable<TypeElement>(p_elements);
            this.Count = p_elements.Count();
        }

        public Pile()
        {
            this.m_donnees = new TableauCapaciteVariable<TypeElement>();
        }

        // ** Méthodes ** //
        public void Empiler(TypeElement p_valeurAEmpiler)
        {
            this.m_donnees.Add(p_valeurAEmpiler);
            this.Count++;
        }
        public TypeElement Sommet()
        {
            // Préconditions
            if(this.EstPileVide)
            {
                throw new PileVideException("Impossible de récupérer le sommet sur une pile vide");
            }

            return m_donnees[this.Count - 1];
        }
        public TypeElement Depiler()
        {
            // Préconditions
            if(this.Count == 0)
            {
                throw new PileVideException("Ne peut pas depiler une pile vide");
            }

            TypeElement sommet = this.Sommet();

            this.m_donnees.RemoveAt(this.Count - 1);

            this.Count--;

            return sommet;
        }
    }
}
