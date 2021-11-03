using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AA_Module03_TableauACapaciteVariable
{
    public class TableauCapaciteVariable<TypeElement> : IEnumerable<TypeElement>, IList<TypeElement>
    {
        // ** Champs ** //
        private const int m_capaciteParDefaut = 1;
        private TypeElement[] m_donnees;

        // ** Propriétés ** //
        public int Count { get; private set; }
        public int Capacity
        {
            get
            {
                return m_donnees.Length;
            }

            private set
            {
                TypeElement[] tableauTemporaire = new TypeElement[value];

                for (int index = 0; index < this.Count; index++)
                {
                    tableauTemporaire[index] = this.m_donnees[index];
                }

                this.m_donnees = tableauTemporaire;
            }
        }
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }


        // ** Constructeurs ** //
        public TableauCapaciteVariable(int p_capacite = m_capaciteParDefaut)
        {
            // Préconditions
            if(p_capacite < 0)
            {
                throw new ArgumentOutOfRangeException("La capacité du tableau ne peut pas être inférieure à zéro", "p_capacite");
            }
            
            this.Capacity = p_capacite;
        }

        public TableauCapaciteVariable(IEnumerable<TypeElement> p_elements)
        {
            // Preconditions
            if (p_elements == null)
            {
                throw new ArgumentNullException("Le conteneur passé en paramètre ne peut pas être null", "p_elements");
            }

            if (!p_elements.Any())
            {
                throw new ArgumentOutOfRangeException("Le conteneur vcdoit être supérieur à zéro", "p_elements");
            }

            this.Capacity = p_elements.Count();

            int index = 0;
            foreach (var item in p_elements)
            {
                this.m_donnees[index] = item;
                index++;
            }

            this.Count = p_elements.Count();
        }

        // ** Méthodes ** //

        // IList
        public TypeElement this[int p_indice]
        {
            get
            {
                return this.m_donnees[p_indice];
            }

            set
            {
                // Préconditions
                if(p_indice < 0 || p_indice >= this.Count)
                {
                    throw new ArgumentOutOfRangeException("Doit être supérieur à 0 et inférieur à la taille du tableau", "p_indice");
                }
                this.m_donnees[p_indice] = value;
            }
             
        }

        private void AugmenterCapacite()
        {
            int tailleTableauDouble = 2;
            this.Capacity = this.Capacity * tailleTableauDouble;
        }

        public void Add(TypeElement p_item)
        {
            if(this.Count == this.Capacity)
            {
                this.AugmenterCapacite();
            }
            
            this.m_donnees[this.Count] = p_item;
            this.Count++;

        }

        public void Clear()
        {
            for (int index = 0; index < m_donnees.Length; index++)
            {
                m_donnees[index] = default;
            }
            
            int tableauCapaciteVariableVide = 0;
            this.Count = tableauCapaciteVariableVide;

        }

        public bool Contains(TypeElement p_item)
        {
            bool elementExistant = false;

            for(int index = 0; index < this.Count; index++)
            {
                if(this.m_donnees[index].Equals(p_item))
                {
                    elementExistant = true;
                }
            }

            return elementExistant;
        }

        public void CopyTo(TypeElement[] p_array, int p_arrayIndex)
        {
            // Préconditions
            if(p_array == null)
            {
                throw new ArgumentNullException("Le tableau passé en paramètre ne peut pas être null", "p_array");
            }

            if(p_arrayIndex < 0 || p_arrayIndex >= p_array.Length)
            {
                throw new ArgumentOutOfRangeException("index doit être supérieur à zéro et inférieur au count", "p_arrayIndex");
            }

            if(this.Count + p_arrayIndex > p_array.Length)
            {
                throw new ArgumentException("La copie des données ne doit pas dépasser la capacité du tableau destinataire", "p_array");
            }

            for(int index = 0; index < this.Count; index++)
            {
                p_array[p_arrayIndex] = this.m_donnees[index];
                p_arrayIndex++;
            }
        }

        public IEnumerator<TypeElement> GetEnumerator()
        {
            return new EnumeratorTableauCapaciteVariable<TypeElement>(this);
        }

        public int IndexOf(TypeElement p_item)
        {
            int valeurTrouvee = -1;

            for (int index = 0; index < this.Count; index++)
            {
                if(this.m_donnees[index].Equals(p_item) || (p_item == null && this.m_donnees[index] == null))
                {
                    return index;
                }
            }

            return valeurTrouvee;
        }

        public void Insert(int p_index, TypeElement p_item)
        {
            // Préconditions
            if(p_index < 0 || p_index > this.Count)
            {
                throw new ArgumentOutOfRangeException("p_index doit être plus supérieur ou égal à zéro et inférieur ou égal à la taille de la collection", "p_index");
            }


            if (p_index == this.Count)
            {
                this.Add(p_item);
            }

            else
            {
                if (this.Count == this.Capacity)
                {
                    this.AugmenterCapacite();
                }

                for (int indexCourant = this.Count - 1; indexCourant >= p_index; indexCourant--)
                {
                    this.m_donnees[indexCourant + 1] = this.m_donnees[indexCourant];
                }

                this.m_donnees[p_index] = p_item;
                this.Count += 1;
            }
        }

        public bool Remove(TypeElement p_item)
        {
            int indexElement = this.IndexOf(p_item);
            int elementNonPresent = -1;
            bool indexEnleve = false;

            if(indexElement != elementNonPresent)
            {
                this.RemoveAt(indexElement);
                indexEnleve = true;
            }

            return indexEnleve;
        }

        public void RemoveAt(int p_index)
        {
            // Préconditions
            if(p_index < 0 || p_index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("L'index en paramètre doit être supérieur ou égal à zéro et inférieur au count", "p_index");
            }

            for (int indexCourant = p_index; indexCourant < this.Count - 1; indexCourant++)
            {
                this.m_donnees[indexCourant] = this.m_donnees[indexCourant + 1];
            }

            this.m_donnees[this.Count - 1] = default;
            this.Count--;
        }

        // IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        } 
    }

    
}
