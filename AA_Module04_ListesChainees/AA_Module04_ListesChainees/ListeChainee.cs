using System;
using System.Collections;
using System.Collections.Generic;

namespace AA_Module04_ListesChainees
{
    public class ListeChainee<TypeElement> : IEnumerable<TypeElement>, IList<TypeElement>
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public NoeudListeChainee<TypeElement> PremierNoeud { get; private set; }
        public NoeudListeChainee<TypeElement> DernierNoeud { get; private set; }
        public int Count { get; private set; }
        public bool IsReadOnly => false;

        // ** Constructeur ** //
        public ListeChainee()
        {
            this.Clear();
        }
        public ListeChainee(IEnumerable<TypeElement> p_elements)
        {
            // Préconditon
            if(p_elements == null)
            {
                throw new ArgumentNullException("La collection ne peut pas être null", "p_elements");
            }

            foreach(TypeElement elements in p_elements)
            {
                this.Add(elements);
            }
        }

        // ** Méthodes ** //
        public TypeElement this[int p_index]
        {
            get
            {
                // Précondition
                if(p_index < 0 || p_index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException("L'index doit être égale ou supérieur à 0 et inférieur à la taille de la collection", "index");
                }

                NoeudListeChainee<TypeElement> noeudAIndex = new NoeudListeChainee<TypeElement>();
                for (int indexCourant = 0; indexCourant <= p_index; indexCourant++)
                {
                    noeudAIndex = indexCourant == 0 ? this.PremierNoeud : noeudAIndex.Suivant;
                }

                return noeudAIndex.Valeur;
            }

            set
            {
                // Précondition
                if (p_index < 0 || p_index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException("L'index doit être égale ou supérieur à 0 et inférieur à la taille de la collection", "index");
                }

                NoeudListeChainee<TypeElement> noeudAIndex = new NoeudListeChainee<TypeElement>();
                for (int indexCourant = 0; indexCourant <= p_index; indexCourant++)
                {
                    noeudAIndex = indexCourant == 0 ? this.PremierNoeud : noeudAIndex.Suivant;
                }

                noeudAIndex.Valeur = value;
            }
        
        }
        public IEnumerator<TypeElement> GetEnumerator()
        {
            return new EnumeratorListeChainee<TypeElement>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public void Add(TypeElement p_item)
        {
            NoeudListeChainee<TypeElement> noeudAjoute = new NoeudListeChainee<TypeElement>();
            noeudAjoute.Valeur = p_item;
            noeudAjoute.Suivant = null;

            if (this.Count == 0)
            {
                this.PremierNoeud = noeudAjoute;
                this.DernierNoeud = noeudAjoute;
            }

            else
            {
                this.DernierNoeud.Suivant = noeudAjoute;
                this.DernierNoeud = noeudAjoute;
            }
             
            this.Count++;
        }
        public void AddFirst(TypeElement p_item)
        {
            NoeudListeChainee<TypeElement> noeudAAjouter = new NoeudListeChainee<TypeElement>();
            noeudAAjouter.Valeur = p_item;

            if (this.Count == 0)
            {
                this.Add(p_item);
            }

            else
            {
                noeudAAjouter.Suivant = this.PremierNoeud;
                this.PremierNoeud = noeudAAjouter;
                this.Count++;
            }
        }
        public void Clear()
        {
            this.PremierNoeud = null;
            this.DernierNoeud = null;
            this.Count = 0;
        }
        public bool Contains(TypeElement p_item)
        {
            bool valeurPresente = false;
            int index = this.IndexOf(p_item);

            if(index != -1)
            {
                valeurPresente = true;
            }

            return valeurPresente;
        }
        public void CopyTo(TypeElement[] p_array, int p_arrayIndex)
        {
            // Préconditions
            if(p_arrayIndex < 0 || p_arrayIndex > p_array.Length)
            {
                throw new ArgumentOutOfRangeException("L'index doit être supérieur ou égal à zéro et inférieur à la taille du tableau", "arrayIndex");
            }
            if(p_array == null)
            {
                throw new ArgumentNullException("Le tableau ne peut pas être null", "array");
            }
            if(p_arrayIndex + this.Count > p_array.Length)
            {
                throw new ArgumentOutOfRangeException("Le tableau de destination doit pouvoir contenir le collection de données", "arrayIndex");
            }

            for (int indexCourant = 0; indexCourant < Count; indexCourant++)
            {
                p_array[p_arrayIndex] = this[indexCourant];
                p_arrayIndex++;
            }
        }
        public int IndexOf(TypeElement p_item)
        {
            int indexItemTrouve = -1;

            NoeudListeChainee<TypeElement> noeudCourant = this.PremierNoeud;
            

            for (int indexCourant = 0; indexItemTrouve == -1 && indexCourant < this.Count; indexCourant++)
            {
                if(noeudCourant.Valeur == null || noeudCourant.Valeur.Equals(p_item))
                {
                    indexItemTrouve = indexCourant;
                }

                noeudCourant = noeudCourant.Suivant;
            }

            return indexItemTrouve;
        }
        public void Insert(int p_index, TypeElement p_item)
        {
            // Précondition
            if(p_index < 0 || p_index > this.Count)
            {
                throw new ArgumentOutOfRangeException("L'index doit être supérieur ou égal à 0 et inférieur ou égale à la taille de la collection", "p_index");
            }

            int premierIndex = 0;

            if(p_index == this.Count)
            {
                this.Add(p_item);
            }

            else if(p_index == premierIndex)
            {
                this.AddFirst(p_item);
            }

            else
            {
                NoeudListeChainee<TypeElement> nouveauNoeudAInserer = new NoeudListeChainee<TypeElement>();
                NoeudListeChainee<TypeElement> noeudTemporaire = this.PremierNoeud;

                for (int indexCourant = 0; indexCourant < p_index - 1; indexCourant++)
                {
                    noeudTemporaire = noeudTemporaire.Suivant;
                }

                nouveauNoeudAInserer.Valeur = p_item;
                nouveauNoeudAInserer.Suivant = noeudTemporaire.Suivant;
                noeudTemporaire.Suivant = nouveauNoeudAInserer;

                this.Count++;
            }
        }
        public bool Remove(TypeElement p_item)
        {
            bool itemTrouve = false;
            int indexTrouve = this.IndexOf(p_item);

            if(indexTrouve != -1)
            {
                this.RemoveAt(indexTrouve);
                itemTrouve = true;
            }

            return itemTrouve;
        }
        public void RemoveAt(int p_index)
        {
            // Préconditions
            if(p_index < 0 || p_index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("L'index doit être supérieur ou égal à 0 et inférieur à la taille de la collection", "p_index");
            }

            if (this.Count == 1)
            {
                this.Clear();
            }

            else if(p_index == 0)
            {
                this.PremierNoeud = PremierNoeud.Suivant;
            }

            else
            {
                NoeudListeChainee<TypeElement> noeudCourant = this.PremierNoeud;

                for (int indexCourant = 0; indexCourant < p_index - 1; indexCourant++)
                {
                    noeudCourant = noeudCourant.Suivant;
                }

                noeudCourant.Suivant = noeudCourant.Suivant.Suivant;

                if(p_index == Count - 1)
                {
                    this.DernierNoeud = noeudCourant;
                }
            }
            
            this.Count--;
        }
    }

    
}
