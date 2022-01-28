using System;
using ArbreBinaire_LibrairieClasses;

namespace ArbreBinaire_console
{
    class Program
    {
        static void Main(string[] args)
        {
            ArbreBinaire<int> test = GenerateurArbreBinaire.ExempleArbre1();

            test.ParcoursLargeur();
        }
    }
}
