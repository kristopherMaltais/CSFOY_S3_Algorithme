using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionnaire_LibrairieClasses
{
    public class Dictionnaire<TypeClef, TypeValeur> : IDictionary<TypeClef, TypeValeur>
    {
        // Champs
        private const int NB_ALVEOLES = 10;
        private LinkedList<CoupleClefValeur<TypeClef, TypeValeur>>[] m_alveoles;

        // Propriétés
        public int Count { get; private set; }
        public ICollection<TypeClef> Keys
        {
            get
            {
                var keys = m_alveoles.Where(index => index is not null).SelectMany(couple => couple).Select(x => x.Clef).ToList();
                return keys;
            }
        }
        public ICollection<TypeValeur> Values
        {
            get
            {
                var values = m_alveoles.Where(index => index is not null).SelectMany(couple => couple).Select(x => x.Valeur).ToList();
                return values;
            }
        }
        public bool IsReadOnly => false;
        public TypeValeur this[TypeClef p_key]
        {
            get
            {
                // Précondition
                if (!this.ContainsKey(p_key))
                {
                    throw new ClefNonTrouveeException("La clef n'existe pas");
                }

                TypeValeur valeurTrouve = default;
                int numeroAlveole = this.CalculerNumeroAlveole(p_key.GetHashCode());
                LinkedList<CoupleClefValeur<TypeClef, TypeValeur>> couples = m_alveoles[numeroAlveole];

                foreach(CoupleClefValeur<TypeClef, TypeValeur> couple in couples)
                {
                    if(couple.ValeurHachage == p_key.GetHashCode())
                    {
                        valeurTrouve = couple.Valeur;
                    }
                }

                return valeurTrouve;
            }

            set
            {
                // Préconditions
                if (this.ContainsKey(p_key))
                {
                    throw new ClefDejaPresenteException("La clef unique existe déjà");
                }

                this.Add(p_key, value);
            }

        }

        // Constructeurs
        public Dictionnaire()
        {
            this.Clear();
        }
        public Dictionnaire(IEnumerable<CoupleClefValeur<TypeClef, TypeValeur>> p_collection)
        {
            // Préconditions
            if(p_collection is null)
            {
                throw new ArgumentNullException("La collection ne peut pas être null", "p_collection");
            }

            this.m_alveoles = new LinkedList<CoupleClefValeur<TypeClef, TypeValeur>>[p_collection.Count()];

            foreach (CoupleClefValeur<TypeClef, TypeValeur> couple in p_collection)
            {
                this.Add(couple.Clef, couple.Valeur);
            }

            this.Count = p_collection.Count();
        }

        // Méthodes
        private int CalculerNumeroAlveole(int p_valeurHachage, int p_nombreAlveoles)
        {
            // Préconditions
            if (p_nombreAlveoles != this.m_alveoles.Length)
            {
                throw new ArgumentOutOfRangeException("Nombre d'alveole doit être égale à la capacité de m_alveole", "p_nombreAlveoles");
            }

            return Math.Abs(p_valeurHachage) % p_nombreAlveoles;
        }
        private int CalculerNumeroAlveole(int p_valeurHachage)
        {
            int nombreAlveoles = this.m_alveoles.Length;

            return this.CalculerNumeroAlveole(p_valeurHachage, nombreAlveoles);
        }
        public void Add(TypeClef p_key, TypeValeur p_value)
        {
            CoupleClefValeur<TypeClef, TypeValeur> nouveauCouple = new CoupleClefValeur<TypeClef, TypeValeur>(p_key, p_value);

            int numeroAlveole = CalculerNumeroAlveole(nouveauCouple.ValeurHachage);

            if (this.m_alveoles[numeroAlveole] is null)
            {
                this.m_alveoles[numeroAlveole] = new LinkedList<CoupleClefValeur<TypeClef, TypeValeur>>();
            }

            this.m_alveoles[numeroAlveole].AddLast(nouveauCouple);
            this.Count++;
        }
        public void Add(KeyValuePair<TypeClef, TypeValeur> p_item)
        {
            this.Add(p_item.Key, p_item.Value);
        }
        public void Clear()
        {
            this.m_alveoles = new LinkedList<CoupleClefValeur<TypeClef, TypeValeur>>[NB_ALVEOLES];
            this.Count = 0;
        }
        public bool Contains(KeyValuePair<TypeClef, TypeValeur> p_item)
        {
            bool estClefValeurTrouve = false;

            if(this.ContainsKey(p_item.Key) && this[p_item.Key].GetHashCode() == p_item.Value.GetHashCode())
            {
                estClefValeurTrouve = true;
            }

            return estClefValeurTrouve;
        }
        public bool ContainsKey(TypeClef p_key)
        {
            int numeroAlveole = CalculerNumeroAlveole(p_key.GetHashCode());
            bool estClefTrouve = false;

            if(this.m_alveoles[numeroAlveole] is not null)
            {
                LinkedList<CoupleClefValeur<TypeClef, TypeValeur>> couples = this.m_alveoles[numeroAlveole];

                foreach (CoupleClefValeur<TypeClef, TypeValeur> couple in couples)
                {
                    if(couple.ValeurHachage == p_key.GetHashCode())
                    {
                        if (p_key.Equals(p_key))
                        {
                            estClefTrouve = true;
                        }
                    }
                }
            }

            return estClefTrouve;
        }
        public void CopyTo(KeyValuePair<TypeClef, TypeValeur>[] p_array, int p_arrayIndex)
        {
            // Préconditions
            if(p_arrayIndex < 0 || p_arrayIndex >= p_array.Length)
            {
                throw new ArgumentOutOfRangeException("index doit être supérieur ou égale à zéro et inférieur à la capacité du tableau Destination", "p_arrarIndex");
            }

            if(p_arrayIndex + this.Count > p_array.Length)
            {
                throw new ArgumentOutOfRangeException("Nombre d'élément à copier plus index de départ doit être inférieur à la capacité du tableau");
            }

            var couplesClefsValeurs = m_alveoles.Where(index => index is not null).SelectMany(couple => couple).ToList();

            
            foreach(CoupleClefValeur<TypeClef, TypeValeur> coupleClefValeur in couplesClefsValeurs)
            {
                KeyValuePair<TypeClef, TypeValeur> coupleConversion = new KeyValuePair<TypeClef, TypeValeur>(coupleClefValeur.Clef, coupleClefValeur.Valeur);
                p_array[p_arrayIndex] = coupleConversion;
                p_arrayIndex++;
            }

        }
        public IEnumerator<KeyValuePair<TypeClef, TypeValeur>> GetEnumerator()
        {
            var keys = this.m_alveoles.Where(index => index is not null).SelectMany(couple => couple).Select(x => new KeyValuePair<TypeClef, TypeValeur>(x.Clef, x.Valeur)).GetEnumerator();
            return keys;
        }
        public bool Remove(TypeClef p_key)
        {
            bool clefSupprime = false;

            if(this.ContainsKey(p_key))
            {
                int numeroAlveole = this.CalculerNumeroAlveole(p_key.GetHashCode());
                var couplesClefValeurFiltres = this.m_alveoles[numeroAlveole].Where(couple => couple.ValeurHachage != p_key.GetHashCode());
                LinkedList<CoupleClefValeur<TypeClef, TypeValeur>> nouveauCoupleClefValeur  = new LinkedList<CoupleClefValeur<TypeClef, TypeValeur>>(couplesClefValeurFiltres);
                this.m_alveoles[numeroAlveole] = nouveauCoupleClefValeur;
                this.Count--;
                clefSupprime = true;
            }

            return clefSupprime;
        }
        public bool Remove(KeyValuePair<TypeClef, TypeValeur> p_item)
        {
            bool coupleClefValeurSupprime = false;

            if (this.Contains(p_item))
            {
                coupleClefValeurSupprime = this.Remove(p_item.Key);
            }

            return coupleClefValeurSupprime;
        }
        public bool TryGetValue(TypeClef key, [MaybeNullWhen(false)] out TypeValeur p_value)
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
