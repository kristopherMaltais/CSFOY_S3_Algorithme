using System;
using System.Collections.Generic;
using System.Linq;

namespace PileEtFile_LibrairieClasses
{
    public class File2<TypeElement> // Le code ici c'est Pour la file basé sur une pile (le numéro optionnel)
    {
        // ** Champs ** //
        private Pile<TypeElement> m_donnees;
        private Pile<TypeElement> m_pileBackUp;

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
        public File2()
        {
            this.m_donnees = new Pile<TypeElement>();
            this.m_pileBackUp = new Pile<TypeElement>();
        }

        // ** Méthodes ** //
        public void Enfiler(TypeElement p_valeurAEnfiler)
        {
            this.m_donnees.Empiler(p_valeurAEnfiler);
            this.Count++;
        }
        public TypeElement Tete()
        {
            // Préconditions
            if(this.EstPileVide)
            {
                throw new PileVideException("Impossible de récupérer le sommet sur une pile vide");
            }

            TypeElement valeurRetour;

            for (int index = 0; index < this.Count; index++)
            {
                this.m_pileBackUp.Empiler(this.m_donnees.Sommet());
                this.m_donnees.Depiler();
            }

            valeurRetour = this.m_pileBackUp.Sommet();

            for (int index = 0; index < this.Count; index++)
            {
                this.m_donnees.Empiler(m_pileBackUp.Sommet());
                this.m_pileBackUp.Depiler();
            }

            return valeurRetour;
        }
        public TypeElement Defiler()
        {
            TypeElement valeurRetour;

            for (int index = 0; index < this.Count; index++)
            {
                this.m_pileBackUp.Empiler(m_donnees.Sommet());
                this.m_donnees.Depiler();
            }

            valeurRetour = this.m_pileBackUp.Sommet();
            m_pileBackUp.Depiler();
            this.Count--;

            for (int index = 0; index < this.Count; index++)
            {
                this.m_donnees.Empiler(this.m_pileBackUp.Sommet());
                this.m_pileBackUp.Depiler();
            }
            return valeurRetour;
        }
    }
}
