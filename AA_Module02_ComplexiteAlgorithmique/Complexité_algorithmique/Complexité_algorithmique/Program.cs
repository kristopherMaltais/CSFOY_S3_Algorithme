using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Complexité_algorithmique
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> liste = new List<int>() { 6, 5, 7, 4, 8, 2, 12, 4, 3, 65, 34, 87, 34, 6, 6, 5, 7, 9, 4, 6, 7, 5, 4, 7, 6, 5, 7, 4, 8, 2, 12, 4, 3, 65, 34, 87, 34, 6, 6, 5, 7, 9, 4, 6, 7, 5, 4, 7, 6, 5, 7, 4, 8, 2, 12, 4, 3, 65, 34, 87, 34, 6, 6, 5, 7, 9, 4, 6, 7, 5, 4, 7, 6, 5, 7, 4, 8, 2, 12, 4, 3, 65, 34, 87, 34, 6, 6, 5, 7, 9, 4, 6, 7, 5, 4, 7, 6, 5, 7, 4, 8, 2, 12, 4, 3, 65, 34, 87, 34, 6, 6, 5, 7, 9, 4, 6, 7, 5, 4, 7, 6, 5, 7, 4, 8, 2, 12, 4, 3, 65, 34, 87, 34, 6, 6, 5, 7, 9, 4, 6, 7, 5, 4, 7, 6, 5, 7, 4, 8, 2, 12, 4, 3, 65, 34, 87, 34, 6, 6, 5, 7, 9, 4, 6, 7, 5, 4, 7, 6, 5, 7, 4, 8, 2, 12, 4, 3, 65, 34, 87, 34, 6, 6, 5, 7, 9, 4, 6, 7, 5, 4, 7 };
            Stopwatch timer = new Stopwatch();
            timer.Start();
            ///////////////////////////////////
            
            int resultat = RechercherMinimumTrie(liste);

            ///////////////////////////////////
            timer.Stop();
            Console.WriteLine(timer.Elapsed);

            
        }

        public static TypeElement RechercherMinimum<TypeElement>(List<TypeElement> p_liste)
        where TypeElement: IComparable<TypeElement>
        {
            TypeElement valeurMinimum = p_liste.First();

            for(int index = 1; index < p_liste.Count; index++) // O(n)
            {
                if(valeurMinimum.CompareTo(p_liste[index]) == 1)
                {
                    valeurMinimum = p_liste[index];
                }
            }

            return valeurMinimum;
        }

        public static TypeElement RechercherMinimumTrie<TypeElement>(List<TypeElement> p_liste)
        where TypeElement : IComparable<TypeElement>
        {
            var listeTriee = p_liste.OrderBy(x => x).ToList(); // O(N LogN)
            
            TypeElement valeurMinimum = listeTriee.First();
            return valeurMinimum;
        }
    }
}
