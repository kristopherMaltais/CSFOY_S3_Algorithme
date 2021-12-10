using System;
using System.Collections.Generic;
using System.Linq;
using Dictionnaire_LibrairieClasses;

namespace Dictionnaire_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            CoupleClefValeur<int, int> couple1 = new CoupleClefValeur<int, int>(1, 2);
            CoupleClefValeur<int, int> couple2 = new CoupleClefValeur<int, int>(2, 2);
            CoupleClefValeur<int, int> couple3 = new CoupleClefValeur<int, int>(3, 2);
            CoupleClefValeur<int, int> couple4 = new CoupleClefValeur<int, int>(4, 2);

            LinkedList<CoupleClefValeur<int, int>> liste1 = new LinkedList<CoupleClefValeur<int, int>>();
            liste1.AddLast(couple1);
            liste1.AddLast(couple2);

            LinkedList<CoupleClefValeur<int, int>> liste2 = new LinkedList<CoupleClefValeur<int, int>>();
            liste2.AddLast(couple3);
            liste2.AddLast(couple4);

            LinkedList<CoupleClefValeur<int, int>>[] tableau = new LinkedList<CoupleClefValeur<int, int>>[] { liste1, liste2 };

            var resultat = tableau.SelectMany(array => array);

            foreach(CoupleClefValeur<int, int> x in resultat)
            {
                Console.WriteLine(x.Clef);
            }

            LinkedList<CoupleClefValeur<int, int>>[] tableau2 = new LinkedList<CoupleClefValeur<int, int>>[5];

            
        }
    }
    
}
