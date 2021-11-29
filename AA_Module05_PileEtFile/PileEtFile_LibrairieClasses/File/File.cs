using System;
using System.Collections.Generic;
using System.Text;

namespace PileEtFile_LibrairieClasses
{
    public class File<TypeElement>
    {
        // ** Champs ** //
        private ListeChainee<TypeElement> m_donnees;


        // ** Propriétés ** //
        public bool EstFileVide
        {
            get
            {
                bool estVide = this.Count != 0 ? false : true;
                return estVide;
            }
        }
        public int Count { get; private set; }

        // ** Constructeur ** //
        public File(IEnumerable<TypeElement> p_elements)
        {
            // Préconditon
            if (p_elements == null)
            {
                throw new ArgumentNullException("La collection ne peut pas être null", "p_elements");
            }

            m_donnees = new ListeChainee<TypeElement>();

            foreach (TypeElement elements in p_elements)
            {
                m_donnees.Add(elements);
            }

            this.Count = m_donnees.Count;
        }

        // ** Méthodes ** //
        public void Enfiler(TypeElement p_elementAEnfiler)
        {
            this.m_donnees.AddFirst(p_elementAEnfiler);
            this.Count++;
        }

        public TypeElement Tete()
        {
            // Préconditions
            if(EstFileVide)
            {
                throw new FileVideException("Ne peut pas retourner la tete d\'une file vide");
            }

            return this.m_donnees.DernierNoeud.Valeur;
        }

        public TypeElement Defiler()
        {
            // Préconditions
            if(EstFileVide)
            {
                throw new FileVideException("Ne peut pas defiler une file qui est vide");
            }

            TypeElement valeurDefilee = this.m_donnees.DernierNoeud.Valeur;

            this.m_donnees.RemoveAt(Count - 1);
            this.Count--;
            return valeurDefilee;
        }
    }
}
