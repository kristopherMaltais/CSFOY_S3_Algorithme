using AbreNAire_LibrairieClasses;
using System;
using System.Collections.Generic;

namespace ArbreNAire_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ArbreExpression arbre =GenerateurArbreExpression.ExempleExpression1();

            Console.WriteLine(arbre.NoeudRacine.Calculer().ToString());
        }
    }
}
