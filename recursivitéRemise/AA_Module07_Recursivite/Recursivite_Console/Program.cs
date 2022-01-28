using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Timers;

namespace Recursivite_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        #region CompterEnNegatif
        // 1. Compter en négatif
        public static void CompterEnNegatifCroissant(int p_depart)
        {
            // Précondition
            if(p_depart > 0)
            {
                throw new ArgumentOutOfRangeException(nameof(p_depart), "Le nombre de départ doit être négatif ou égale à 0");
            }

            CompterEnNegatifCroissant_rec(p_depart);
        }
        private static void CompterEnNegatifCroissant_rec(int p_depart)
        {
            Console.WriteLine(p_depart.ToString());

            if (p_depart < 0)
            {
                CompterEnNegatifCroissant_rec(p_depart + 1);
            }
        }
        public static void CompterEnNegatifDecroissant(int p_fin)
        {
            // Précondition
            if (p_fin > 0)
            {
                throw new ArgumentOutOfRangeException(nameof(p_fin), "Le nombre de fin doit être négatif ou égale à 0");
            }

            CompterEnNegatifDecroissant_rec(p_fin);
        }
        private static void CompterEnNegatifDecroissant_rec(int p_fin)
        {

            if(p_fin <= 0)
            {
                CompterEnNegatifDecroissant_rec(p_fin + 1);
                Console.WriteLine(p_fin);
            }
        }
        #endregion

        #region DivisionEntiere
        // 2. Division entière
        public static int DivisionEntiere(int p_premierChiffre, int p_deuxiemeChiffre)
        {
            // Préconditions
            if(p_premierChiffre < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(p_premierChiffre), "Ne peut pas être négatif");
            }
            if (p_deuxiemeChiffre <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(p_premierChiffre), "Ne peut pas être négatif ou égale à 0");
            }
            return DivisionEntiere_rec(p_premierChiffre, p_deuxiemeChiffre);
        }
        public static int DivisionEntiere_rec(int p_premierChiffre, int p_deuxiemeChiffre)
        {
            if(p_premierChiffre - p_deuxiemeChiffre < 0)
            {
                return p_premierChiffre;
            }

            return DivisionEntiere_rec(p_premierChiffre - p_deuxiemeChiffre, p_deuxiemeChiffre);
        }
        #endregion

        #region fibonacci
        // 3.1 Fibonacci
        public static int Fibonacci(int p_n)
        {
           // Précondition
           if(p_n < 0)
           {
                throw new ArgumentOutOfRangeException(nameof(p_n), "La position de fibonacci doit être positive");
           }

            return Fibonacci_rec(p_n - 1) + Fibonacci_rec(p_n - 2);
        }
        public static int Fibonacci_rec(int p_n)
        {
            if (p_n <= 1)
            {
                return p_n;
            }
            else
            {
                return Fibonacci_rec(p_n - 1) + Fibonacci_rec(p_n - 2);
            }
        }

        // 3.2 Fibonacci optimisé
        public static long FibonacciOpt(long p_n)
        {
            // Précondition
            if (p_n < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(p_n), "La position de fibonacci doit être positive");
            }

            Dictionary<long, long> fibonacciConnu = new Dictionary<long, long>();
            return FibonacciOpt_rec(p_n - 1, fibonacciConnu) + FibonacciOpt_rec(p_n - 2, fibonacciConnu);
        }
        public static long FibonacciOpt_rec(long p_n, Dictionary<long, long> p_fibonacciConnu)
        {
            if (p_n <= 1)
            {
                return p_n;
            }

            if(p_fibonacciConnu.ContainsKey(p_n))
            {
                return p_fibonacciConnu[p_n];
            }
            else
            {
                long resultat = FibonacciOpt_rec(p_n - 1, p_fibonacciConnu) + FibonacciOpt_rec(p_n - 2, p_fibonacciConnu);
                p_fibonacciConnu.Add(p_n, resultat);
                return resultat;
            }
        }
        #endregion

        #region ListeChainee
        // 4.1 Liste chainée NombreElement
        public static int NombreElementV1<TypeElement>(LinkedList<TypeElement> p_listeChainee)
        {
            // Précondition
            if(p_listeChainee is null)
            {
                throw new ArgumentNullException("La liste chainée ne peut pas être null");
            }
            
            LinkedListNode<TypeElement> noeudCourrant = p_listeChainee.First;

            if(noeudCourrant is null)
            {
                return 0;
            }

            return NombreElementV1_rec(noeudCourrant);
        }
        private static int NombreElementV1_rec<TypeElement>(LinkedListNode<TypeElement> p_noeud)
        {
            if(p_noeud is null)
            {
                return 0;
            }

            return 1 + NombreElementV1_rec(p_noeud.Next);
        }

        // 4.2 Liste chainée ValeurPlusGrande
        public static TypeElement ValeurPlusGrandeV1<TypeElement>(LinkedList<TypeElement> p_listeChainee)
        where TypeElement : IComparable
        {
            // Précondition
            if (p_listeChainee is null)
            {
                throw new ArgumentNullException("La liste chainée ne peut pas être null");
            }

            LinkedListNode<TypeElement> noeudCourrant = p_listeChainee.First;

            return ValeurPlusGrandeV1_rec(noeudCourrant);
        }
        private static TypeElement ValeurPlusGrandeV1_rec<TypeElement>(LinkedListNode<TypeElement> p_noeud)
        where TypeElement : IComparable
        {
            if (p_noeud.Next is null)
            {
                return p_noeud.Value;
            }

            TypeElement noeudSuivant = ValeurPlusGrandeV1_rec(p_noeud.Next);
            return p_noeud.Value.CompareTo(noeudSuivant) >= 0 ? p_noeud.Value : noeudSuivant;
        }

        // 4.3 Liste chainée fonction lambda
        public static void TraitementLambda<TypeElement>(LinkedList<TypeElement> p_listeChainee, Action<TypeElement> p_parcours)
        where TypeElement : IComparable
        {
            // Précondition
            if (p_listeChainee is null)
            {
                throw new ArgumentNullException("La liste chainée ne peut pas être null");
            }

            LinkedListNode<TypeElement> noeudCourrant = p_listeChainee.First;

            TraitementLambda_rec(noeudCourrant, p_parcours);
        }
        private static void TraitementLambda_rec<TypeElement>(LinkedListNode<TypeElement> p_noeud, Action<TypeElement> p_parcours)
        where TypeElement : IComparable
        {
            if (p_noeud.Next is null)
            {
                p_parcours(p_noeud.Value);
            }

            else
            {
                TraitementLambda_rec(p_noeud.Next, p_parcours);
                p_parcours(p_noeud.Value);
            }
        }

        // 4.4 Liste chainée NombreElementsV2
        public static int NombreElementV2<TypeElement>(LinkedList<TypeElement> p_listeChainee)
        {
            // Précondition
            if (p_listeChainee is null)
            {
                throw new ArgumentNullException("La liste chainée ne peut pas être null");
            }

            LinkedListNode<TypeElement> noeudCourrant = p_listeChainee.First;
            if (noeudCourrant is null)
            {
                return 0;
            }

            int compteur = 0;
            Action<TypeElement> incrementerCompteur = x => compteur++;

            ValeurPlusGrandeV2_rec(noeudCourrant, incrementerCompteur);
            return compteur;
        }
        private static int NombreElementV2_rec<TypeElement>(LinkedListNode<TypeElement> p_noeud, Action<TypeElement> p_incrementer)
        {
            if (p_noeud is null)
            {
                return 0;
            }

            p_incrementer(p_noeud.Value);
            return NombreElementV2_rec(p_noeud.Next, p_incrementer);
        }

        // 4.5 Liste chainée MaximumV2
        public static TypeElement ValeurPlusGrandeV2<TypeElement>(LinkedList<TypeElement> p_listeChainee)
        where TypeElement : IComparable
        {
            // Précondition
            if (p_listeChainee is null)
            {
                throw new ArgumentNullException("La liste chainée ne peut pas être null");
            }

            LinkedListNode<TypeElement> noeudCourrant = p_listeChainee.First;
            if (noeudCourrant is null)
            {
                return default;
            }

            TypeElement valeurPlusGrande = noeudCourrant.Value;
            Action<TypeElement> incrementerCompteur = x => valeurPlusGrande = valeurPlusGrande.CompareTo(x) < 0 ? x : valeurPlusGrande;

            ValeurPlusGrandeV2_rec(noeudCourrant, incrementerCompteur);
            return valeurPlusGrande;
        }
        private static TypeElement ValeurPlusGrandeV2_rec<TypeElement>(LinkedListNode<TypeElement> p_noeud, Action<TypeElement> p_comparer)
        {
            if (p_noeud is null)
            {
                return default;
            }

            p_comparer(p_noeud.Value);
            return ValeurPlusGrandeV2_rec(p_noeud.Next, p_comparer);
        }

        #endregion

        #region Recherche
        // 5.1 Recherche retourner default ou valeur
        public static TypeElement Recherche<TypeElement>(IEnumerable<TypeElement> p_collection, TypeElement p_valeurATrouver)
        {
            // Précondition
            if (p_collection is null)
            {
                throw new ArgumentNullException(nameof(p_collection), "La collection ne peut pas être null");
            }
            if(p_valeurATrouver is null)
            {
                throw new ArgumentNullException(nameof(p_valeurATrouver), "La valeur à trouver ne peut pas être null");
            }

            Func<TypeElement, bool> comparerValeur = x => p_valeurATrouver.Equals(x);
            return Recherche_rec(p_collection.GetEnumerator(), comparerValeur);
        }
        private static TypeElement Recherche_rec<TypeElement>(IEnumerator<TypeElement> p_enumerateur, Func<TypeElement, bool> p_lambda)
        {
            bool finParcours = !p_enumerateur.MoveNext();
            if (finParcours)
            {
                return default;
            }

            bool valeurEstTrouve = p_lambda(p_enumerateur.Current);
            if (valeurEstTrouve)
            {
                return p_enumerateur.Current;
            }

            return Recherche_rec(p_enumerateur, p_lambda);
        }

        // 5.2 Recherche retourner nombre occurence
        public static int RechercheNombreOccuurence<TypeElement>(IEnumerable<TypeElement> p_collection, TypeElement p_valeurATrouver)
        {
            // Précondition
            if (p_collection is null)
            {
                throw new ArgumentNullException(nameof(p_collection), "La collection ne peut pas être null");
            }
            if (p_valeurATrouver is null)
            {
                throw new ArgumentNullException(nameof(p_valeurATrouver), "La valeur à trouver ne peut pas être null");
            }

            Func<TypeElement, bool> comparerValeur = x => p_valeurATrouver.Equals(x);
            return RechercheNombreOccurence_rec(p_collection.GetEnumerator(), comparerValeur);
        }
        private static int RechercheNombreOccurence_rec<TypeElement>(IEnumerator<TypeElement> p_enumerateur, Func<TypeElement, bool> p_lambda)
        {
            bool finParcours = !p_enumerateur.MoveNext();
            if (finParcours)
            {
                return 0;
            }

            bool valeurEstTrouve = p_lambda(p_enumerateur.Current);
            if (valeurEstTrouve)
            {
                return 1 + RechercheNombreOccurence_rec(p_enumerateur, p_lambda);
            }

            return RechercheNombreOccurence_rec(p_enumerateur, p_lambda);
        }

        // 5.3 Rechercher avec filtre
        public static List<TypeElement> FiltrerCollection<TypeElement>(IEnumerable<TypeElement> p_collection, TypeElement p_valeurATrouver)
        {
            // Précondition
            if (p_collection is null)
            {
                throw new ArgumentNullException(nameof(p_collection), "La collection ne peut pas être null");
            }
            if (p_valeurATrouver is null)
            {
                throw new ArgumentNullException(nameof(p_valeurATrouver), "La valeur à trouver ne peut pas être null");
            }

            List<TypeElement> collectionFiltree = new List<TypeElement>();
            Func<TypeElement, bool> comparerValeur = x => p_valeurATrouver.Equals(x);
            return FiltrerCollection_rec(p_collection.GetEnumerator(), comparerValeur, collectionFiltree);
        }
        private static List<TypeElement> FiltrerCollection_rec<TypeElement>(IEnumerator<TypeElement> p_enumerateur, Func<TypeElement, bool> p_lambda, List<TypeElement> p_collectionFiltree)
        {
            bool finParcours = !p_enumerateur.MoveNext();
            if (finParcours)
            {
                return p_collectionFiltree;
            }

            bool valeurEstTrouve = p_lambda(p_enumerateur.Current);
            if (valeurEstTrouve)
            {
                p_collectionFiltree.Add(p_enumerateur.Current);
                return FiltrerCollection_rec(p_enumerateur, p_lambda, p_collectionFiltree);
            }

            return FiltrerCollection_rec(p_enumerateur, p_lambda, p_collectionFiltree);
        }
        #endregion

        #region RechercheDichotomique
        // 6.1 Recherche dichotomique
        public static TypeElement RechercherElement<TypeElement>(TypeElement[] p_collection, Func<TypeElement, int> p_comparaison)
        {
            // Précondition
            if (p_collection is null)
            {
                throw new ArgumentNullException(nameof(p_collection), "La collection ne peut pas être null");
            }
            // à voir pour la func si peut etre null

            return RechercherElement_rec(p_collection, p_comparaison, 0, p_collection.Length - 1);

        }
        private static TypeElement RechercherElement_rec<TypeElement>(TypeElement[] p_collection, Func<TypeElement, int> p_comparaison, int p_debut, int p_fin)
        {
            int pivot = (p_debut + p_fin) / 2;

            if (p_debut > p_fin)
            {
                return default;
            }
            else if (p_comparaison(p_collection[pivot]) == 0)
            {
                return p_collection[pivot];
            }
            else if (p_comparaison(p_collection[pivot]) < 0)
            {
                return RechercherElement_rec(p_collection, p_comparaison, p_debut, pivot - 1);
            }
            else
            {
                return RechercherElement_rec(p_collection, p_comparaison, pivot + 1, p_fin);
            }
        }
        #endregion
    }
}
